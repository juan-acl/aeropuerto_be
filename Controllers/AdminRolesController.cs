using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminRolesController : ControllerBase
    {
        private readonly DBContext _context;

        public AdminRolesController(DBContext context)
        {
            _context = context;
        }

        public class CrearRolDto
        {
            public string NombreRol { get; set; } = null!;
            public string Descripcion { get; set; } = null!;
            public decimal NivelJerarquico { get; set; } = 3;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearRolDto request)
        {
            try
            {
                int maxId = await _context.RolesSistema.AnyAsync() 
                            ? await _context.RolesSistema.MaxAsync(r => r.IdRolSistema) 
                            : 0;

                var nuevoRol = new RolesSistema
                {
                    IdRolSistema = maxId + 1,
                    NombreRol = request.NombreRol.ToUpper(),
                    Descripcion = request.Descripcion,
                    NivelJerarquico = request.NivelJerarquico,
                    Activo = 1
                };

                _context.RolesSistema.Add(nuevoRol);
                await _context.SaveChangesAsync();

                return Ok(new {
                    mensaje = "Rol creado exitosamente.",
                    rol = nuevoRol
                });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al insertar el rol.", detalle = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarRoles()
        {
            var data = await _context.RolesSistema.ToListAsync();
            return Ok(data);
        }
    }
}
