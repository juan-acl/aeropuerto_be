using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasesAbordajeController : ControllerBase
    {
        private readonly IPasesAbordajeService _service;

        public PasesAbordajeController(IPasesAbordajeService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PasesAbordajeModel modelo)
        {
            try
            {
                await _service.GenerarPase(modelo);
                return Ok(new { mensaje = "Pase de abordaje generado correctamente." });
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
            if (result == null) return NotFound("No se encontró pase de abordaje.");
            return Ok(result);
        }

        [HttpPatch("abordar/{id}")]
        public async Task<IActionResult> PatchBoard(int id)
        {
            await _service.RegistrarUso(id);
            return Ok(new { mensaje = "Abordaje registrado." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Pase eliminado físicamente." });
        }
    }
}