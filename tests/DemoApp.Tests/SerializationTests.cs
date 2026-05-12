using DemoApp.Abstractions;
using DemoApp.Shared;
using Xunit;

namespace DemoApp.Tests;

public sealed class SerializationTests
{
    [Fact]
    public void OrderJson_includes_fields()
    {
        var json = OrderJson.Serialize(new OrderDto { Id = 7, Name = "Contoso" });
        Assert.Contains("7", json);
        Assert.Contains("Contoso", json);
    }
}
