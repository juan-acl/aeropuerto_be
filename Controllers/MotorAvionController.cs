using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotorAvionController : ControllerBase
    {
        private readonly IMotorAvionService _service;

        public MotorAvionController(IMotorAvionService service)
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
                return StatusCode(500, $"Error al obtener los motores: {ex.Message}");
            }
        }

        // 2. OBTENER POR ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var motor = await _service.ObtenerPorId(id);
                if (motor == null) return NotFound($"Motor con ID {id} no encontrado.");
                return Ok(motor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar el motor: {ex.Message}");
            }
        }

        // 3. INSERTAR (POST) - Llama a pkg_motores_aviones.insert_motor
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] MotorAvionModel modelo)
        {
            if (modelo == null) return BadRequest("Datos del motor no válidos.");

            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = $"Motor '{modelo.NombreMotor}' registrado con éxito." });
            }
            catch (Exception ex)
            {
                // Captura errores de CHECK CONSTRAINT (TURBOFAN, JET, etc.) de Oracle
                return StatusCode(500, $"Error al insertar el motor: {ex.Message}");
            }
        }

        // 4. ACTUALIZAR (PUT) - Llama a pkg_motores_aviones.update_motor
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, string nombre, string tipo, decimal empuje, int activo)
        {
            try
            {
                var resultado = await _service.Actualizar(id, nombre, tipo, empuje, activo);
                if (!resultado) return NotFound($"No se pudo actualizar: El motor con ID {id} no existe.");

                return Ok(new { mensaje = $"Motor con ID {id} actualizado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el motor: {ex.Message}");
            }
        }

        // 5. ELIMINAR (DELETE) - Llama a pkg_motores_aviones.delete_motor
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.Eliminar(id);
                return Ok(new { mensaje = $"Motor con ID {id} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el motor: {ex.Message}");
            }
        }
    }
}
