using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemporadaVueloController : ControllerBase
    {
        private readonly ITemporadaVueloService _service;

        public TemporadaVueloController(ITemporadaVueloService service)
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
                return StatusCode(500, $"Error al obtener las temporadas: {ex.Message}");
            }
        }

        // 2. OBTENER POR ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var temporada = await _service.ObtenerPorId(id);
                if (temporada == null) return NotFound($"Temporada con ID {id} no encontrada.");
                return Ok(temporada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar la temporada: {ex.Message}");
            }
        }

        // 3. INSERTAR (POST) - Llama a pkg_temporadas_vuelo.insert_temporada
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] TemporadaVueloModel modelo)
        {
            if (modelo == null) return BadRequest("Datos de la temporada no válidos.");

            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = $"Temporada '{modelo.NombreTemporada}' registrada con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar la temporada: {ex.Message}");
            }
        }

        // 4. ACTUALIZAR (PUT) - Llama a pkg_temporadas_vuelo.update_temporada
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, string nombre, DateTime inicio, DateTime fin, decimal factor, int activa)
        {
            try
            {
                var resultado = await _service.Actualizar(id, nombre, inicio, fin, factor, activa);
                if (!resultado) return NotFound($"No se pudo actualizar: La temporada con ID {id} no existe.");

                return Ok(new { mensaje = $"Temporada con ID {id} actualizada correctamente." });
            }
            catch (Exception ex)
            {
                // Captura errores de CHECK factor_demanda (0.5 - 2.0)
                return StatusCode(500, $"Error al actualizar la temporada: {ex.Message}");
            }
        }

        // 5. ELIMINAR (DELETE) - Llama a pkg_temporadas_vuelo.delete_temporada
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.Eliminar(id);
                return Ok(new { mensaje = $"Temporada con ID {id} eliminada correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la temporada: {ex.Message}");
            }
        }
    }
}
