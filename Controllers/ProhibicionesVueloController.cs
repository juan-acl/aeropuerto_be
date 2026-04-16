using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProhibicionesVueloController : ControllerBase
    {
        private readonly IProhibicionesVueloService _service;

        public ProhibicionesVueloController(IProhibicionesVueloService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProhibicionesVueloModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Prohibición de vuelo registrada exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("verificar/{idPasajero}")]
        public async Task<IActionResult> Verify(int idPasajero)
        {
            bool estaProhibido = await _service.EsPasajeroProhibido(idPasajero);
            return Ok(new { idPasajero, estaProhibido });
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> GetByPasajero(int idPasajero)
        {
            var result = await _service.ListarPorPasajero(idPasajero);
            return Ok(result);
        }

        [HttpPatch("desactivar/{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _service.DesactivarProhibicion(id);
            return Ok(new { mensaje = "La prohibición ha sido desactivada manualmente." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro eliminado físicamente." });
        }
    }
}