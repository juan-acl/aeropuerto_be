using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasajerosController : ControllerBase
    {
        private readonly IPasajeroService _service;

        public PasajerosController(IPasajeroService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] PasajeroModel modelo)
        {
            if (modelo == null) return BadRequest("Datos inválidos");
            try
            {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = $"Pasajero {modelo.Nombres} {modelo.Apellidos} registrado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarContacto(int id, string telefono, string email, string direccion)
        {
            try
            {
                await _service.ActualizarContacto(id, telefono, email, direccion);
                return Ok(new { mensaje = $"Contacto del pasajero ID {id} actualizado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _service.Eliminar(id);
                return Ok(new { mensaje = $"Pasajero ID {id} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar: {ex.Message}");
            }
        }

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


            [HttpPost("registrar")]
            public async Task<IActionResult> Registrar([FromBody] RegistrarPasajeroRequest modelo)
            {
                if (modelo == null) return BadRequest("Datos del pasajero requeridos.");

                try
                {
                    await _service.RegistrarPasajero(modelo);
                    return Ok(new { mensaje = $"Pasajero {modelo.Nombre} {modelo.Apellidos} registrado con éxito." });
                }
                catch (Exception ex)
                {
                    // Captura errores de Oracle:
                    // -40302: Documento duplicado
                    // -40303: Email inválido (Regexp)
                    // -40304: Fecha futura
                    return BadRequest(new
                    {
                        error = "No se pudo registrar al pasajero",
                        detalle = ex.Message
                    });
                }
            }
        }
    }
