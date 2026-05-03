using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasaController : ControllerBase
    {
        private readonly ITasaService _service;
        public TasaController(ITasaService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ListarTodo());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TasaAeroportuaria m) 
        {
            if (m == null) return BadRequest("La tasa aeroportuaria no puede ser nula.");
            
            var exito = await _service.Insertar(m);
            return exito ? Ok(new { mensaje = "Tasa creada" }) : StatusCode(500, "Error interno en Oracle.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _service.ObtenerPorId(id));
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TasaAeroportuaria m) => Ok(await _service.Actualizar(m));
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _service.Eliminar(id));
    }
}