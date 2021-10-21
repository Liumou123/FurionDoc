﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

namespace Furion.EventBus;

/// <summary>
/// 事件订阅者处理程序执行前上下文
/// </summary>
public sealed class EventSubscribeExecutingContext : EventSubscribeContext
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="eventSource">事件源（事件承载对象）</param>
    internal EventSubscribeExecutingContext(IEventSource eventSource)
        : base(eventSource)
    {
    }

    /// <summary>
    /// 执行前时间
    /// </summary>
    public DateTime ExecutingTime { get; internal set; }
}