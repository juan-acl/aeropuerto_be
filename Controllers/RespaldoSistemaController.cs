using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/respaldossistema")]
    public class RespaldoSistemaController : ControllerBase
    {
        private readonly IRespaldoSistemaService _service;
        public RespaldoSistemaController(IRespaldoSistemaService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Listar() { try { return Ok(await _service.ListarTodo()); } catch (Exception ex) { return StatusCode(500, ex.Message); } }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id) { try { var i = await _service.ObtenerPorId(id); return i == null ? NotFound() : Ok(i); } catch (Exception ex) { return StatusCode(500, ex.Message); } }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] RespaldosSistema modelo) { try { await _service.Insertar(modelo); return Ok(new { mensaje = "Creado." }); } catch (Exception ex) { return StatusCode(500, ex.Message); } }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] RespaldosSistema modelo) { try { var ok = await _service.Actualizar(id, modelo); return ok ? Ok(new { mensaje = "Actualizado." }) : NotFound(); } catch (Exception ex) { return StatusCode(500, ex.Message); } }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id) { try { await _service.Eliminar(id); return Ok(new { mensaje = "Eliminado." }); } catch (Exception ex) { return StatusCode(500, ex.Message); } }
    }
}
