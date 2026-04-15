using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitoreoAireController : ControllerBase
    {
        private readonly IMonitoreoAireService _service;

        public MonitoreoAireController(IMonitoreoAireService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<MonitoreoAire>>> Get()
        {
            var lista = await _service.ListarTodo();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MonitoreoAire>> GetById(int id)
        {
            var item = await _service.ObtenerPorId(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] MonitoreoAire modelo)
        {
            var resultado = await _service.Insertar(modelo);
            if (!resultado) return BadRequest("No se pudo registrar la medición de aire.");
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(int id, [FromBody] MonitoreoAire modelo)
        {
            var resultado = await _service.Actualizar(id, modelo);
            if (!resultado) return NotFound("No se encontró la medición o no se pudo actualizar.");
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var resultado = await _service.Eliminar(id);
            if (!resultado) return NotFound("La medición no existe.");
            return Ok(resultado);
        }
    }
}