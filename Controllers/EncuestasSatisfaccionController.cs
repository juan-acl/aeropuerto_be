using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncuestasSatisfaccionController : ControllerBase
    {
        private readonly IEncuestasSatisfaccionService _service;

        public EncuestasSatisfaccionController(IEncuestasSatisfaccionService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EncuestasSatisfaccionModel modelo)
        {
            // Validación manual rápida para asegurar que los valores estén en el rango de Oracle CHECK (1-5)
            if (modelo.PuntuacionGeneral is < 1 or > 5 ||
                modelo.PuntuacionCheckin is < 1 or > 5 ||
                modelo.PuntuacionAbordaje is < 1 or > 5)
            {
                return BadRequest("Todas las puntuaciones deben estar en un rango de 1 a 5.");
            }

            try
            {
                int idEncuesta = await _service.RegistrarEncuesta(modelo);
                return Ok(new
                {
                    mensaje = "¡Gracias por tus comentarios! Encuesta guardada exitosamente.",
                    idEncuesta = idEncuesta
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar encuesta: {ex.Message}");
            }
        }

        [HttpGet("vuelo/{idVuelo}")]
        public async Task<IActionResult> GetByVuelo(int idVuelo)
        {
            var result = await _service.ListarPorVuelo(idVuelo);
            return Ok(result);
        }

        [HttpGet("vuelo/{idVuelo}/estadisticas")]
        public async Task<IActionResult> GetEstadisticasByVuelo(int idVuelo)
        {
            var result = await _service.ObtenerEstadisticasPorVuelo(idVuelo);
            return Ok(result);
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Encuesta eliminada físicamente." });
        }
    }
}