using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiasOperacionController : ControllerBase
    {
        private readonly IDiasOperacionService _service;

        public DiasOperacionController(IDiasOperacionService service)
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
                return StatusCode(500, $"Error al obtener el catálogo de días: {ex.Message}");
            }
        }

        // 2. OBTENER POR ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var dia = await _service.ObtenerPorId(id);
                if (dia == null) return NotFound($"Día con ID {id} no encontrado.");
                return Ok(dia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar el día: {ex.Message}");
            }
        }

        // 3. INSERTAR (POST) - Llama a pkg_dias_operacion.insert_dia
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] DiaOperacionModel modelo)
        {
            if (modelo == null) return BadRequest("Datos del día no válidos.");

            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = $"Día '{modelo.NombreDia}' registrado con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar el día: {ex.Message}");
            }
        }

        // 4. ACTUALIZAR (PUT) - Llama a pkg_dias_operacion.update_dia
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, string nombreDia, int activo)
        {
            try
            {
                var resultado = await _service.Actualizar(id, nombreDia, activo);
                if (!resultado) return NotFound($"No se pudo actualizar: El día con ID {id} no existe.");

                return Ok(new { mensaje = $"Día con ID {id} actualizado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el día: {ex.Message}");
            }
        }

        // 5. ELIMINAR (DELETE) - Llama a pkg_dias_operacion.delete_dia
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.Eliminar(id);
                return Ok(new { mensaje = $"Día con ID {id} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el día: {ex.Message}");
            }
        }
    }
}
