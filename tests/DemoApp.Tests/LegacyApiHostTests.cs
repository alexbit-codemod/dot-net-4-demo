using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using DemoApp.Legacy.ApiHost;
using Xunit;

namespace DemoApp.Tests;

public sealed class LegacyApiHostTests
{
    [Fact]
    public async Task Orders_get_returns_legacy_payload()
    {
        using var server = new WebApplicationFactory<Program>();
        var client = server.CreateClient();
        var response = await client.GetAsync("/api/orders/1");
        var body = await response.Content.ReadAsStringAsync();
        Assert.True(
            response.StatusCode == HttpStatusCode.OK,
            $"Expected 200 OK but got {(int)response.StatusCode} {response.StatusCode}. BaseAddress={client.BaseAddress}. Body={body}"
        );
        Assert.Contains("demo-app", body);
    }
}
