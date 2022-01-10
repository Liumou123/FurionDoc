﻿// Copyright (c) 2020-2022 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

namespace Furion.Schedule;

/// <summary>
/// 作业调度器工厂依赖接口
/// </summary>
internal interface ISchedulerJobFactory
{
    /// <summary>
    /// 作业调度器集合
    /// </summary>
    ICollection<SchedulerJob> SchedulerJobs { get; }

    /// <summary>
    /// 根据作业 Id 获取作业调度器
    /// </summary>
    /// <param name="jobId">作业 Id</param>
    /// <param name="schedulerJob">作业调度器</param>
    /// <returns><see cref="bool"/></returns>
    bool TryGet(string jobId, out SchedulerJob? schedulerJob);

    /// <summary>
    /// 向工厂中追加作业调度器
    /// </summary>
    /// <param name="schedulerJob">调度作业对象</param>
    void Append(SchedulerJob schedulerJob);

    /// <summary>
    /// 尝试删除作业调度器
    /// </summary>
    /// <param name="jobId">作业 Id</param>
    /// <param name="schedulerJob">作业调度器</param>
    /// <returns><see cref="bool"/></returns>
    bool TryRemove(string jobId, out SchedulerJob? schedulerJob);

    /// <summary>
    /// 启动所有作业调度器
    /// </summary>
    void StartAll();

    /// <summary>
    /// 暂停所有作业调度器
    /// </summary>
    void PauseAll();
}