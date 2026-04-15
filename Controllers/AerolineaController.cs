using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AerolineasController : ControllerBase
    {
        private readonly IAerolineaService _service;

        public AerolineasController(IAerolineaService service)
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
                return StatusCode(500, $"Error al listar aerolíneas: {ex.Message}");
            }
        }

        // 2. OBTENER POR ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var aerolinea = await _service.ObtenerPorId(id);
                if (aerolinea == null) return NotFound($"Aerolínea con ID {id} no encontrada.");
                return Ok(aerolinea);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener aerolínea: {ex.Message}");
            }
        }

        // 3. INSERTAR (POST) - Llama a pkg_aerolineas.insert_aerolinea
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] AerolineaModel modelo)
        {
            if (modelo == null) return BadRequest("Datos de aerolínea inválidos");

            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = $"Aerolínea '{modelo.NombreAerolinea}' insertada correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar aerolínea: {ex.Message}");
            }
        }

        // 4. ACTUALIZAR (PUT) - Llama a pkg_aerolineas.update_aerolinea
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, int flota, int destinos, string alianza, int activo)
        {
            try
            {
                var resultado = await _service.Actualizar(id, flota, destinos, alianza, activo);
                if (!resultado) return NotFound($"No se pudo actualizar: Aerolínea con ID {id} no existe.");

                return Ok(new { mensaje = $"Aerolínea con ID {id} actualizada correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar aerolínea: {ex.Message}");
            }
        }

        // 5. ELIMINAR (DELETE) - Llama a pkg_aerolineas.delete_aerolinea
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.Eliminar(id);
                return Ok(new { mensaje = $"Aerolínea con ID {id} eliminada correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar aerolínea: {ex.Message}");
            }
        }
    }
}
