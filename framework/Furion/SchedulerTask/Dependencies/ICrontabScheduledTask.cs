﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.TimeCrontab;

namespace Furion.SchedulerTask;

/// <summary>
/// 执行 Cron 表达式任务
/// </summary>
public interface ICrontabScheduledTask : IScheduledTask
{
    /// <summary>
    /// Cron 表达式
    /// </summary>
    string Schedule { get; }

    /// <summary>
    /// Cron 表达式格式化，默认 <see cref="CronStringFormat.Default"/>
    /// </summary>
    CronStringFormat Format { get; set; }
}