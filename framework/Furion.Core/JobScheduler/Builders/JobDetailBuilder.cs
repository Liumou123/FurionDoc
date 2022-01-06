﻿// Copyright (c) 2020-2022 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

namespace Furion.JobScheduler;

/// <summary>
/// 作业详情构建器
/// </summary>
public sealed class JobDetailBuilder
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="jobId">作业 Id</param>
    /// <param name="jobType">作业类型</param>
    internal JobDetailBuilder(string jobId, Type jobType)
    {
        // 空检查
        if (string.IsNullOrWhiteSpace(jobId))
        {
            throw new ArgumentNullException(nameof(jobId));
        }

        JobId = jobId;
        JobTypeWithAssembly = $"{jobType.Assembly.GetName().Name};{jobType.FullName}";
    }

    /// <summary>
    /// 作业 Id
    /// </summary>
    public string JobId { get; }

    /// <summary>
    /// 作业类型名（含程序集名）
    /// </summary>
    /// <remarks>格式：程序集名;命名空间.类型名，如：Furion;Furion.Jobs.MyJob</remarks>
    public string JobTypeWithAssembly { get; }

    /// <summary>
    /// 作业描述
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 作业状态
    /// </summary>
    public JobStatus Status { get; set; } = JobStatus.Normal;

    /// <summary>
    /// 作业执行方式
    /// </summary>
    public JobMode Mode { get; set; } = JobMode.Parallel;

    /// <summary>
    /// 记录详细日志
    /// </summary>
    public bool WithExecutionLog { get; set; } = false;

    /// <summary>
    /// 构建作业详情
    /// </summary>
    /// <returns><see cref="JobDetail"/></returns>
    internal JobDetail Build()
    {
        // 创建作业详情对象
        var jobDetail = new JobDetail(JobId);

        // 初始化作业详情参数
        jobDetail!.Description = Description;
        jobDetail!.Status = Status;
        jobDetail!.Mode = Mode;
        jobDetail!.WithExecutionLog = WithExecutionLog;
        jobDetail!.JobTypeWithAssembly = JobTypeWithAssembly;

        return jobDetail;
    }
}