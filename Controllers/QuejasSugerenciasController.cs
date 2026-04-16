using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuejasSugerenciasController : ControllerBase
    {
        private readonly IQuejasSugerenciasService _service;

        public QuejasSugerenciasController(IQuejasSugerenciasService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuejasSugerenciasModel modelo)
        {
            try
            {
                int ticketId = await _service.RegistrarContacto(modelo);
                return Ok(new
                {
                    mensaje = "Su caso ha sido registrado. Nuestro equipo lo revisará pronto.",
                    numeroTicket = ticketId
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar el caso: {ex.Message}");
            }
        }

        public class RespuestaDto
        {
            public string TextoRespuesta { get; set; } = null!;
        }

        [HttpPatch("{id}/responder")]
        public async Task<IActionResult> PatchResponder(int id, [FromBody] RespuestaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TextoRespuesta))
                return BadRequest("La respuesta no puede estar vacía.");

            await _service.ResponderContacto(id, dto.TextoRespuesta);
            return Ok(new { mensaje = "Caso actualizado a estado RESPONDIDO y fecha estampada." });
        }

        [HttpPatch("{id}/calificar")]
        public async Task<IActionResult> PatchCalificar(int id, [FromBody] int satisfaccion)
        {
            if (satisfaccion < 1 || satisfaccion > 5)
                return BadRequest("El nivel de satisfacción debe estar entre 1 y 5.");

            await _service.CalificarRespuesta(id, satisfaccion);
            return Ok(new { mensaje = "Calificación registrada y caso CERRADO exitosamente." });
        }

        [HttpGet("estado/{estado}")]
        public async Task<IActionResult> GetByEstado(string estado)
        {
            var result = await _service.ListarPorEstado(estado);
            return Ok(result);
        }

        [HttpGet("pasajero/{idPasajero}")]
        public async Task<IActionResult> GetByPasajero(int idPasajero)
        {
            var result = await _service.ListarPorPasajero(idPasajero);
            return Ok(result);
        }

        [HttpDelete("fisico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarFisico(id);
            return Ok(new { mensaje = "Registro eliminado físicamente." });
        }
    }
}