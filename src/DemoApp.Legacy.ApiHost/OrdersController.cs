using Microsoft.AspNetCore.Mvc;
namespace DemoApp.Legacy.ApiHost;

public sealed class OrdersController : ControllerBase
{
    [HttpGet]
    [Route("api/orders/{id:int}")]
    public IActionResult Get(int id)
    {
        if (id <= 0)
            return BadRequest();
        return Ok(new { id, source = "demo-app" });
    }
}
