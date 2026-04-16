using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitasSeguridadController : ControllerBase
    {
        private readonly IVisitasSeguridadService _service;

        public VisitasSeguridadController(IVisitasSeguridadService service) => _service = service;

        [HttpPost("ingreso")]
        public async Task<IActionResult> PostIngreso([FromBody] VisitasSeguridadModel modelo)
        {
            try
            {
                await _service.RegistrarIngreso(modelo);
                return Ok(new { mensaje = "Ingreso de visitante registrado exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("aeropuerto/{codigo}")]
        public async Task<IActionResult> GetByAero(string codigo)
        {
            var result = await _service.ListarPorAeropuerto(codigo);
            return Ok(result);
        }

        [HttpGet("aeropuerto/{codigo}/activos")]
        public async Task<IActionResult> GetActivos(string codigo)
        {
            var result = await _service.ListarVisitantesActivos(codigo);
            return Ok(result);
        }

        [HttpPatch("{id}/salida")]
        public async Task<IActionResult> PatchSalida(int id)
        {
            await _service.RegistrarSalida(id);
            return Ok(new { mensaje = "Salida de visitante registrada." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de visita eliminado." });
        }
    }
}