using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasPagosController : ControllerBase
    {
        private readonly IReservasPagosService _service;

        public ReservasPagosController(IReservasPagosService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservasPagosModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Pago registrado correctamente." });
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

        [HttpPatch("{id}/estado")]
        public async Task<IActionResult> PatchEstado(int id, [FromBody] string nuevoEstado)
        {
            await _service.ActualizarEstado(id, nuevoEstado);
            return Ok(new { mensaje = "Estado de pago actualizado." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de pago eliminado físicamente." });
        }
    }
}