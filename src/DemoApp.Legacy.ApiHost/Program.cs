using System;
using System.Configuration;
using Microsoft.Owin.Hosting;
using DemoApp.Abstractions;
using DemoApp.Legacy.ClassicLib;
using DemoApp.Shared;

namespace DemoApp.Legacy.ApiHost;

internal static class Program
{
    private static void Main()
    {
        _ = BinaryFormatterProbe.SerializeInt(0);

        var apiUrl = ConfigurationManager.AppSettings["ApiUrl"] ?? "";
        Console.WriteLine("Demo App — ApiUrl from App.config: {0}", apiUrl);
        Console.WriteLine("Demo App — shared JSON sample: {0}", OrderJson.Serialize(new OrderDto { Id = 42, Name = "demo" }));

        var baseUrl = ConfigurationManager.AppSettings["SelfHostBaseUrl"] ?? "http://localhost:8088/";
        using (WebApp.Start<Startup>(baseUrl))
        {
            Console.WriteLine("Demo App — Web API (OWIN) at {0}", baseUrl.TrimEnd('/'));
            Console.WriteLine("Example: GET {0}/api/orders/1", baseUrl.TrimEnd('/'));
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
