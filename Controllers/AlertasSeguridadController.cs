using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertasSeguridadController : ControllerBase
    {
        private readonly IAlertasSeguridadService _service;

        public AlertasSeguridadController(IAlertasSeguridadService service) => _service = service;

        [HttpPost("emitir")]
        public async Task<IActionResult> Post([FromBody] AlertasSeguridadModel modelo)
        {
            try
            {
                await _service.EmitirAlerta(modelo);
                return Ok(new { mensaje = $"Alerta {modelo.NivelAlerta} emitida exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("aeropuerto/{codigo}/historial")]
        public async Task<IActionResult> GetHistorial(string codigo)
        {
            var result = await _service.ListarHistorial(codigo);
            return Ok(result);
        }

        [HttpGet("aeropuerto/{codigo}/activa")]
        public async Task<IActionResult> GetActiva(string codigo)
        {
            var result = await _service.ObtenerAlertaActiva(codigo);
            if (result == null) return Ok(new { mensaje = "No hay alertas de seguridad activas en este momento." });
            return Ok(result);
        }

        [HttpPatch("{id}/desactivar")]
        public async Task<IActionResult> PatchDesactivar(int id)
        {
            await _service.DesactivarAlerta(id);
            return Ok(new { mensaje = "Alerta de seguridad desactivada. Nivel restablecido." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de alerta eliminado del historial." });
        }
    }
}