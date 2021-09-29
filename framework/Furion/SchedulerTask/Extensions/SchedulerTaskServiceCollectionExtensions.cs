// Copyright (c) 2020-2021 ��Сɮ, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.SchedulerTask;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// SchedulerTask ģ�������չ
/// </summary>
public static class SchedulerTaskServiceCollectionExtensions
{
    /// <summary>
    /// ��� SchedulerTask ģ��ע��
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <returns>���񼯺�ʵ��</returns>
    public static IServiceCollection AddSchedulerTask(this IServiceCollection services)
    {
        return services.AddHostedService<SchedulerTaskHostedService>();
    }

    /// <summary>
    /// ��� SchedulerTask ģ��ע��
    /// </summary>
    /// <param name="services">���񼯺϶���</param>
    /// <param name="unobservedTaskExceptionHandler">δ��������쳣�¼��������</param>
    /// <returns>���񼯺�ʵ��</returns>
    public static IServiceCollection AddScheduler(this IServiceCollection services, EventHandler<UnobservedTaskExceptionEventArgs> unobservedTaskExceptionHandler)
    {
        // ͨ������ģʽ����
        return services.AddHostedService(serviceProvider =>
        {
            // �����������
            var schedulerTaskHostedService = ActivatorUtilities.CreateInstance<SchedulerTaskHostedService>(serviceProvider);

            // ����δ��������쳣�¼�
            schedulerTaskHostedService.UnobservedTaskException += unobservedTaskExceptionHandler;

            return schedulerTaskHostedService;
        });
    }
}