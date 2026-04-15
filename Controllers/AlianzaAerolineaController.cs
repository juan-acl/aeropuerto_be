using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlianzaAerolineasController : ControllerBase
    {
        private readonly IAlianzaAerolineaService _service;

        public AlianzaAerolineasController(IAlianzaAerolineaService service)
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
                return StatusCode(500, $"Error al obtener las alianzas: {ex.Message}");
            }
        }

        // 2. OBTENER POR ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var alianza = await _service.ObtenerPorId(id);
                if (alianza == null) return NotFound($"Alianza con ID {id} no encontrada.");
                return Ok(alianza);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar la alianza: {ex.Message}");
            }
        }

        // 3. INSERTAR (POST) - Llama a pkg_alianzas.insert_alianza
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] AlianzaAerolineaModel modelo)
        {
            if (modelo == null) return BadRequest("Datos de la alianza no válidos.");

            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = $"Alianza '{modelo.NombreAlianza}' creada con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar la alianza: {ex.Message}");
            }
        }

        // 4. ACTUALIZAR (PUT) - Llama a pkg_alianzas.update_alianza
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, string sede, int numeroMiembros, string descripcion)
        {
            try
            {
                var resultado = await _service.Actualizar(id, sede, numeroMiembros, descripcion);
                if (!resultado) return NotFound($"No se pudo actualizar: La alianza con ID {id} no existe.");

                return Ok(new { mensaje = $"Alianza con ID {id} actualizada correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la alianza: {ex.Message}");
            }
        }

        // 5. ELIMINAR (DELETE) - Llama a pkg_alianzas.delete_alianza
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.Eliminar(id);
                return Ok(new { mensaje = $"Alianza con ID {id} eliminada correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la alianza: {ex.Message}");
            }
        }
    }
}
