using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasajerosPreferenciasController : ControllerBase
    {
        private readonly IPasajeroPreferenciaService _service;

        public PasajerosPreferenciasController(IPasajeroPreferenciaService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] PasajeroPreferenciaModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Preferencia guardada con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> GetByPasajero(int idPasajero)
        {
            var prefs = await _service.ListarPorPasajero(idPasajero);
            return Ok(prefs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] string descripcion)
        {
            await _service.ActualizarPreferencia(id, descripcion);
            return Ok(new { mensaje = "Preferencia actualizada." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarLogico(id);
            return Ok(new { mensaje = "Preferencia desactivada." });
        }
    }
}