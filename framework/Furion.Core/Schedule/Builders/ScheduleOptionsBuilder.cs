﻿// Copyright (c) 2020-2022 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Microsoft.Extensions.DependencyInjection;

namespace Furion.Schedule;

/// <summary>
/// Schedule 模块配置选项构建器
/// </summary>
public sealed class ScheduleOptionsBuilder
{
    /// <summary>
    /// 作业调度程序构建器集合
    /// </summary>
    private readonly IList<SchedulerBuilder> _schedulerBuilders;

    /// <summary>
    /// 作业监视器
    /// </summary>
    private Type? _jobMonitor;

    /// <summary>
    /// 作业执行器
    /// </summary>
    private Type? _jobExecutor;

    /// <summary>
    /// 构造函数
    /// </summary>
    public ScheduleOptionsBuilder()
    {
        _schedulerBuilders = new List<SchedulerBuilder>();
    }

    /// <summary>
    /// 未察觉任务异常处理程序
    /// </summary>
    public EventHandler<UnobservedTaskExceptionEventArgs>? UnobservedTaskExceptionHandler { get; set; }

    /// <summary>
    /// 注册作业
    /// </summary>
    /// <param name="schedulerBuilder">作业调度程序构建器</param>
    /// <returns><see cref="ScheduleOptionsBuilder"/></returns>
    public ScheduleOptionsBuilder AddJob(SchedulerBuilder schedulerBuilder)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(schedulerBuilder);

        // 添加到作业调度器构建器集合中
        _schedulerBuilders.Add(schedulerBuilder);

        return this;
    }

    /// <summary>
    /// 注册作业监视器
    /// </summary>
    /// <typeparam name="TJobMonitor">实现自 <see cref="IJobMonitor"/></typeparam>
    /// <returns><see cref="ScheduleOptionsBuilder"/></returns>
    public ScheduleOptionsBuilder AddMonitor<TJobMonitor>()
        where TJobMonitor : class, IJobMonitor
    {
        _jobMonitor = typeof(TJobMonitor);
        return this;
    }

    /// <summary>
    /// 注册作业执行器
    /// </summary>
    /// <typeparam name="TJobExecutor">实现自 <see cref="IJobExecutor"/></typeparam>
    /// <returns><see cref="ScheduleOptionsBuilder"/></returns>
    public ScheduleOptionsBuilder AddExecutor<TJobExecutor>()
        where TJobExecutor : class, IJobExecutor
    {
        _jobExecutor = typeof(TJobExecutor);
        return this;
    }

    /// <summary>
    /// 构建 <see cref="Scheduler"/> 集合
    /// </summary>
    /// <param name="services">服务集合对象</param>
    /// <returns>IList{<see cref="Scheduler"/>}</returns>
    internal IList<Scheduler> Build(IServiceCollection services)
    {
        // 注册作业监视器
        if (_jobMonitor != default)
        {
            services.AddSingleton(typeof(IJobMonitor), _jobMonitor);
        }

        // 注册作业执行器
        if (_jobExecutor != default)
        {
            services.AddSingleton(typeof(IJobExecutor), _jobExecutor);
        }

        // 构建作业调度器
        return _schedulerBuilders.Select(s => s.Build()).ToList();
    }
}