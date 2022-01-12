// Copyright (c) 2020-2022 ��Сɮ, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.Schedule;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Schedule ģ�������չ
/// </summary>
public static class ScheduleServiceCollectionExtensions
{
    /// <summary>
    /// ��� Schedule ģ��ע��
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <param name="configureOptionsBuilder">������ҵ����ѡ�����ί��</param>
    /// <returns>���񼯺�ʵ��</returns>
    public static IServiceCollection AddSchedule(this IServiceCollection services, Action<ScheduleOptionsBuilder> configureOptionsBuilder)
    {
        // ������ʼ������ҵ����ѡ�����
        var scheduleOptionsBuilder = new ScheduleOptionsBuilder();
        configureOptionsBuilder.Invoke(scheduleOptionsBuilder);

        return services.AddSchedule(scheduleOptionsBuilder);
    }

    /// <summary>
    /// ��� Schedule ģ��ע��
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <param name="scheduleOptionsBuilder">������ҵ����ѡ�����</param>
    /// <returns>���񼯺�ʵ��</returns>
    public static IServiceCollection AddSchedule(this IServiceCollection services, ScheduleOptionsBuilder? scheduleOptionsBuilder = default)
    {
        // ��ʼ��������ҵ������
        scheduleOptionsBuilder ??= new ScheduleOptionsBuilder();

        // ע���ڲ�����
        services.AddInternalService();

        // ���� Schedule ����ѡ�������ҵ����������
        var schedulerJobs = scheduleOptionsBuilder.Build(services);

        // ͨ������ģʽ����
        services.AddHostedService(serviceProvider =>
        {
            // ����������������̨�������
            var schedulerFactoryHostedService = ActivatorUtilities.CreateInstance<ScheduleHostedService>(serviceProvider, schedulerJobs);

            // ����δ��������쳣�¼�
            var unobservedTaskExceptionHandler = scheduleOptionsBuilder.UnobservedTaskExceptionHandler;
            if (unobservedTaskExceptionHandler != default)
            {
                schedulerFactoryHostedService.UnobservedTaskException += unobservedTaskExceptionHandler;
            }

            return schedulerFactoryHostedService;
        });

        return services;
    }

    /// <summary>
    /// ע���ڲ�����
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <returns>���񼯺�ʵ��</returns>
    private static IServiceCollection AddInternalService(this IServiceCollection services)
    {
        // ע����ҵ����������
        services.AddSingleton<ISchedulerJobFactory, SchedulerJobFactory>();

        // ע�� Schedule ģ��ӿ�
        services.AddSingleton<ISchedule, InternalSchedule>();

        return services;
    }
}