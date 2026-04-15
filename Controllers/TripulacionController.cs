using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripulacionController : ControllerBase
    {
        private readonly ITripulacionService _service;

        public TripulacionController(ITripulacionService service)
        {
            _service = service;
        }

        // 1. LISTAR TODO (GET)
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var lista = await _service.ListarTodo();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la tripulación: {ex.Message}");
            }
        }

        // 2. OBTENER POR ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var tripulante = await _service.ObtenerPorId(id);
                if (tripulante == null) return NotFound($"Tripulante con ID {id} no encontrado.");
                return Ok(tripulante);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar tripulante: {ex.Message}");
            }
        }

        // 3. INSERTAR (POST) - Llama a pkg_tripulacion.insert_tripulante
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] TripulacionModel modelo)
        {
            if (modelo == null) return BadRequest("Datos del tripulante no válidos.");

            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = $"Tripulante {modelo.Nombres} {modelo.Apellidos} registrado con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar tripulante: {ex.Message}");
            }
        }

        // 4. ACTUALIZAR (PUT) - Llama a pkg_tripulacion.update_tripulante
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, string tipoTripulante, string licencia, DateTime vencimientoLicencia, decimal horasVuelo, int activo)
        {
            try
            {
                var resultado = await _service.Actualizar(id, tipoTripulante, licencia, vencimientoLicencia, horasVuelo, activo);
                if (!resultado) return NotFound($"No se pudo actualizar: El tripulante con ID {id} no existe.");

                return Ok(new { mensaje = $"Datos operativos del tripulante con ID {id} actualizados correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar tripulante: {ex.Message}");
            }
        }

        // 5. ELIMINAR (DELETE) - Llama a pkg_tripulacion.delete_tripulante
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.Eliminar(id);
                return Ok(new { mensaje = $"Tripulante con ID {id} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar tripulante: {ex.Message}");
            }
        }
    }
}
