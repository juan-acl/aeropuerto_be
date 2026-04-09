using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendasVentasController : ControllerBase
    {
        private readonly ITiendasVentasService _service;

        public TiendasVentasController(ITiendasVentasService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TiendasVentasModel modelo)
        {
            try
            {
                int idVentaGenerado = await _service.RegistrarVentaCabecera(modelo);
                // Devolvemos el ID porque el frontend lo necesitará inmediatamente para registrar el detalle
                return Ok(new
                {
                    mensaje = "Cabecera de venta registrada exitosamente.",
                    idVenta = idVentaGenerado
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("concesion/{idConcesion}")]
        public async Task<IActionResult> GetByConcesion(int idConcesion)
        {
            var result = await _service.ListarPorConcesion(idConcesion);
            return Ok(result);
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> GetByPasajero(int idPasajero)
        {
            var result = await _service.ListarPorPasajero(idPasajero);
            return Ok(result);
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de venta eliminado." });
        }
    }
}