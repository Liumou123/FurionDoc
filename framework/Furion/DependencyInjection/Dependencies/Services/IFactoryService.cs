﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.DependencyInjection;

namespace System;

/// <summary>
/// 基于工厂的服务依赖接口
/// </summary>
public interface IFactoryService<TServiceType, TDependency>
    where TServiceType : class
    where TDependency : IDependency
{
    /// <summary>
    /// 实现工厂
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <returns></returns>
    object ImplementationFactory(IServiceProvider serviceProvider);
}