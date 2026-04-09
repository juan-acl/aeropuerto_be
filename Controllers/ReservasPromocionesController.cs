using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasPromocionesController : ControllerBase
    {
        private readonly IReservasPromocionesService _service;

        public ReservasPromocionesController(IReservasPromocionesService service) => _service = service;

        [HttpPost("aplicar")]
        public async Task<IActionResult> Aplicar([FromBody] ReservasPromocionesModel modelo)
        {
            try
            {
                await _service.AplicarPromocion(modelo);
                return Ok(new { mensaje = "Promoción aplicada a la reserva exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("reserva/{idReserva}")]
        public async Task<IActionResult> Get(int idReserva)
        {
            var result = await _service.ListarPorReserva(idReserva);
            return Ok(result);
        }

        [HttpDelete("quitar/{idReserva}/{idPromocion}")]
        public async Task<IActionResult> Delete(int idReserva, int idPromocion)
        {
            await _service.EliminarRelacion(idReserva, idPromocion);
            return Ok(new { mensaje = "Promoción removida de la reserva." });
        }
    }
}