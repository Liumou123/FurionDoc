﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.Hosting;

/// <summary>
/// 框架内服务提供器工厂主机拓展类
/// </summary>
internal static class AppServiceProviderFactoryHostBuilderExtensions
{
    /// <summary>
    /// 使用框架提供的服务提供器工厂
    /// </summary>
    /// <param name="hostBuilder"></param>
    /// <param name="configureDelegate"></param>
    /// <returns></returns>
    internal static IHostBuilder UseAppServiceProviderFactory(this IHostBuilder hostBuilder, Action<HostBuilderContext, ServiceProviderOptions>? configureDelegate = default)
    {
        // 替换 .NET 默认工厂
        return hostBuilder.UseServiceProviderFactory(context =>
        {
            // 创建默认配置选项
            var serviceProviderOptions = new ServiceProviderOptions();
            var validateOnBuild = (serviceProviderOptions.ValidateScopes = context.HostingEnvironment.IsDevelopment());
            serviceProviderOptions.ValidateOnBuild = validateOnBuild;

            configureDelegate?.Invoke(context, serviceProviderOptions);

            return new AppServiceProviderFactory(context, serviceProviderOptions);
        });
    }
}