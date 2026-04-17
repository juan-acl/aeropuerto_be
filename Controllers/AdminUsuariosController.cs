using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Models;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Aeropuerto.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminUsuariosController : ControllerBase
    {
        private readonly DBContext _context;

        public AdminUsuariosController(DBContext context)
        {
            _context = context;
        }

        public class CrearUsuarioDto
        {
            public string NombreCompleto { get; set; } = null!;
            public string NombreUsuario { get; set; } = null!;
            public string Email { get; set; } = null!;
            public int IdRolSistema { get; set; }
            public string Password { get; set; } = null!;
            public string Departamento { get; set; } = "General";
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearUsuarioDto request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Validación básica para evitar duplicados
                var existe = await _context.UsuariosSistema.AnyAsync(u => u.NombreUsuario.ToLower() == request.NombreUsuario.ToLower());
                if (existe) return BadRequest(new { mensaje = "El nombre de usuario ya está en uso." });

                // Calcular nuevo ID (Oracle autoincrement usualmente necesita trigger, sino calculamos Max+1 de forma manual para evitar error de entidad)
                int maxIdUser = await _context.UsuariosSistema.AnyAsync() ? await _context.UsuariosSistema.MaxAsync(u => u.IdUsuarioSistema) : 0;
                
                var nuevoUsuario = new UsuariosSistema
                {
                    IdUsuarioSistema = maxIdUser + 1,
                    NombreUsuario = request.NombreUsuario,
                    PasswordHash = request.Password, // Texto plano por mandato de demo
                    EmailInstitucional = request.Email,
                    FechaCreacion = DateTime.Now,
                    Activo = 1
                };

                _context.UsuariosSistema.Add(nuevoUsuario);
                await _context.SaveChangesAsync();

                int maxIdRol = await _context.UsuariosRoles.AnyAsync() ? await _context.UsuariosRoles.MaxAsync(ur => ur.IdUsuarioRol) : 0;

                var usuRol = new UsuariosRoles
                {
                    IdUsuarioRol = maxIdRol + 1,
                    IdUsuarioSistema = nuevoUsuario.IdUsuarioSistema,
                    IdRolSistema = request.IdRolSistema,
                    FechaAsignacion = DateTime.Now
                };

                _context.UsuariosRoles.Add(usuRol);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                // Devolvemos el registro consolidado
                return Ok(new {
                    mensaje = "Usuario creado y asociado exitosamente.",
                    usuario = new {
                        id = nuevoUsuario.IdUsuarioSistema,
                        nombre_usuario = nuevoUsuario.NombreUsuario,
                        email = nuevoUsuario.EmailInstitucional,
                        rolId = request.IdRolSistema,
                        estado = "ACTIVO"
                    }
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new { mensaje = "Error al crear usuario transaccionalmente.", detalle = ex.Message });
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> ListarConsolidado()
        {
            // Join de Usuarios con Roles
            var query = from u in _context.UsuariosSistema
                        join ur in _context.UsuariosRoles on u.IdUsuarioSistema equals ur.IdUsuarioSistema into usrRol
                        from ur in usrRol.DefaultIfEmpty()
                        join r in _context.RolesSistema on (ur == null ? 0 : ur.IdRolSistema) equals r.IdRolSistema into rol
                        from r in rol.DefaultIfEmpty()
                        select new {
                            id = u.IdUsuarioSistema,
                            nombre_usuario = u.NombreUsuario,
                            nombre_completo = u.NombreUsuario, // Suplente
                            email = u.EmailInstitucional,
                            estado = u.Activo == 1 ? "ACTIVO" : "BLOQUEADO",
                            rol = r != null ? r.NombreRol : "SIN_ROL",
                            rolId = r != null ? r.IdRolSistema : 0,
                            fecha_creacion = u.FechaCreacion.ToString(),
                            departamento = "General"
                        };

            var data = await query.ToListAsync();
            return Ok(data);
        }
    }
}
