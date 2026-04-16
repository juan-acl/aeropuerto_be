using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturasService _service;

        public FacturasController(IFacturasService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FacturasModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Factura generada y guardada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("reserva/{idReserva}")]
        public async Task<IActionResult> GetByReserva(int idReserva)
        {
            var factura = await _service.ObtenerPorReserva(idReserva);
            if (factura == null) return NotFound("No se encontró factura para esta reserva.");
            return Ok(factura);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FacturasModel modelo)
        {
            await _service.Actualizar(id, modelo);
            return Ok(new { mensaje = "Datos de la factura actualizados." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Factura eliminada del sistema." });
        }
    }
}