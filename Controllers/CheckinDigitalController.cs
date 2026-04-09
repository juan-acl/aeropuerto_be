using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckinDigitalController : ControllerBase
    {
        private readonly ICheckinDigitalService _service;

        public CheckinDigitalController(ICheckinDigitalService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CheckinDigitalModel modelo)
        {
            try
            {
                await _service.RegistrarCheckin(modelo);
                return Ok(new { mensaje = "Check-in realizado con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("reserva/{idReserva}")]
        public async Task<IActionResult> Get(int idReserva)
        {
            var result = await _service.ObtenerPorReserva(idReserva);
            if (result == null) return NotFound("No se encontró registro de check-in.");
            return Ok(result);
        }

        [HttpPatch("{id}/notificar")]
        public async Task<IActionResult> PatchNotify(int id, [FromQuery] bool email, [FromQuery] bool sms)
        {
            await _service.ActualizarNotificaciones(id, email, sms);
            return Ok(new { mensaje = "Estado de notificación actualizado." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro eliminado físicamente." });
        }
    }
}