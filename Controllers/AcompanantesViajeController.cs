using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcompanantesViajeController : ControllerBase
    {
        private readonly IAcompanantesViajeService _service;

        public AcompanantesViajeController(IAcompanantesViajeService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AcompanantesViajeModel modelo)
        {
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Acompañante registrado con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("principal/{idPasajeroPrincipal}")]
        public async Task<IActionResult> Get(int idPasajeroPrincipal)
        {
            var result = await _service.ListarPorPasajeroPrincipal(idPasajeroPrincipal);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AcompanantesViajeModel modelo)
        {
            try
            {
                await _service.Actualizar(id, modelo);
                return Ok(new { mensaje = "Datos del acompañante actualizados." });
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
                return Ok(new { mensaje = "Registro eliminado físicamente de la base de datos." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar: {ex.Message}");
            }
        }
    }
}