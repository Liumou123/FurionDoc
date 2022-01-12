﻿// Copyright (c) 2020-2022 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using System.Reflection;

namespace Furion.Schedule;

/// <summary>
/// 作业信息构建器
/// </summary>
public sealed class JobDetailBuilder
{
    /// <summary>
    /// 构造函数
    /// </summary>
    internal JobDetailBuilder()
    {
    }

    /// <summary>
    /// 作业 Id
    /// </summary>
    public string? JobId { get; private set; }

    /// <summary>
    /// 作业类型完整限定名
    /// </summary>
    public string? JobType { get; private set; }

    /// <summary>
    /// 运行时作业类型
    /// </summary>
    internal Type? RuntimeJobType { get; private set; }

    /// <summary>
    /// 作业类型所在程序集名称
    /// </summary>
    public string? AssemblyName { get; private set; }

    /// <summary>
    /// 作业描述信息
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 作业状态
    /// </summary>
    public JobStatus Status { get; set; } = JobStatus.Normal;

    /// <summary>
    /// 作业启动方式
    /// </summary>
    public JobStartMode StartMode { get; set; } = JobStartMode.Run;

    /// <summary>
    /// 作业执行方式
    /// </summary>
    public JobExecutionMode ExecutionMode { get; set; } = JobExecutionMode.Parallel;

    /// <summary>
    /// 是否打印执行日志
    /// </summary>
    public bool WithExecutionLog { get; set; } = false;

    /// <summary>
    /// 是否创建新的服务作用域执行作业
    /// </summary>
    public bool WithScopeExecution { get; set; } = false;

    /// <summary>
    /// 配置作业 Id
    /// </summary>
    /// <param name="jobId">作业 Id</param>
    public void WithIdentity(string jobId)
    {
        // 空检查
        if (string.IsNullOrWhiteSpace(jobId))
        {
            throw new ArgumentNullException(nameof(jobId));
        }

        JobId = jobId;
    }

    /// <summary>
    /// 设置作业类型
    /// </summary>
    /// <typeparam name="TJob"><see cref="IJob"/> 实现类</typeparam>
    /// <returns><see cref="JobDetailBuilder"/></returns>
    public JobDetailBuilder SetJobType<TJob>()
        where TJob : class, IJob
    {
        return SetJobType(typeof(TJob));
    }

    /// <summary>
    /// 设置作业类型
    /// </summary>
    /// <param name="assembly">程序集全名</param>
    /// <param name="jobType">作业类型完整名称</param>
    /// <returns><see cref="JobDetailBuilder"/></returns>
    public JobDetailBuilder SetJobType(string assembly, string jobType)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(assembly);
        ArgumentNullException.ThrowIfNull(jobType);

        // 加载 GAC 全局缓存中的程序集
        var runtimeJobType = Assembly.Load(assembly).GetType(jobType);
        ArgumentNullException.ThrowIfNull(runtimeJobType);

        return SetJobType(runtimeJobType);
    }

    /// <summary>
    /// 设置作业类型
    /// </summary>
    /// <param name="jobType">作业类型</param>
    /// <returns><see cref="JobDetailBuilder"/></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public JobDetailBuilder SetJobType(Type jobType)
    {
        // 检查 jobType 类型是否实现 IJob 接口
        if (!typeof(IJob).IsAssignableFrom(jobType))
        {
            throw new InvalidOperationException("The <jobType> does not implement IJob interface.");
        }

        // 设置作业类型关联的属性初始值
        WithScopeExecution = jobType.IsDefined(typeof(ScopeExecutionAttribute), false);
        AssemblyName = jobType.Assembly.GetName().Name;
        JobType = jobType.FullName;
        RuntimeJobType = jobType;

        return this;
    }

    /// <summary>
    /// 将 JobDetail 信息转换成 JobDetailBuilder
    /// </summary>
    /// <param name="jobDetail"><see cref="JobDetail"/></param>
    internal void LoadTo(JobDetail jobDetail)
    {
        WithIdentity(jobDetail.JobId!);
        SetJobType(jobDetail.AssemblyName!, jobDetail.JobType!);
        Description = jobDetail.Description;
        Status = jobDetail.Status;
        StartMode = jobDetail.StartMode;
        ExecutionMode = jobDetail.ExecutionMode;
        WithExecutionLog = jobDetail.WithExecutionLog;
        WithScopeExecution = jobDetail.WithScopeExecution;
    }

    /// <summary>
    /// 构建作业信息对象
    /// </summary>
    /// <returns><see cref="JobDetail"/></returns>
    internal JobDetail Build()
    {
        // 创建作业信息对象
        var jobDetail = new JobDetail();

        // 初始化作业信息属性
        jobDetail!.JobId = string.IsNullOrWhiteSpace(JobId) ? $"job_{Guid.NewGuid():N}" : JobId;
        jobDetail!.JobType = JobType;
        jobDetail!.AssemblyName = AssemblyName;
        jobDetail!.Description = Description;
        jobDetail!.Status = StartMode == JobStartMode.Wait ? JobStatus.None : Status;    // 只要启动模式为 Wait（等待启动），那么作业状态都会是 None
        jobDetail!.StartMode = StartMode;
        jobDetail!.ExecutionMode = ExecutionMode;
        jobDetail!.WithExecutionLog = WithExecutionLog;
        jobDetail!.WithScopeExecution = WithScopeExecution;

        return jobDetail;
    }
}