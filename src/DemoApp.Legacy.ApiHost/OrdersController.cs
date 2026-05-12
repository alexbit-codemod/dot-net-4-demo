using System.Web.Http;

namespace DemoApp.Legacy.ApiHost;

public sealed class OrdersController : ApiController
{
    [HttpGet]
    [Route("api/orders/{id:int}")]
    public IHttpActionResult Get(int id)
    {
        if (id <= 0)
            return BadRequest();
        return Ok(new { id, source = "demo-app" });
    }
}
