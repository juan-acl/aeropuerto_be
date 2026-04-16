using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenDetalleController : ControllerBase
    {
        private readonly IOrdenDetalleService _service;
        public OrdenDetalleController(IOrdenDetalleService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ListarTodo());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrdenDetalle m) => Ok(await _service.Insertar(m));
    }
}