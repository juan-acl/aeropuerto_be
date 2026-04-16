using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendasProductosController : ControllerBase
    {
        private readonly ITiendasProductosService _service;

        public TiendasProductosController(ITiendasProductosService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TiendasProductosModel modelo)
        {
            try
            {
                await _service.RegistrarProducto(modelo);
                return Ok(new { mensaje = "Producto registrado en la concesión correctamente." });
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

        [HttpGet("concesion/{idConcesion}/alertas-stock")]
        public async Task<IActionResult> GetBajoStock(int idConcesion)
        {
            var result = await _service.ListarBajoStockMinimo(idConcesion);
            return Ok(result);
        }

        [HttpPatch("{id}/stock")]
        public async Task<IActionResult> PatchStock(int id, [FromBody] int nuevoStock)
        {
            if (nuevoStock < 0) return BadRequest("El stock no puede ser un valor negativo.");

            await _service.ActualizarStock(id, nuevoStock);
            return Ok(new { mensaje = "Inventario del producto actualizado." });
        }

        [HttpPatch("{id}/desactivar")]
        public async Task<IActionResult> PatchDesactivar(int id)
        {
            await _service.DesactivarProducto(id);
            return Ok(new { mensaje = "Producto descontinuado (Soft Delete)." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Producto eliminado físicamente del catálogo." });
        }
    }
}