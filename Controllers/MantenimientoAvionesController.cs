using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MantenimientoAvionesController : ControllerBase
    {
        private readonly IMantenimientoAvionService _mantenimientoService;

        public MantenimientoAvionesController(IMantenimientoAvionService mantenimientoService)
        {
            _mantenimientoService = mantenimientoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mantenimientos = await _mantenimientoService.GetMantenimientosAsync();
            return Ok(mantenimientos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mantenimiento = await _mantenimientoService.GetMantenimientoByIdAsync(id);
            if (mantenimiento == null)
            {
                return NotFound();
            }
            return Ok(mantenimiento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MantenimientoAvionModel mantenimiento)
        {
            if (mantenimiento == null)
            {
                return BadRequest();
            }
            var created = await _mantenimientoService.AddMantenimientoAsync(mantenimiento);
            return CreatedAtAction(nameof(GetById), new { id = created.IdMantenimiento }, created);
        }
    }
}
