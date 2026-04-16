using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasDetalleController : ControllerBase
    {
        private readonly IVentasDetalleService _service;

        public VentasDetalleController(IVentasDetalleService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VentasDetalleModel modelo)
        {
            try
            {
                await _service.RegistrarDetalle(modelo);
                return Ok(new { mensaje = "Línea de detalle agregada a la venta." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> PostBulk([FromBody] List<VentasDetalleModel> detalles)
        {
            try
            {
                await _service.RegistrarMultiplesDetalles(detalles);
                return Ok(new { mensaje = "Todos los detalles fueron registrados y el stock ha sido actualizado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al procesar el ticket: {ex.Message}");
            }
        }

        [HttpGet("venta/{idVenta}")]
        public async Task<IActionResult> GetByVenta(int idVenta)
        {
            var result = await _service.ListarPorVenta(idVenta);
            return Ok(result);
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Línea de detalle eliminada." });
        }
    }
}