using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromocionesController : ControllerBase
    {
        private readonly IPromocionesService _service;

        public PromocionesController(IPromocionesService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PromocionesModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Promoción creada correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var promociones = await _service.ListarTodas();
            return Ok(promociones);
        }

        [HttpGet("validar/{codigo}")]
        public async Task<IActionResult> Validate(string codigo)
        {
            var promo = await _service.ObtenerPorCodigo(codigo);
            if (promo == null) return NotFound("Código de promoción inválido o inactivo.");
            return Ok(promo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PromocionesModel modelo)
        {
            await _service.Actualizar(id, modelo);
            return Ok(new { mensaje = "Promoción actualizada." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Promoción eliminada físicamente." });
        }
    }
}