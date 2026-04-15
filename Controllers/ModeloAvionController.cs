using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeloAvionController : ControllerBase
    {
        private readonly IModeloAvionService _service;

        public ModeloAvionController(IModeloAvionService service)
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
                return StatusCode(500, $"Error al obtener los modelos de aviones: {ex.Message}");
            }
        }

        // 2. OBTENER POR ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var modelo = await _service.ObtenerPorId(id);
                if (modelo == null) return NotFound($"Modelo con ID {id} no encontrado.");
                return Ok(modelo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar el modelo: {ex.Message}");
            }
        }

        // 3. INSERTAR (POST) - Llama a pkg_modelos_aviones.insert_modelo
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ModeloAvionModel modelo)
        {
            if (modelo == null) return BadRequest("Datos del modelo no válidos.");

            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = $"Modelo '{modelo.NombreModelo}' registrado con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar el modelo: {ex.Message}");
            }
        }

        // 4. ACTUALIZAR (PUT) - Llama a pkg_modelos_aviones.update_modelo
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, int pasajeros, decimal carga, decimal autonomia, int activo)
        {
            try
            {
                var resultado = await _service.Actualizar(id, pasajeros, carga, autonomia, activo);
                if (!resultado) return NotFound($"No se pudo actualizar: El modelo con ID {id} no existe.");

                return Ok(new { mensaje = $"Modelo con ID {id} actualizado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el modelo: {ex.Message}");
            }
        }

        // 5. ELIMINAR (DELETE) - Llama a pkg_modelos_aviones.delete_modelo
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.Eliminar(id);
                return Ok(new { mensaje = $"Modelo con ID {id} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el modelo: {ex.Message}");
            }
        }
    }
}
