using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class RecursoEmergenciaService : IRecursoEmergenciaService
    {
        private readonly DBContext _context;
        public RecursoEmergenciaService(DBContext context) => _context = context;

        public async Task<bool> Insertar(RecursosEmergencia m)
        {
            var p = new[] {
                new OracleParameter("p_tipo_recurso", (object?)m.TipoRecurso ?? DBNull.Value),
                new OracleParameter("p_nombre_recurso", (object?)m.NombreRecurso ?? DBNull.Value),
                new OracleParameter("p_cantidad_disponible", (object?)m.CantidadDisponible ?? DBNull.Value),
                new OracleParameter("p_ubicacion_almacen", (object?)m.UbicacionAlmacen ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_proveedor", (object?)m.Proveedor ?? DBNull.Value),
                new OracleParameter("p_responsable_mantenimiento", (object?)m.ResponsableMantenimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_ultima_revision", (object?)m.FechaUltimaRevision ?? DBNull.Value),
                new OracleParameter("p_fecha_proxima_revision", (object?)m.FechaProximaRevision ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_recursos_emergencia.insert_recurso(:p_tipo_recurso, :p_nombre_recurso, :p_cantidad_disponible, :p_ubicacion_almacen, :p_fecha_vencimiento, :p_proveedor, :p_responsable_mantenimiento, :p_fecha_ultima_revision, :p_fecha_proxima_revision, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, RecursosEmergencia m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_recurso_emergencia", m.IdRecursoEmergencia)
            };
            p.AddRange(new[] {
                new OracleParameter("p_tipo_recurso", (object?)m.TipoRecurso ?? DBNull.Value),
                new OracleParameter("p_nombre_recurso", (object?)m.NombreRecurso ?? DBNull.Value),
                new OracleParameter("p_cantidad_disponible", (object?)m.CantidadDisponible ?? DBNull.Value),
                new OracleParameter("p_ubicacion_almacen", (object?)m.UbicacionAlmacen ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_proveedor", (object?)m.Proveedor ?? DBNull.Value),
                new OracleParameter("p_responsable_mantenimiento", (object?)m.ResponsableMantenimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_ultima_revision", (object?)m.FechaUltimaRevision ?? DBNull.Value),
                new OracleParameter("p_fecha_proxima_revision", (object?)m.FechaProximaRevision ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_recursos_emergencia.update_recurso(:p_id_recurso_emergencia, :p_tipo_recurso, :p_nombre_recurso, :p_cantidad_disponible, :p_ubicacion_almacen, :p_fecha_vencimiento, :p_proveedor, :p_responsable_mantenimiento, :p_fecha_ultima_revision, :p_fecha_proxima_revision, :p_activo); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_recursos_emergencia.delete_recurso(:p_id_recurso_emergencia); END;", 
                new OracleParameter("p_id_recurso_emergencia", id));
            return true;
        }

        public async Task<List<RecursosEmergencia>> ListarTodo() => await _context.Set<RecursosEmergencia>().ToListAsync();

        public async Task<RecursosEmergencia?> ObtenerPorId(int id) => await _context.Set<RecursosEmergencia>().FindAsync(id);
    }
}
