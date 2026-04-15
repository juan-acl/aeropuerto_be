using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FabricanteAvionController : ControllerBase
    {
        private readonly IFabricanteAvionService _service;

        public FabricanteAvionController(IFabricanteAvionService service)
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
                return StatusCode(500, $"Error al obtener los fabricantes: {ex.Message}");
            }
        }

        // 2. OBTENER POR ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var fabricante = await _service.ObtenerPorId(id);
                if (fabricante == null) return NotFound($"Fabricante con ID {id} no encontrado.");
                return Ok(fabricante);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar el fabricante: {ex.Message}");
            }
        }

        // 3. INSERTAR (POST) - Llama a pkg_fabricantes.insert_fabricante
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] FabricanteAvionModel modelo)
        {
            if (modelo == null) return BadRequest("Datos del fabricante no válidos.");

            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = $"Fabricante '{modelo.NombreFabricante}' registrado con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar el fabricante: {ex.Message}");
            }
        }

        // 4. ACTUALIZAR (PUT) - Llama a pkg_fabricantes.update_fabricante
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, string pais, string sede, string website, int activo)
        {
            try
            {
                var resultado = await _service.Actualizar(id, pais, sede, website, activo);
                if (!resultado) return NotFound($"No se pudo actualizar: El fabricante con ID {id} no existe.");

                return Ok(new { mensaje = $"Fabricante con ID {id} actualizado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el fabricante: {ex.Message}");
            }
        }

        // 5. ELIMINAR (DELETE) - Llama a pkg_fabricantes.delete_fabricante
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.Eliminar(id);
                return Ok(new { mensaje = $"Fabricante con ID {id} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el fabricante: {ex.Message}");
            }
        }
    }
}
