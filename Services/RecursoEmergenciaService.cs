using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class RecursoEmergenciaService : IRecursoEmergenciaService
    {
        private readonly DBContext _context;
        public RecursoEmergenciaService(DBContext context) => _context = context;

        public async Task<List<RecursosEmergencia>> ListarTodo()
        {
            try { return await _context.RecursosEmergencia.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo RecursosEmergencia: {ex.Message}"); return new List<RecursosEmergencia>(); }
        }

        public async Task<RecursosEmergencia?> ObtenerPorId(int id)
        {
            try { return await _context.RecursosEmergencia.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId RecursosEmergencia: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(RecursosEmergencia m)
        {
            try
            {
                string sql = "BEGIN pkg_recursos_emergencia.insert_recurso(:p_tipo_recurso, :p_nombre_recurso, :p_cantidad_disponible, :p_ubicacion_almacen, :p_fecha_vencimiento, :p_proveedor, :p_responsable_mantenimiento, :p_fecha_ultima_revision, :p_fecha_proxima_revision, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_tipo_recurso", (object?)m.TipoRecurso ?? DBNull.Value),
                new OracleParameter("p_nombre_recurso", (object?)m.NombreRecurso ?? DBNull.Value),
                new OracleParameter("p_cantidad_disponible", (object?)m.CantidadDisponible ?? DBNull.Value),
                new OracleParameter("p_ubicacion_almacen", (object?)m.UbicacionAlmacen ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_proveedor", (object?)m.Proveedor ?? DBNull.Value),
                new OracleParameter("p_responsable_mantenimiento", (object?)m.ResponsableMantenimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_ultima_revision", (object?)m.FechaUltimaRevision ?? DBNull.Value),
                new OracleParameter("p_fecha_proxima_revision", (object?)m.FechaProximaRevision ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar RecursosEmergencia: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, RecursosEmergencia m)
        {
            try
            {
                string sql = "BEGIN pkg_recursos_emergencia.update_recurso(:p_id_recurso_emergencia, :p_tipo_recurso, :p_nombre_recurso, :p_cantidad_disponible, :p_ubicacion_almacen, :p_fecha_vencimiento, :p_proveedor, :p_responsable_mantenimiento, :p_fecha_ultima_revision, :p_fecha_proxima_revision, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_recurso_emergencia", id),
                new OracleParameter("p_tipo_recurso", (object?)m.TipoRecurso ?? DBNull.Value),
                new OracleParameter("p_nombre_recurso", (object?)m.NombreRecurso ?? DBNull.Value),
                new OracleParameter("p_cantidad_disponible", (object?)m.CantidadDisponible ?? DBNull.Value),
                new OracleParameter("p_ubicacion_almacen", (object?)m.UbicacionAlmacen ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_proveedor", (object?)m.Proveedor ?? DBNull.Value),
                new OracleParameter("p_responsable_mantenimiento", (object?)m.ResponsableMantenimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_ultima_revision", (object?)m.FechaUltimaRevision ?? DBNull.Value),
                new OracleParameter("p_fecha_proxima_revision", (object?)m.FechaProximaRevision ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar RecursosEmergencia: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_recursos_emergencia.delete_recurso(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar RecursosEmergencia: {ex.Message}"); return false; }
        }
    }
}
