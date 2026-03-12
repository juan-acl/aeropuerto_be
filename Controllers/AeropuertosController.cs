using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AeropuertosController : ControllerBase
    {
        private readonly IAeropuertoService _service;

        public AeropuertosController(IAeropuertoService service)
        {
            _service = service;
        }

        // 1. INSERTAR (POST) - Llama a insert_aeropuerto
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] AeropuertoModel modelo)
        {
            if (modelo == null) return BadRequest("Datos inválidos");

            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = $"Aeropuerto {modelo.CodigoAeropuerto} insertado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar: {ex.Message}");
            }
        }

        // 2. ACTUALIZAR (PUT) - Llama a update_aeropuerto
        [HttpPut("{codigo}")]
        public async Task<IActionResult> Actualizar(string codigo, int terminales, int puertas, int activo)
        {
            try
            {
                await _service.Actualizar(codigo, terminales, puertas, activo);
                return Ok(new { mensaje = $"Aeropuerto {codigo} actualizado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar: {ex.Message}");
            }
        }

        // 3. ELIMINAR (DELETE) - Llama a delete_aeropuerto
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Eliminar(string codigo)
        {
            try
            {
                await _service.Eliminar(codigo);
                return Ok(new { mensaje = $"Aeropuerto {codigo} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar: {ex.Message}");
            }
        }

        // 4. LISTAR TODO (GET)
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
                return StatusCode(500, $"Error al listar: {ex.Message}");
            }
        }
    }
}