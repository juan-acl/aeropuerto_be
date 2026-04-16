using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionamientoController : ControllerBase
    {
        private readonly IEstacionamientoService _service;

        public EstacionamientoController(IEstacionamientoService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EstacionamientoModel modelo)
        {
            try
            {
                await _service.RegistrarEspacio(modelo);
                return Ok(new { mensaje = "Espacio de estacionamiento registrado correctamente." });
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

        [HttpGet("aeropuerto/{codigo}/disponibles")]
        public async Task<IActionResult> GetDisponibles(string codigo, [FromQuery] string tipo)
        {
            // Ejemplo: GET /api/Estacionamiento/aeropuerto/GUA/disponibles?tipo=ELECTRICO
            if (string.IsNullOrEmpty(tipo))
                return BadRequest("Debe especificar el tipo de espacio (ej. AUTOMOVIL, ELECTRICO).");

            var result = await _service.ListarDisponiblesPorTipo(codigo, tipo.ToUpper());
            return Ok(result);
        }

        [HttpPatch("{id}/disponibilidad")]
        public async Task<IActionResult> PatchDisponibilidad(int id, [FromBody] int disponible)
        {
            if (disponible != 0 && disponible != 1)
                return BadRequest("La disponibilidad debe ser 0 (Ocupado) o 1 (Disponible).");

            await _service.CambiarDisponibilidad(id, disponible);
            string estado = disponible == 1 ? "Disponible" : "Ocupado";
            return Ok(new { mensaje = $"El espacio ha sido marcado como {estado}." });
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Espacio de estacionamiento eliminado físicamente." });
        }
    }
}