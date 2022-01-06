// Copyright (c) 2020-2022 ��Сɮ, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.JobScheduler;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// JobScheduler ģ�������չ
/// </summary>
public static class SchedulerJobServiceCollectionExtensions
{
    /// <summary>
    /// ��� JobScheduler ģ��ע��
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <param name="configureOptionsBuilder">������ҵ����ѡ�����ί��</param>
    /// <returns>���񼯺�ʵ��</returns>
    public static IServiceCollection AddJobScheduler(this IServiceCollection services, Action<JobSchedulerOptionsBuilder> configureOptionsBuilder)
    {
        // ������ʼ������ҵ����ѡ�����
        var jobSchedulerOptionsBuilder = new JobSchedulerOptionsBuilder();
        configureOptionsBuilder.Invoke(jobSchedulerOptionsBuilder);

        return services.AddJobScheduler(jobSchedulerOptionsBuilder);
    }

    /// <summary>
    /// ��� JobScheduler ģ��ע��
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <param name="jobSchedulerOptionsBuilder">������ҵ����ѡ�����</param>
    /// <returns>���񼯺�ʵ��</returns>
    public static IServiceCollection AddJobScheduler(this IServiceCollection services, JobSchedulerOptionsBuilder? jobSchedulerOptionsBuilder = default)
    {
        // ��ʼ��������ҵ������
        jobSchedulerOptionsBuilder ??= new JobSchedulerOptionsBuilder();

        // ע���ڲ�����
        services.AddInternalService();

        // ������ҵ����������
        var schedulerJobBuilders = jobSchedulerOptionsBuilder.Build(services);

        // ͨ������ģʽ����
        services.AddHostedService(serviceProvider =>
        {
            // ����������������̨�������
            var schedulerFactoryHostedService = ActivatorUtilities.CreateInstance<SchedulerFactoryHostedService>(serviceProvider
                , schedulerJobBuilders
                , jobSchedulerOptionsBuilder.TimeBeforeSync
                , jobSchedulerOptionsBuilder.MinimumSyncInterval);

            // ����δ��������쳣�¼�
            var unobservedTaskExceptionHandler = jobSchedulerOptionsBuilder.UnobservedTaskExceptionHandler;
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
        // ע����ҵ�洢�������ù�����ʽ����
        services.AddSingleton<IJobStorer>(_ =>
        {
            // ������������ʱ�ڴ���ҵ�洢ʵ��
            return new RuntimeJobStorer();
        });

        // ע����ҵ����
        services.AddSingleton<ISchedulerFactory, SchedulerFactory>();

        // ע����ҵ������
        services.AddSingleton<IScheduler, Scheduler>();

        return services;
    }
}