using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GruposViajeController : ControllerBase
    {
        private readonly IGruposViajeService _service;

        public GruposViajeController(IGruposViajeService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GruposViajeModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Grupo de viaje creado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grupos = await _service.ListarTodos();
            return Ok(grupos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var grupo = await _service.ObtenerPorId(id);
            if (grupo == null) return NotFound("Grupo no encontrado.");
            return Ok(grupo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GruposViajeModel modelo)
        {
            await _service.Actualizar(id, modelo);
            return Ok(new { mensaje = "Información del grupo actualizada." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Grupo eliminado permanentemente." });
        }
    }
}