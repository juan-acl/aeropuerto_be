using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BotiquinesVueloController : ControllerBase
    {
        private readonly IBotiquinesVueloService _service;

        public BotiquinesVueloController(IBotiquinesVueloService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BotiquinesVueloModel modelo)
        {
            try
            {
                await _service.RegistrarVerificacion(modelo);
                return Ok(new { mensaje = "Verificación de botiquín registrada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("vuelo/{idVuelo}")]
        public async Task<IActionResult> GetByVuelo(int idVuelo)
        {
            var result = await _service.ListarPorVuelo(idVuelo);
            return Ok(result);
        }

        [HttpGet("vuelo/{idVuelo}/ultima")]
        public async Task<IActionResult> GetLatest(int idVuelo)
        {
            var result = await _service.ObtenerUltimaVerificacion(idVuelo);
            if (result == null) return NotFound("No hay registros de verificación para este vuelo.");
            return Ok(result);
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro eliminado físicamente." });
        }
    }
}