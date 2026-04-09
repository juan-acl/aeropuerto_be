using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentesController : ControllerBase
    {
        private readonly IIncidentesService _service;

        public IncidentesController(IIncidentesService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncidentesModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Incidente reportado y registrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? gravedad, [FromQuery] string? estado)
        {
            var result = await _service.ListarPorFiltro(gravedad, estado);
            return Ok(result);
        }

        [HttpPut("{id}/resolver")]
        public async Task<IActionResult> Resolve(int id, [FromBody] string resolucion)
        {
            await _service.ResolverIncidente(id, resolucion);
            return Ok(new { mensaje = "Incidente marcado como resuelto." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro eliminado del sistema de seguridad." });
        }
    }
}