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
    /// ע���¼��������
    /// </summary>
    /// <typeparam name="TEventHandler">�¼����������ʵ�� <see cref="IEventHandler"/> �ӿ�</typeparam>
    /// <param name="services">���񼯺϶���</param>
    /// <returns>���񼯺϶���</returns>
    public static IServiceCollection AddEventHandler<TEventHandler>(this IServiceCollection services)
        where TEventHandler : class, IEventHandler
    {
        // ���¼��������ע��Ϊ����
        services.AddSingleton<IEventHandler, TEventHandler>();

        return services;
    }

    /// <summary>
    /// ��� EventBus ģ��ע��
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <param name="configuration">���ö���</param>
    /// <returns>���񼯺�ʵ��</returns>
    public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
    {
        // ע���ڲ�����
        services.AddInternalService(configuration);

        // ע���¼����ߺ�̨����
        services.AddHostedService<EventBusHostedService>();

        return services;
    }

    /// <summary>
    /// ��� EventBus ģ��ע��
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <<param name="configuration">���ö���</param>
    /// <param name="unobservedTaskExceptionHandler">δ��������쳣�¼��������</param>
    /// <returns>���񼯺�ʵ��</returns>
    public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration, EventHandler<UnobservedTaskExceptionEventArgs> unobservedTaskExceptionHandler)
    {
        // ע���ڲ�����
        services.AddInternalService(configuration);

        // ͨ������ģʽ����
        return services.AddHostedService(serviceProvider =>
        {
            // �����¼����ߺ�̨�������
            var eventBusHostedService = ActivatorUtilities.CreateInstance<EventBusHostedService>(serviceProvider);

            // ����δ��������쳣�¼�
            eventBusHostedService.UnobservedTaskException += unobservedTaskExceptionHandler;

            return eventBusHostedService;
        });
    }

    /// <summary>
    /// ע���ڲ�����
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <param name="configuration">���ö���</param>
    /// <returns>���񼯺�ʵ��</returns>
    private static IServiceCollection AddInternalService(this IServiceCollection services, IConfiguration configuration)
    {
        // ע���̨������нӿ�/ʵ��Ϊ���������ù�����ʽ����
        services.AddSingleton<IEventStoreChannel>(_ =>
        {
            // ��ȡ EventBus ģ�����ã�����ȡ����ͨ��������Ĭ��Ϊ 100
            if (!int.TryParse(configuration[Constants.Keys.Capacity], out var capacity))
            {
                capacity = Constants.Values.Capacity;
            }

            // �����¼���ȡ������
            return new EventStoreChannel(capacity);
        });

        // ע���¼�����
        services.AddSingleton<IEventPulisher, EventPulisher>();

        return services;
    }
}