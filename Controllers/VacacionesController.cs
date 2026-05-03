using Microsoft.AspNetCore.Mvc;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacacionesController : ControllerBase
    {
        private readonly IVacacionesService _service;
        public VacacionesController(IVacacionesService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ListarTodo());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VacacionPermiso m) => Ok(await _service.Insertar(m));
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _service.ObtenerPorId(id));
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VacacionPermiso m) => Ok(await _service.Actualizar(m));
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _service.Eliminar(id));
    }
}