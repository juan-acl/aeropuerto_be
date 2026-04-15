using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoAeropuertoController : ControllerBase
    {
        private readonly ITipoAeropuertoService _service;

        public TipoAeropuertoController(ITipoAeropuertoService service)
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
                return StatusCode(500, $"Error al obtener los tipos de aeropuerto: {ex.Message}");
            }
        }

        // 2. OBTENER POR ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var tipo = await _service.ObtenerPorId(id);
                if (tipo == null) return NotFound($"Tipo de aeropuerto con ID {id} no encontrado.");
                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar el tipo de aeropuerto: {ex.Message}");
            }
        }

        // 3. INSERTAR (POST) - Llama a pkg_tipos_aeropuerto.insert_tipo
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] TipoAeropuertoModel modelo)
        {
            if (modelo == null) return BadRequest("Datos del tipo de aeropuerto no válidos.");

            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = $"Tipo de aeropuerto '{modelo.Descripcion}' registrado con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar: {ex.Message}");
            }
        }

        // 4. ACTUALIZAR (PUT) - Llama a pkg_tipos_aeropuerto.update_tipo
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, string descripcion, string codigo, int activo)
        {
            try
            {
                var resultado = await _service.Actualizar(id, descripcion, codigo, activo);
                if (!resultado) return NotFound($"No se pudo actualizar: El ID {id} no existe.");

                return Ok(new { mensaje = $"Tipo de aeropuerto con ID {id} actualizado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar: {ex.Message}");
            }
        }

        // 5. ELIMINAR (DELETE) - Llama a pkg_tipos_aeropuerto.delete_tipo
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.Eliminar(id);
                return Ok(new { mensaje = $"Tipo de aeropuerto con ID {id} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar: {ex.Message}");
            }
        }
    }
}
