﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.TimeCrontab;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Furion.SchedulerJob;

/// <summary>
/// 调度作业配置选项构建器
/// </summary>
public sealed class SchedulerJobOptionsBuilder
{
    /// <summary>
    /// 作业类型集合
    /// </summary>
    private readonly Dictionary<Type, (IJobIdentity, IJobTrigger)> _jobs = new();

    /// <summary>
    /// 未察觉任务异常事件处理程序
    /// </summary>
    public EventHandler<UnobservedTaskExceptionEventArgs>? UnobservedTaskExceptionHandler { get; set; }

    /// <summary>
    /// 注册作业
    /// </summary>
    /// <typeparam name="TJob"><see cref="IJob"/> 实例</typeparam>
    /// <param name="jobTrigger">作业触发器</param>
    /// <returns><see cref="SchedulerJobOptionsBuilder"/> 实例</returns>
    public SchedulerJobOptionsBuilder AddJob<TJob>(IJobTrigger? jobTrigger = default)
        where TJob : class, IJob
    {
        return AddJob(typeof(TJob), jobTrigger);
    }

    /// <summary>
    /// 注册作业
    /// </summary>
    /// <param name="jobType">作业类型，必须实现 <see cref="IJob"/> 接口</param>
    /// <param name="jobTrigger">作业触发器</param>
    /// <returns><see cref="SchedulerJobOptionsBuilder"/> 实例</returns>
    public SchedulerJobOptionsBuilder AddJob(Type jobType, IJobTrigger? jobTrigger = default)
    {
        if (!typeof(IJob).IsAssignableFrom(jobType))
        {
            throw new InvalidOperationException("The <jobType> does not implement <IJob> interface.");
        }

        // 判断是否贴有 [Job] 或其派生类特性
        if (!jobType.IsDefined(typeof(JobAttribute), false))
        {
            throw new InvalidOperationException("The [Job] attribute is not added to the current job.");
        }

        // 获取 [Job] 特性具体类型
        var jobAttribute = jobType.GetCustomAttribute<JobAttribute>(false)!;

        // 创建作业标识器
        IJobIdentity identity = new JobIdentity(jobAttribute.Identity);

        // 创建作业触发器
        IJobTrigger trigger;
        if (jobTrigger != default)
        {
            trigger = jobTrigger;
        }
        else
        {
            // 解析 Cron 表达式触发器
            if (jobAttribute is CronJobAttribute cronJobAttribute)
            {
                // 解析速率
                var rates = cronJobAttribute.Format == CronStringFormat.WithSeconds || cronJobAttribute.Format == CronStringFormat.WithSecondsAndYears
                    ? TimeSpan.FromSeconds(1)
                    : TimeSpan.FromMinutes(1);

                trigger = new CronTrigger(rates, Crontab.Parse(cronJobAttribute.Schedule, cronJobAttribute.Format))
                {
                    NextRunTime = DateTime.UtcNow
                };
            }
            // 解析周期触发器
            else if (jobAttribute is SimpleJobAttribute simpleJobAttribute)
            {
                trigger = new SimpleTrigger(TimeSpan.FromMilliseconds(simpleJobAttribute.Interval))
                {
                    NextRunTime = DateTime.UtcNow
                };
            }
            else
            {
                throw new InvalidOperationException("Job trigger not found.");
            }
        }

        // 禁止重复注册作业
        if (!_jobs.TryAdd(jobType, (identity, trigger)))
        {
            throw new InvalidOperationException("The job has been registered. Repeated registration is prohibited.");
        }

        return this;
    }

    /// <summary>
    /// 构建调度作业配置选项
    /// </summary>
    /// <param name="services">服务集合对象</param>
    internal void Build(IServiceCollection services)
    {
        // 注册事件订阅者
        foreach (var (jobType, (identity, trigger)) in _jobs)
        {
            AddJob(services, jobType, identity, trigger);
        }
    }

    /// <summary>
    /// 注册作业
    /// </summary>
    /// <param name="services">服务集合对象</param>
    /// <param name="jobType">作业类型</param>
    /// <param name="identity">作业标识器</param>
    /// <param name="trigger">作业触发器</param>
    /// <exception cref="InvalidOperationException"></exception>
    private void AddJob(IServiceCollection services, Type jobType, IJobIdentity identity, IJobTrigger trigger)
    {
        // 将作业注册为单例
        services.AddSingleton(jobType);

        // 创建作业调度器
        services.AddHostedService(serviceProvider =>
        {
            // 获取作业存储器
            var storer = serviceProvider.GetRequiredService<IJobStorer>();
            storer.Register(identity);

            var jobScheduler = new JobScheduler(serviceProvider.GetRequiredService<ILogger<JobScheduler>>()
                , serviceProvider
                , storer
                , identity,
                (serviceProvider.GetRequiredService(jobType) as IJob)!
                , trigger);

            // 订阅未察觉任务异常事件
            var unobservedTaskExceptionHandler = UnobservedTaskExceptionHandler;
            if (unobservedTaskExceptionHandler != default)
            {
                jobScheduler.UnobservedTaskException += unobservedTaskExceptionHandler;
            }

            return jobScheduler;
        });
    }
}