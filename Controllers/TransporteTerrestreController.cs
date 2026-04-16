using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransporteTerrestreController : ControllerBase
    {
        private readonly ITransporteTerrestreService _service;

        public TransporteTerrestreController(ITransporteTerrestreService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransporteTerrestreModel modelo)
        {
            try
            {
                await _service.RegistrarTransporte(modelo);
                return Ok(new { mensaje = "Opción de transporte terrestre registrada correctamente." });
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
        public async Task<IActionResult> GetActivos(string codigo, [FromQuery] string? tipo)
        {
            // Ejemplo 1: GET /api/TransporteTerrestre/aeropuerto/GUA/activos
            // Ejemplo 2: GET /api/TransporteTerrestre/aeropuerto/GUA/activos?tipo=RENTA_AUTO
            var result = await _service.ListarActivos(codigo, tipo);
            return Ok(result);
        }

        [HttpPatch("{id}/desactivar")]
        public async Task<IActionResult> PatchDesactivar(int id)
        {
            await _service.DesactivarTransporte(id);
            return Ok(new { mensaje = "Proveedor de transporte desactivado." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de transporte eliminado físicamente." });
        }
    }
}