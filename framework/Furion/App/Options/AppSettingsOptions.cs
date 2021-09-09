﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

using Furion.Options;

namespace Furion;

/// <summary>
/// App 模块配置选项
/// </summary>
[AppOptions(sectionKey, ErrorOnUnknownConfiguration = true)]
public sealed class AppSettingsOptions : IAppOptions<AppSettingsOptions>
{
    /// <summary>
    /// 配置根节点名称
    /// </summary>
    internal const string sectionKey = "AppSettings";

    /// <summary>
    /// 环境配置提供程序节点变量前缀
    /// </summary>
    internal const string environmentVariablesPrefix = "FURION_";

    /// <summary>
    /// 环境配置提供程序节点变量前缀
    /// </summary>
    public string? EnvironmentVariablesPrefix { get; set; }

    /// <summary>
    /// 自定义配置文件
    /// </summary>
    /// <remarks>
    /// <para>*.json;*.xml;*.ini;</para>
    /// <para>null: 不配置(缺省值);</para>
    /// <para>@ 或 ~：入口目录(缺省值); / 或 !：绝对路径; <c>与符号</c> 或 .：执行目录(bin);</para>
    /// <para>参数：includeEnvironment; optional; reloadOnChange;</para>
    /// </remarks>
    public string[]? CustomizeConfigurationFiles { get; set; }

    /// <summary>
    /// 后期配置
    /// </summary>
    /// <param name="options">当前选项对象</param>
    void IAppOptions<AppSettingsOptions>.PostConfigure(AppSettingsOptions options)
    {
        options.EnvironmentVariablesPrefix ??= environmentVariablesPrefix;
    }
}