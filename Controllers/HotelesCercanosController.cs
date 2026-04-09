using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelesCercanosController : ControllerBase
    {
        private readonly IHotelesCercanosService _service;

        public HotelesCercanosController(IHotelesCercanosService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HotelesCercanosModel modelo)
        {
            try
            {
                await _service.RegistrarHotel(modelo);
                return Ok(new { mensaje = "Hotel cercano registrado en el directorio." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("aeropuerto/{codigo}")]
        public async Task<IActionResult> GetAllByAeropuerto(string codigo)
        {
            var result = await _service.ListarPorAeropuerto(codigo);
            return Ok(result);
        }

        [HttpGet("aeropuerto/{codigo}/activos")]
        public async Task<IActionResult> GetActivos(string codigo, [FromQuery] bool? soloConShuttle)
        {
            // Ejemplo 1: GET /api/HotelesCercanos/aeropuerto/GUA/activos
            // Ejemplo 2: GET /api/HotelesCercanos/aeropuerto/GUA/activos?soloConShuttle=true
            var result = await _service.ListarActivos(codigo, soloConShuttle);
            return Ok(result);
        }

        [HttpPatch("{id}/desactivar")]
        public async Task<IActionResult> PatchDesactivar(int id)
        {
            await _service.DesactivarHotel(id);
            return Ok(new { mensaje = "Hotel desactivado del directorio público." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de hotel eliminado físicamente." });
        }
    }
}