﻿namespace Furion.Options;

/// <summary>
/// 选项配置特性
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class AppOptionsAttribute : Attribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public AppOptionsAttribute()
    {
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="sectionKey">配置节点 Key</param>
    public AppOptionsAttribute(string sectionKey)
    {
        SectionKey = sectionKey;
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="sectionKey">配置节点 Key</param>
    /// <param name="validateOptionsTypes">复杂验证类型</param>
    public AppOptionsAttribute(string sectionKey, params Type[] validateOptionsTypes)
    {
        SectionKey = sectionKey;
        ValidateOptionsTypes = validateOptionsTypes;
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="validateOptionsTypes">复杂验证类型</param>
    public AppOptionsAttribute(params Type[] validateOptionsTypes)
    {
        ValidateOptionsTypes = validateOptionsTypes;
    }

    /// <summary>
    /// 配置节点 Key
    /// </summary>
    public string? SectionKey { get; set; }

    /// <summary>
    /// 复杂验证类型
    /// </summary>
    public Type[]? ValidateOptionsTypes { get; set; }

    /// <summary>
    /// 存在未知配置节点抛异常
    /// </summary>
    public bool ErrorOnUnknownConfiguration { get; set; } = false;

    /// <summary>
    /// 绑定非公开属性
    /// </summary>
    public bool BindNonPublicProperties { get; set; } = false;

    /// <summary>
    /// 启动数据校验
    /// </summary>
    public bool ValidateDataAnnotations { get; set; } = true;
}