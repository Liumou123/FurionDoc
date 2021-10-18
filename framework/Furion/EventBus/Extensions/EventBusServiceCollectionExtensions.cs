// Copyright (c) 2020-2021 ��Сɮ, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.EventBus;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// EventBus ģ�������չ
/// </summary>
public static class EventBusServiceCollectionExtensions
{
    /// <summary>
    /// ��� EventBus ģ��ע��
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <returns>���񼯺�ʵ��</returns>
    public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEventChannelService(configuration);
        services.AddHostedService<EventBusHostedService>();

        return services;
    }

    /// <summary>
    /// ��� EventBus ģ��ע��
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <param name="unobservedTaskExceptionHandler">δ��������쳣�¼��������</param>
    /// <returns>���񼯺�ʵ��</returns>
    public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration, EventHandler<UnobservedTaskExceptionEventArgs> unobservedTaskExceptionHandler)
    {
        services.AddEventChannelService(configuration);

        // ͨ������ģʽ����
        return services.AddHostedService(serviceProvider =>
        {
            // �����������
            var eventBusHostedService = ActivatorUtilities.CreateInstance<EventBusHostedService>(serviceProvider);

            // ����δ��������쳣�¼�
            eventBusHostedService.UnobservedTaskException += unobservedTaskExceptionHandler;

            return eventBusHostedService;
        });
    }

    /// <summary>
    /// ע�� EventChannel ����
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <param name="configuration">���ö���</param>
    /// <returns>���񼯺�ʵ��</returns>
    private static IServiceCollection AddEventChannelService(this IServiceCollection services, IConfiguration configuration)
    {
        // ע���̨������нӿ�/ʵ��Ϊ���������ù�����ʽ����
        services.AddSingleton<IEventChannel>(_ =>
        {
            // ��ȡ EventBus ģ�����ã�����ȡ����ͨ��������Ĭ��Ϊ 100
            if (!int.TryParse(configuration[Constants.Keys.Capacity], out var capacity))
            {
                capacity = Constants.Values.Capacity;
            }

            // ������̨����ʵ��
            return new EventChannel(capacity);
        });

        return services;
    }
}