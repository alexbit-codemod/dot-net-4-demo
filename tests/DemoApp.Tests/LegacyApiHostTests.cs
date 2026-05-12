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
        var response = await server.CreateClient().GetAsync("/api/orders/1");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("demo-app", body);
    }
}
