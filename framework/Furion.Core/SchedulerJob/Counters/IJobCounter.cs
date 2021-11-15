﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

namespace Furion.SchedulerJob;

/// <summary>
/// 作业计数器
/// </summary>
public interface IJobCounter
{
    /// <summary>
    /// 最近运行时间
    /// </summary>
    DateTime LastRunTime { get; }

    /// <summary>
    /// 下一次运行时间
    /// </summary>
    DateTime NextRunTime { get; }

    /// <summary>
    /// 运行次数
    /// </summary>
    long NumberOfRuns { get; }
}