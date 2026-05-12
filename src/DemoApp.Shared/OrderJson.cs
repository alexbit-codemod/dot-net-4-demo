using DemoApp.Abstractions;
using Newtonsoft.Json;

namespace DemoApp.Shared;

public static class OrderJson
{
    public static string Serialize(OrderDto order)
    {
        return JsonConvert.SerializeObject(order);
    }
}
