using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _service;

        public DepartamentoController(IDepartamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Departamento modelo)
        {
            try {
                await _service.Insertar(modelo);
                return Ok(new { mensaje = "Departamento insertado correctamente." });
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
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _service.ObtenerPorId(id));
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Departamento m) => Ok(await _service.Actualizar(m));
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _service.Eliminar(id));
    }
}