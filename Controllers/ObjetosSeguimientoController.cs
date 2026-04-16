using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjetosSeguimientoController : ControllerBase
    {
        private readonly IObjetosSeguimientoService _service;

        public ObjetosSeguimientoController(IObjetosSeguimientoService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ObjetosSeguimientoModel modelo)
        {
            try
            {
                await _service.RegistrarMovimiento(modelo);
                return Ok(new { mensaje = "Movimiento del objeto registrado con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("objeto/{idObjeto}")]
        public async Task<IActionResult> GetByObjeto(int idObjeto)
        {
            var result = await _service.ListarHistorialPorObjeto(idObjeto);
            return Ok(result);
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de seguimiento eliminado." });
        }
    }
}