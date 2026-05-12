using Owin;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Legacy.ApiHost;

public sealed class Startup
{
    public void Configuration(IAppBuilder app)
    {
        var config = new HttpConfiguration();
        config.MapHttpAttributeRoutes();
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional });
        app.UseWebApi(config);
    }
}
