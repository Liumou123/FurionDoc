﻿using Furion.Options;

namespace Furion;

/// <summary>
/// App 全局应用对象配置
/// </summary>
[AppOptions("AppSettings")]
public sealed class AppSettingsOptions : IAppOptions<AppSettingsOptions>
{
    /// <summary>
    /// 后期配置
    /// </summary>
    /// <param name="options"></param>
    void IAppOptions<AppSettingsOptions>.PostConfigure(AppSettingsOptions options)
    {
    }
}