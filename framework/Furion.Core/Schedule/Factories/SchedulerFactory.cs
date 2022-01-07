﻿// Copyright (c) 2020-2022 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

namespace Furion.Schedule;

/// <summary>
/// 调度工厂依赖接口
/// </summary>
internal sealed class SchedulerFactory : ISchedulerFactory
{
    /// <summary>
    /// 作业存储器
    /// </summary>
    private readonly IJobStorer _jobStorer;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="jobStorer">作业存储器</param>
    public SchedulerFactory(IJobStorer jobStorer)
    {
        _jobStorer = jobStorer;
    }

    /// <summary>
    /// 动态添加作业
    /// </summary>
    /// <typeparam name="TJob"><see cref="IJob"/> 实现类</typeparam>
    /// <param name="configureSchedulerJobBuilder">调度作业构建器委托</param>
    public void AddJob<TJob>(Action<SchedulerJobBuilder> configureSchedulerJobBuilder)
         where TJob : class, IJob
    {
        AddJob(typeof(TJob), configureSchedulerJobBuilder);
    }

    /// <summary>
    /// 动态添加作业
    /// </summary>
    /// <param name="jobType">作业类型</param>
    /// <param name="configureSchedulerJobBuilder">调度作业构建器委托</param>
    public void AddJob(Type jobType, Action<SchedulerJobBuilder> configureSchedulerJobBuilder)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(configureSchedulerJobBuilder);

        // jobType 须实现 IJob 接口
        if (!typeof(IJob).IsAssignableFrom(jobType))
        {
            throw new InvalidOperationException("The <jobType> does not implement <IJob> interface.");
        }

        // 创建调度作业对象
        var schedulerJobBuilder = new SchedulerJobBuilder(jobType);

        // 调用委托
        configureSchedulerJobBuilder(schedulerJobBuilder);

        // 解析作业实例
        var schedulerJob = schedulerJobBuilder.Build(DateTime.UtcNow);

        // 存储调度作业
        _jobStorer.AddSchedulerJob(schedulerJob);
    }
}