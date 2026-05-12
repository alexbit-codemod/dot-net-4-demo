using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using DemoApp.Legacy.ApiHost;
using Xunit;

namespace DemoApp.Tests;

public sealed class LegacyApiHostTests
{
    [Fact]
    public async Task Orders_get_returns_legacy_payload()
    {
        using var server = TestServer.Create<Startup>();
        var response = await server.HttpClient.GetAsync("/api/orders/1");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("demo-app", body);
    }
}
