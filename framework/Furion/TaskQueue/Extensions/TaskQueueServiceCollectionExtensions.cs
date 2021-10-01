﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.TaskQueue;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// TaskQueue 模块服务拓展
/// </summary>
public static class TaskQueueServiceCollectionExtensions
{
    /// <summary>
    /// 添加 TaskQueue 模块注册
    /// </summary>
    /// <param name="services">服务集合对象</param>
    /// <param name="configuration">配置对象</param>
    /// <returns>服务集合实例</returns>
    public static IServiceCollection AddTaskQueue(this IServiceCollection services, IConfiguration configuration)
    {
        // 注册任务队列后台服务
        services.AddHostedService<TaskQueuedHostedService>();

        // 注册 BackgroundTaskQueue 服务
        services.AddTaskQueueService(configuration);

        return services;
    }

    /// <summary>
    /// 注册 TaskQueue 服务
    /// </summary>
    /// <param name="services">服务集合对象</param>
    /// <param name="configuration">配置对象</param>
    /// <returns>服务集合实例</returns>
    private static IServiceCollection AddTaskQueueService(this IServiceCollection services, IConfiguration configuration)
    {
        // 注册后台任务队列接口/实例为单例，采用工厂方式创建
        services.AddSingleton<ITaskQueue>(_ =>
        {
            // 读取 TaskQueue 模块配置，并获取队列通道容量，默认为 100
            if (!int.TryParse(configuration["TaskQueue:Capacity"], out var capacity))
            {
                capacity = 100;
            }

            // 创建后台队列实例
            return new TaskQueue(capacity);
        });

        return services;
    }
}