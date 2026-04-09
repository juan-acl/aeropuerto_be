using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasajerosHistorialMedicoController : ControllerBase
    {
        private readonly IPasajeroHistorialMedicoService _service;

        public PasajerosHistorialMedicoController(IPasajeroHistorialMedicoService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] PasajeroHistorialMedicoModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Historial médico registrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> GetByPasajero(int idPasajero)
        {
            var historial = await _service.ObtenerPorPasajero(idPasajero);
            if (historial == null) return NotFound("No existe historial para este pasajero.");
            return Ok(historial);
        }

        /// <summary>
        /// Elimina permanentemente el historial médico.
        /// </summary>
        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> DeleteFisico(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Historial médico eliminado permanentemente." });
        }
    }
}