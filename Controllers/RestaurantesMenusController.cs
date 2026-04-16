using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantesMenusController : ControllerBase
    {
        private readonly IRestaurantesMenusService _service;

        public RestaurantesMenusController(IRestaurantesMenusService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RestaurantesMenusModel modelo)
        {
            try
            {
                await _service.RegistrarPlato(modelo);
                return Ok(new { mensaje = "Plato registrado en el menú exitosamente." });
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

        [HttpGet("concesion/{idConcesion}/disponibles")]
        public async Task<IActionResult> GetDisponibles(int idConcesion)
        {
            var result = await _service.ListarDisponiblesPorConcesion(idConcesion);
            return Ok(result);
        }

        [HttpPatch("{id}/disponibilidad")]
        public async Task<IActionResult> PatchDisponibilidad(int id, [FromBody] int disponible)
        {
            if (disponible != 0 && disponible != 1)
                return BadRequest("El valor de disponibilidad debe ser 0 o 1.");

            await _service.CambiarDisponibilidad(id, disponible);
            return Ok(new { mensaje = disponible == 1 ? "Plato marcado como disponible." : "Plato marcado como agotado." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Plato eliminado del menú." });
        }
    }
}