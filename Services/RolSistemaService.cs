using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class RolSistemaService : IRolSistemaService
    {
        private readonly DBContext _context;
        public RolSistemaService(DBContext context) => _context = context;

        public async Task<bool> Insertar(RolesSistema m)
        {
            var p = new[] {
                new OracleParameter("p_nombre_rol", (object?)m.NombreRol ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_nivel_jerarquico", (object?)m.NivelJerarquico ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_roles_sistema.insert_rol(:p_nombre_rol, :p_descripcion, :p_nivel_jerarquico, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_roles_sistema.delete_rol(:p_id_rol_sistema); END;", new OracleParameter("p_id_rol_sistema", id));
            return true;
        }

        public async Task<List<RolesSistema>> ListarTodo() => await _context.Set<RolesSistema>().ToListAsync();
    }
}
