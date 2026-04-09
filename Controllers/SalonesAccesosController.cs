using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalonesAccesosController : ControllerBase
    {
        private readonly ISalonesAccesosService _service;

        public SalonesAccesosController(ISalonesAccesosService service) => _service = service;

        [HttpPost("entrada")]
        public async Task<IActionResult> PostEntrada([FromBody] SalonesAccesosModel modelo)
        {
            try
            {
                int idGenerado = await _service.RegistrarEntrada(modelo);
                return Ok(new
                {
                    mensaje = "Acceso al salón VIP registrado.",
                    idAcceso = idGenerado
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPatch("{id}/salida")]
        public async Task<IActionResult> PatchSalida(int id)
        {
            var exito = await _service.RegistrarSalida(id);
            if (!exito)
                return BadRequest("No se pudo registrar la salida. Verifique que el acceso exista y no haya sido cerrado previamente.");

            return Ok(new { mensaje = "Hora de salida registrada correctamente." });
        }

        [HttpGet("salon/{idSalon}/activos")]
        public async Task<IActionResult> GetActivos(int idSalon)
        {
            var result = await _service.ListarAccesosActivos(idSalon);
            return Ok(result);
        }

        [HttpGet("salon/{idSalon}/historial")]
        public async Task<IActionResult> GetHistorial(int idSalon, [FromQuery] DateTime fecha)
        {
            // Ejemplo de uso: GET /api/SalonesAccesos/salon/1/historial?fecha=2023-10-25
            var result = await _service.ListarHistorialPorSalon(idSalon, fecha);
            return Ok(result);
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de acceso eliminado." });
        }
    }
}