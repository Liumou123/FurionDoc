// Copyright (c) 2020-2021 ��Сɮ, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.EventBus;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// EventBus ģ�������չ
/// </summary>
public static class EventBusServiceCollectionExtensions
{
    /// <summary>
    /// ע���¼�������
    /// </summary>
    /// <typeparam name="TEventSubscriber">ʵ���� <see cref="IEventSubscriber"/></typeparam>
    /// <param name="services">���񼯺϶���</param>
    /// <returns>���񼯺϶���</returns>
    public static IServiceCollection AddEventSubscriber<TEventSubscriber>(this IServiceCollection services)
        where TEventSubscriber : class, IEventSubscriber
    {
        // ���¼�������ע��Ϊ����
        services.AddSingleton<IEventSubscriber, TEventSubscriber>();

        return services;
    }

    /// <summary>
    /// �滻�¼������¼�ԴĬ�ϴ�ȡ��
    /// </summary>
    /// <remarks>���� <see cref="AddEventBus(IServiceCollection, EventBusOptions?)"/> ֮������</remarks>
    /// <param name="services">���񼯺϶���</param>
    /// <param name="implementationFactory">�����Զ����¼���ȡ�����󹤳�</param>
    /// <returns>���񼯺϶���</returns>
    public static IServiceCollection ReplaceEventStoreChannel(this IServiceCollection services, Func<IServiceProvider, IEventStoreChannel> implementationFactory)
    {
        return services.Replace(ServiceDescriptor.Singleton(implementationFactory));
    }

    /// <summary>
    /// ��� EventBus ģ��ע��
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <param name="configureOptions">�¼���������ѡ��ί��</param>
    /// <returns>���񼯺�ʵ��</returns>
    public static IServiceCollection AddEventBus(this IServiceCollection services, Action<EventBusOptions> configureOptions)
    {
        // ������ʼ�¼���������ѡ��
        var eventBusOptions = new EventBusOptions();
        configureOptions.Invoke(eventBusOptions);

        return services.AddEventBus(eventBusOptions);
    }

    /// <summary>
    /// ��� EventBus ģ��ע��
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <param name="eventBusOptions">�¼���������ѡ��</param>
    /// <returns>���񼯺�ʵ��</returns>
    public static IServiceCollection AddEventBus(this IServiceCollection services, EventBusOptions? eventBusOptions = default)
    {
        // ������������
        eventBusOptions ??= new EventBusOptions();

        // ע���ڲ�����
        services.AddInternalService(eventBusOptions);

        // ͨ������ģʽ����
        return services.AddHostedService(serviceProvider =>
        {
            // �����¼����ߺ�̨�������
            var eventBusHostedService = ActivatorUtilities.CreateInstance<EventBusHostedService>(serviceProvider);

            // ����δ��������쳣�¼�
            var unobservedTaskExceptionHandler = eventBusOptions.UnobservedTaskExceptionHandler;
            if (unobservedTaskExceptionHandler != default)
            {
                eventBusHostedService.UnobservedTaskException += unobservedTaskExceptionHandler;
            }

            return eventBusHostedService;
        });
    }

    /// <summary>
    /// ע���ڲ�����
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <param name="eventBusOptions">�¼���������ѡ��</param>
    /// <returns>���񼯺�ʵ��</returns>
    private static IServiceCollection AddInternalService(this IServiceCollection services, EventBusOptions eventBusOptions)
    {
        // ע���̨������нӿ�/ʵ��Ϊ���������ù�����ʽ����
        services.AddSingleton<IEventStoreChannel>(_ =>
        {
            // �����¼���ȡ������
            return new EventStoreChannel(eventBusOptions.ChannelCapacity);
        });

        // ע���¼�������
        services.AddSingleton<IEventPulisher, EventPulisher>();

        return services;
    }
}