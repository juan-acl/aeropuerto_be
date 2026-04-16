using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalonesVipController : ControllerBase
    {
        private readonly ISalonesVipService _service;

        public SalonesVipController(ISalonesVipService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SalonesVipModel modelo)
        {
            try
            {
                await _service.RegistrarSalon(modelo);
                return Ok(new { mensaje = "Salón VIP registrado exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("aeropuerto/{codigo}")]
        public async Task<IActionResult> GetAllByAeropuerto(string codigo)
        {
            var result = await _service.ListarPorAeropuerto(codigo);
            return Ok(result);
        }

        [HttpGet("aeropuerto/{codigo}/activos")]
        public async Task<IActionResult> GetActivos(string codigo)
        {
            var result = await _service.ListarActivos(codigo);
            return Ok(result);
        }

        [HttpPatch("{id}/capacidad")]
        public async Task<IActionResult> PatchCapacidad(int id, [FromBody] int nuevaCapacidad)
        {
            if (nuevaCapacidad <= 0)
                return BadRequest("La capacidad debe ser mayor a cero.");

            await _service.ActualizarCapacidad(id, nuevaCapacidad);
            return Ok(new { mensaje = "Capacidad del salón actualizada." });
        }

        [HttpPatch("{id}/desactivar")]
        public async Task<IActionResult> PatchDesactivar(int id)
        {
            await _service.DesactivarSalon(id);
            return Ok(new { mensaje = "Salón VIP desactivado (Soft Delete)." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Salón VIP eliminado físicamente." });
        }
    }
}