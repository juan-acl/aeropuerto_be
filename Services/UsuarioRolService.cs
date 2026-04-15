using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services.Seguridad
{
    public class UsuarioRolService : IUsuarioRolService
    {
        private readonly DBContext _context;
        public UsuarioRolService(DBContext context) => _context = context;

        public async Task<bool> Insertar(UsuariosRoles m)
        {
            var p = new[] {
                new OracleParameter("p_id_usuario_sistema", (object?)m.IdUsuarioSistema ?? DBNull.Value),
                new OracleParameter("p_id_rol_sistema", (object?)m.IdRolSistema ?? DBNull.Value),
                new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_asignado_por", (object?)m.AsignadoPor ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_usuarios_roles.insert_usuario_rol(:p_id_usuario_sistema, :p_id_rol_sistema, :p_fecha_asignacion, :p_asignado_por, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Eliminar(int id1)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_usuarios_roles.delete_usuario_rol(:p_id_usuario_sistema, :p_id_rol_sistema); END;", new OracleParameter("p_id_usuario_sistema", id1));
            return true;
        }

        public async Task<List<UsuariosRoles>> ListarTodo() => await _context.Set<UsuariosRoles>().ToListAsync();
    }
}
