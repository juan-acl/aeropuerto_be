using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IReservasService _service;

        public ReservasController(IReservasService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservasModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Reserva creada exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> GetByPasajero(int idPasajero)
        {
            var result = await _service.ListarPorPasajero(idPasajero);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ReservasModel modelo)
        {
            try
            {
                await _service.Actualizar(id, modelo);
                return Ok(new { mensaje = "Reserva actualizada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.EliminarFisico(id);
                return Ok(new { mensaje = "Reserva eliminada permanentemente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}