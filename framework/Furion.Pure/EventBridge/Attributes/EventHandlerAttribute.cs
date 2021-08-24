﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             http://license.coscl.org.cn/MulanPSL2
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.DependencyInjection;

namespace Furion.EventBridge;

/// <summary>
/// 事件处理程序特性
/// </summary>
[SuppressSniffer, AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class EventHandlerAttribute : Attribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public EventHandlerAttribute()
    {
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="category"></param>
    public EventHandlerAttribute(string category)
    {
        Category = category;
    }

    /// <summary>
    /// 分类名
    /// </summary>
    public string Category { get; set; }
}
