using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoAerolineaController(ITipoAerolineaService service) : ControllerBase
    {

        // 1. LISTAR TODO (GET)
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var lista = await service.ListarTodo();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los tipos de aerolínea: {ex.Message}");
            }
        }

        // 2. OBTENER POR ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var tipo = await service.ObtenerPorId(id);
                if (tipo == null) return NotFound($"Tipo de aerolínea con ID {id} no encontrado.");
                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar el tipo de aerolínea: {ex.Message}");
            }
        }

        // 3. INSERTAR (POST) - Llama a pkg_tipos_aerolinea.insert_tipo
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] TipoAerolineaModel modelo)
        {
            if (modelo == null) return BadRequest("Datos inválidos.");

            try
            {
                await service.Insertar(modelo);
                return Ok(new { mensaje = $"Tipo de aerolínea '{modelo.Descripcion}' registrado con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar: {ex.Message}");
            }
        }

        // 4. ACTUALIZAR (PUT) - Llama a pkg_tipos_aerolinea.update_tipo
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, string descripcion, int activo)
        {
            try
            {
                var resultado = await service.Actualizar(id, descripcion, activo);
                if (!resultado) return NotFound($"No se pudo actualizar: El ID {id} no existe.");

                return Ok(new { mensaje = $"Tipo de aerolínea con ID {id} actualizado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar: {ex.Message}");
            }
        }

        // 5. ELIMINAR (DELETE) - Llama a pkg_tipos_aerolinea.delete_tipo
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await service.Eliminar(id);
                return Ok(new { mensaje = $"Tipo de aerolínea con ID {id} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar: {ex.Message}");
            }
        }
    }
}
