using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class RolPermisoModuloService : IRolPermisoModuloService
    {
        private readonly DBContext _context;
        public RolPermisoModuloService(DBContext context) => _context = context;

        public async Task<bool> Insertar(RolesPermisosModulos m)
        {
            var p = new[] {
                new OracleParameter("p_id_rol_sistema", (object?)m.IdRolSistema ?? DBNull.Value),
                new OracleParameter("p_id_modulo_sistema", (object?)m.IdModuloSistema ?? DBNull.Value),
                new OracleParameter("p_permiso_lectura", (object?)m.PermisoLectura ?? DBNull.Value),
                new OracleParameter("p_permiso_escritura", (object?)m.PermisoEscritura ?? DBNull.Value),
                new OracleParameter("p_permiso_eliminacion", (object?)m.PermisoEliminacion ?? DBNull.Value),
                new OracleParameter("p_permiso_ejecucion", (object?)m.PermisoEjecucion ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_roles_permisos_modulos.insert_permiso(:p_id_rol_sistema, :p_id_modulo_sistema, :p_permiso_lectura, :p_permiso_escritura, :p_permiso_eliminacion, :p_permiso_ejecucion); END;", p);
            return true;
        }

        public async Task<bool> Eliminar(int id1)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_roles_permisos_modulos.delete_permiso(:p_id_rol_sistema, :p_id_modulo_sistema); END;", new OracleParameter("p_id_rol_sistema", id1));
            return true;
        }

        public async Task<List<RolesPermisosModulos>> ListarTodo() => await _context.Set<RolesPermisosModulos>().ToListAsync();
    }
}
