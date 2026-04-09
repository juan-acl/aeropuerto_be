using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReclamacionesObjetosController : ControllerBase
    {
        private readonly IReclamacionesObjetosService _service;

        public ReclamacionesObjetosController(IReclamacionesObjetosService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReclamacionesObjetosModel modelo)
        {
            try
            {
                await _service.RegistrarReclamacion(modelo);
                return Ok(new { mensaje = "Reclamación registrada y en estado PENDIENTE." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("pendientes")]
        public async Task<IActionResult> GetPendientes()
        {
            var result = await _service.ListarPendientes();
            return Ok(result);
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> GetByPasajero(int idPasajero)
        {
            var result = await _service.ListarPorPasajero(idPasajero);
            return Ok(result);
        }

        public class ResolverReclamacionDto
        {
            public string Estado { get; set; } = null!;
            public string Resolucion { get; set; } = null!;
            public string ResueltoPor { get; set; } = null!;
        }

        [HttpPatch("{id}/resolver")]
        public async Task<IActionResult> PatchResolver(int id, [FromBody] ResolverReclamacionDto dto)
        {
            if (dto.Estado != "APROBADA" && dto.Estado != "RECHAZADA")
                return BadRequest("El estado debe ser APROBADA o RECHAZADA.");

            await _service.ResolverReclamacion(id, dto.Estado, dto.Resolucion, dto.ResueltoPor);
            return Ok(new { mensaje = $"Reclamación marcada como {dto.Estado}." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro de reclamación eliminado." });
        }
    }
}