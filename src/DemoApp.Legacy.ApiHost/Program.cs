using System;
using System.Configuration;

using DemoApp.Abstractions;
using DemoApp.Legacy.ClassicLib;
using DemoApp.Shared;
using Microsoft.Extensions.Configuration;

namespace DemoApp.Legacy.ApiHost;

internal static class Program
{
    // TODO(dotnet-appconfig-to-appsettings): inject IConfiguration; "ApiUrl" now lives in appsettings.json
    private static void Main()
    {
        _ = BinaryFormatterProbe.SerializeInt(0);

        var apiUrl = configuration["ApiUrl"] ?? "";
        Console.WriteLine("Demo App — ApiUrl from App.config: {0}", apiUrl);
        Console.WriteLine("Demo App — shared JSON sample: {0}", OrderJson.Serialize(new OrderDto { Id = 42, Name = "demo" }));

        var baseUrl = configuration["SelfHostBaseUrl"] ?? "http://localhost:8088/";
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddControllers();
        var app = builder.Build();
        app.MapControllers();
        app.Urls.Add(baseUrl);
        app.Run();
    }
}
