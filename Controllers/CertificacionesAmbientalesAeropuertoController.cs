using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificacionesAmbientalesAeropuertoController : ControllerBase
    {
        private readonly ICertificacionesAmbientalesAeropuertoService _service;

        public CertificacionesAmbientalesAeropuertoController(ICertificacionesAmbientalesAeropuertoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CertificacionesAmbientalesAeropuerto modelo)
        {
            if (modelo == null) return BadRequest("Datos inválidos");
            try {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "CertificacionesAmbientalesAeropuerto insertado correctamente." });
            } catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] CertificacionesAmbientalesAeropuerto modelo)
        {
            try {
                await _service.Actualizar(modelo.IdCertificacionAmbiental, modelo);
                return Ok(new { mensaje = "CertificacionesAmbientalesAeropuerto actualizado correctamente." });
            } catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try {
                await _service.Eliminar(id);
                return Ok(new { mensaje = "CertificacionesAmbientalesAeropuerto eliminado correctamente." });
            } catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try {
                var lista = await _service.ListarTodo();
                return Ok(lista);
            } catch (Exception ex) { return StatusCode(500, ex.Message); }
        }
    }
}
