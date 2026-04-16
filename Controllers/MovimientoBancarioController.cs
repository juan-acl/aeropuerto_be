using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoBancarioController : ControllerBase
    {
        private readonly IMovimientoBancarioService _service;
        public MovimientoBancarioController(IMovimientoBancarioService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ListarTodo());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovimientoBancario m) => Ok(await _service.Insertar(m));
    }
}