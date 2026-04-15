using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorCombustibleController : ControllerBase
    {
        private readonly IProveedorCombustibleService _service;

        public ProveedorCombustibleController(IProveedorCombustibleService service)
            => _service = service;

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try { return Ok(await _service.ListarTodo()); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var item = await _service.ObtenerPorId(id);
                return item == null ? NotFound() : Ok(item);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ProveedoresCombustible modelo)
        {
            try { await _service.Insertar(modelo); return Ok(new { mensaje = "Creado." }); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ProveedoresCombustible modelo)
        {
            try
            {
                var ok = await _service.Actualizar(id, modelo);
                return ok ? Ok(new { mensaje = "Actualizado." }) : NotFound();
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try { await _service.Eliminar(id); return Ok(new { mensaje = "Eliminado." }); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }
    }
}
