using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManifiestoDetalleController : ControllerBase
    {
        private readonly IManifiestoDetalleService _service;
        public ManifiestoDetalleController(IManifiestoDetalleService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ListarTodo());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ManifiestoDetalle m) => Ok(await _service.Insertar(m));
    }
}