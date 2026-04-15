using Microsoft.AspNetCore.Mvc;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "Backend funcionando", database = "Oracle Ready" });
        }
    }
}