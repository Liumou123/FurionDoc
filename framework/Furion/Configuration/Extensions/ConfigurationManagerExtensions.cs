﻿using Furion;
using System.Diagnostics;

namespace Microsoft.Extensions.Configuration;

/// <summary>
/// 配置主机构建器拓展类
/// </summary>
public static class ConfigurationManagerExtensions
{
    /// <summary>
    /// 添加应用配置
    /// </summary>
    /// <remarks>包含自动扫描、环境配置</remarks>
    /// <param name="configurationManager">配置管理对象</param>
    /// <returns></returns>
    public static ConfigurationManager AddAppConfiguration(this ConfigurationManager configurationManager)
    {
        var configuration = configurationManager as IConfiguration;
        var configurationBuilder = configurationManager as IConfigurationBuilder;

        // 添加 Furion 框架环境变量配置支持
        configurationBuilder.AddEnvironmentVariables(prefix: configuration[$"{AppSettingsOptions._sectionKey}:{nameof(AppSettingsOptions.EnvironmentVariablesPrefix)}"] ?? AppSettingsOptions._environmentVariablesPrefix);

        Trace.WriteLine(string.Join(";\n", configuration.AsEnumerable().Select(c => $"{c.Key}={c.Value}")));

        return configurationManager;
    }
}