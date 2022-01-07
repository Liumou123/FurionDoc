﻿// Copyright (c) 2020-2022 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Furion.Schedule;

/// <summary>
/// 作业调度作业工厂默认实现
/// </summary>
internal sealed class SchedulerFactory : ISchedulerFactory
{
    /// <summary>
    /// 作业调度器字典集合
    /// </summary>
    private readonly ConcurrentDictionary<string, SchedulerJob> _schedulerJobs;

    /// <summary>
    /// 日志对象
    /// </summary>
    private readonly ILogger<SchedulerFactory> _logger;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志对象</param>
    public SchedulerFactory(ILogger<SchedulerFactory> logger)
    {
        _schedulerJobs = new();
        _logger = logger;
    }

    /// <summary>
    /// 添加作业调度器
    /// </summary>
    /// <param name="schedulerJob">调度作业对象</param>
    public void AddSchedulerJob(SchedulerJob schedulerJob)
    {
        var jobId = schedulerJob.JobDetail.JobId!;

        // 检查作业 Id 唯一性
        if (!_schedulerJobs.TryAdd(jobId, schedulerJob))
        {
            throw new InvalidOperationException($"The job <{jobId}> has been registered. Repeated registration is prohibited.");
        }

        var logTemplate = @"┏━━━━━━━━━━ Schedule Console ━━━━━━━━━━
┣ JobId：           {JobId}
┣ Description：     {Description}
┣ JobType：         {JobType}
┣ Triggers：        [{EarliestNextRunTime}] {Triggers}
┣ StartMode：       {StartMode}
┣ ExecutionMode：   {ExecutionMode}
┗━━━━━━━━━━ Schedule Console ━━━━━━━━━━";

        // 打印添加成功日志
        _logger.LogInformation(logTemplate
            , jobId
            , schedulerJob.JobDetail.Description
            , schedulerJob.JobDetail.JobType
            , schedulerJob.GetEarliestNextRunTime()
            , string.Join(';', schedulerJob.Triggers.Select(u => u.TriggerType + "/" + u.ToString()))
            , schedulerJob.JobDetail.StartMode
            , schedulerJob.JobDetail.ExecutionMode);
    }

    /// <summary>
    /// 尝试删除作业调度器
    /// </summary>
    /// <param name="jobId">作业 Id</param>
    /// <param name="schedulerJob">作业调度器</param>
    /// <returns><see cref="bool"/></returns>
    public bool TryRemoveSchedulerJob(string jobId, out SchedulerJob? schedulerJob)
    {
        var canRemove = _schedulerJobs.TryRemove(jobId, out schedulerJob);

        // 打印移除日志
        if (canRemove)
        {
            _logger.LogWarning("The <{JobId}> job has been removed from the schedule.", schedulerJob!.JobDetail.JobId);
        }

        return canRemove;
    }

    /// <summary>
    /// 获取所有作业调度器
    /// </summary>
    /// <returns><see cref="ICollection{T}"/></returns>
    public ICollection<SchedulerJob> GetSchedulerJobs()
    {
        return _schedulerJobs.Values;
    }
}