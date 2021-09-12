using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Furion.IntegrationTests;

/// <summary>
/// App ģ�鼯�ɲ���
/// </summary>
public class AppModuleIntegrationTests : IClassFixture<WebApplicationFactory<Furion.AppSamples.FakeStartup>>
{
    private readonly WebApplicationFactory<Furion.AppSamples.FakeStartup> _factory;
    public AppModuleIntegrationTests(WebApplicationFactory<Furion.AppSamples.FakeStartup> factory)
    {
        _factory = factory;
    }

    /// <summary>
    /// ���� App ģ��ʾ��������
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    [Theory]
    [InlineData("/api/IApp/GetConfiguration")]
    [InlineData("/api/IApp/GetEnvironmentInfo")]
    [InlineData("/api/IApp/GetServiceByHostServices")]
    [InlineData("/api/IApp/GetServiceByServiceProvider")]
    [InlineData("/api/IApp/GetService")]
    [InlineData("/api/IApp/GetRequiredService")]
    [InlineData("/api/AppSettingsOptions/GetAppSettings")]
    public async Task TestEnsureSuccessStatusCode(string url)
    {
        using var client = _factory.CreateClient();
        using var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
    }
}