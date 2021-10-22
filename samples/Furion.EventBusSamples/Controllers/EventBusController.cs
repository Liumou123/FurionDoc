﻿using Furion.EventBus;
using Microsoft.AspNetCore.Mvc;

namespace Furion.EventBusSamples.Controllers;

/// <summary>
/// EventBus 模块测试
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public class EventBusController : ControllerBase
{
    private readonly IEventPublisher _eventPublisher;
    public EventBusController(IEventPublisher eventPublisher)
    {
        _eventPublisher = eventPublisher;
    }

    /// <summary>
    /// 发送创建用户消息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task SendCreateUser()
    {
        await _eventPublisher.PublishAsync(new EventSource("User:Create", new
        {
            Name = "Furion"
        }));
    }

    /// <summary>
    /// 发送更新用户消息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task SendUpdateUser()
    {
        await _eventPublisher.PublishAsync(new EventSource("User:Update", new
        {
            Id = 2,
            Name = "先知"
        }));
    }

    /// <summary>
    /// 发送删除用户消息（抛异常）
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task SendDeleteUser()
    {
        await _eventPublisher.PublishAsync(new EventSource("User:Delete", new
        {
            Id = 2,
            Name = "先知"
        }));
    }

    /// <summary>
    /// 发送不存在消息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task SendUnknownEvent()
    {
        await _eventPublisher.PublishAsync(new EventSource("User:NotExist"));
    }
}