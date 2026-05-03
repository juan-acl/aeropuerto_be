using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestoController : ControllerBase
    {
        private readonly IPresupuestoService _service;
        public PresupuestoController(IPresupuestoService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var lista = await _service.ListarTodo();
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Presupuesto m) 
        {
            if (m == null) return BadRequest("Los datos del presupuesto son requeridos.");
            
            var resultado = await _service.Insertar(m);
            if (resultado) return Ok(new { mensaje = "Presupuesto insertado correctamente" });
            
            return StatusCode(500, "Error al insertar el presupuesto en la base de datos.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _service.ObtenerPorId(id));
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Presupuesto m) => Ok(await _service.Actualizar(m));
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _service.Eliminar(id));
    }
}