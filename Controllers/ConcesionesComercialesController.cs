using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcesionesComercialesController : ControllerBase
    {
        private readonly IConcesionesComercialesService _service;

        public ConcesionesComercialesController(IConcesionesComercialesService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConcesionesComercialesModel modelo)
        {
            try
            {
                await _service.RegistrarConcesion(modelo);
                return Ok(new { mensaje = "Concesión comercial registrada con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("aeropuerto/{codigo}")]
        public async Task<IActionResult> GetAllByAero(string codigo)
        {
            var result = await _service.ListarPorAeropuerto(codigo);
            return Ok(result);
        }

        [HttpGet("aeropuerto/{codigo}/activas")]
        public async Task<IActionResult> GetActivas(string codigo)
        {
            var result = await _service.ListarActivas(codigo);
            return Ok(result);
        }

        public class RenovarContratoDto
        {
            public DateTime NuevaFechaFin { get; set; }
            public decimal NuevoCanon { get; set; }
        }

        [HttpPatch("{id}/renovar")]
        public async Task<IActionResult> PatchRenovar(int id, [FromBody] RenovarContratoDto dto)
        {
            await _service.RenovarContrato(id, dto.NuevaFechaFin, dto.NuevoCanon);
            return Ok(new { mensaje = "Contrato de concesión renovado." });
        }

        [HttpPatch("{id}/desactivar")]
        public async Task<IActionResult> PatchDesactivar(int id)
        {
            await _service.DesactivarConcesion(id);
            return Ok(new { mensaje = "Concesión marcada como inactiva (Soft Delete)." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro comercial eliminado." });
        }
    }
}