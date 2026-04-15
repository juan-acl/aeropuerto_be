using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services.Seguridad
{
    public class ModuloSistemaService : IModuloSistemaService
    {
        private readonly DBContext _context;
        public ModuloSistemaService(DBContext context) => _context = context;

        public async Task<bool> Insertar(ModulosSistema m)
        {
            var p = new[] {
                new OracleParameter("p_nombre_modulo", (object?)m.NombreModulo ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_ruta_acceso", (object?)m.RutaAcceso ?? DBNull.Value),
                new OracleParameter("p_icono", (object?)m.Icono ?? DBNull.Value),
                new OracleParameter("p_orden", (object?)m.Orden ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_modulos_sistema.insert_modulo(:p_nombre_modulo, :p_descripcion, :p_ruta_acceso, :p_icono, :p_orden, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_modulos_sistema.delete_modulo(:p_id_modulo_sistema); END;", new OracleParameter("p_id_modulo_sistema", id));
            return true;
        }

        public async Task<List<ModulosSistema>> ListarTodo() => await _context.Set<ModulosSistema>().ToListAsync();

        public async Task<ModulosSistema?> ObtenerPorId(int id) => await _context.Set<ModulosSistema>().FindAsync(id);
    }
}
