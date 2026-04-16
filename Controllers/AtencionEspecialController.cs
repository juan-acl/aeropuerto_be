using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtencionEspecialController : ControllerBase
    {
        private readonly IAtencionEspecialService _service;

        public AtencionEspecialController(IAtencionEspecialService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AtencionEspecialModel modelo)
        {
            try
            {
                int idGenerado = await _service.SolicitarAtencion(modelo);
                return Ok(new
                {
                    mensaje = "Solicitud de atención especial registrada. Nuestro equipo estará esperándole.",
                    idAtencion = idGenerado
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al solicitar asistencia: {ex.Message}");
            }
        }

        public class AsignarDto
        {
            public string NombreAsistente { get; set; } = null!;
        }

        [HttpPatch("{id}/asignar")]
        public async Task<IActionResult> PatchAsignar(int id, [FromBody] AsignarDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NombreAsistente))
                return BadRequest("Debe proporcionar el nombre del asistente.");

            await _service.AsignarAsistente(id, dto.NombreAsistente);
            return Ok(new { mensaje = $"Asistente {dto.NombreAsistente} despachado(a) para atender la solicitud." });
        }

        public class FinalizarDto
        {
            public string? Observaciones { get; set; }
        }

        [HttpPatch("{id}/finalizar")]
        public async Task<IActionResult> PatchFinalizar(int id, [FromBody] FinalizarDto dto)
        {
            await _service.FinalizarAtencion(id, dto.Observaciones);
            return Ok(new { mensaje = "Atención especial completada y bitácora actualizada." });
        }

        [HttpGet("pendientes")]
        public async Task<IActionResult> GetPendientes()
        {
            var result = await _service.ListarPendientes();
            return Ok(result);
        }

        [HttpGet("reserva/{idReserva}")]
        public async Task<IActionResult> GetByReserva(int idReserva)
        {
            var result = await _service.ListarPorReserva(idReserva);
            return Ok(result);
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de atención especial eliminado." });
        }
    }
}