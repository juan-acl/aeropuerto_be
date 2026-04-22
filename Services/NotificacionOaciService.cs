using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class NotificacionOaciService : INotificacionOaciService
    {
        private readonly DBContext _context;
        public NotificacionOaciService(DBContext context) => _context = context;

        public async Task<List<NotificacionesOaci>> ListarTodo()
        {
            try { return await _context.NotificacionesOaci.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo NotificacionesOaci: {ex.Message}"); return new List<NotificacionesOaci>(); }
        }

        public async Task<NotificacionesOaci?> ObtenerPorId(int id)
        {
            try { return await _context.NotificacionesOaci.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId NotificacionesOaci: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(NotificacionesOaci m)
        {
            try
            {
                string sql = "BEGIN pkg_notificaciones_oaci.insert_notificacion(:p_numero_notificacion, :p_fecha_recepcion, :p_tipo_notificacion, :p_asunto, :p_descripcion, :p_fecha_limite_cumplimiento, :p_documento_notificacion, :p_area_responsable, :p_estado_cumplimiento, :p_fecha_cumplimiento, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_numero_notificacion", (object?)m.NumeroNotificacion ?? DBNull.Value),
                new OracleParameter("p_fecha_recepcion", (object?)m.FechaRecepcion ?? DBNull.Value),
                new OracleParameter("p_tipo_notificacion", (object?)m.TipoNotificacion ?? DBNull.Value),
                new OracleParameter("p_asunto", (object?)m.Asunto ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_fecha_limite_cumplimiento", (object?)m.FechaLimiteCumplimiento ?? DBNull.Value),
                new OracleParameter("p_documento_notificacion", OracleDbType.Blob) { Value = (object?)m.DocumentoNotificacion ?? DBNull.Value },
                new OracleParameter("p_area_responsable", (object?)m.AreaResponsable ?? DBNull.Value),
                new OracleParameter("p_estado_cumplimiento", (object?)m.EstadoCumplimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_cumplimiento", (object?)m.FechaCumplimiento ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar NotificacionesOaci: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, NotificacionesOaci m)
        {
            try
            {
                string sql = "BEGIN pkg_notificaciones_oaci.update_notificacion(:p_id_notificacion_oaci, :p_numero_notificacion, :p_fecha_recepcion, :p_tipo_notificacion, :p_asunto, :p_descripcion, :p_fecha_limite_cumplimiento, :p_documento_notificacion, :p_area_responsable, :p_estado_cumplimiento, :p_fecha_cumplimiento, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_notificacion_oaci", id),
                new OracleParameter("p_numero_notificacion", (object?)m.NumeroNotificacion ?? DBNull.Value),
                new OracleParameter("p_fecha_recepcion", (object?)m.FechaRecepcion ?? DBNull.Value),
                new OracleParameter("p_tipo_notificacion", (object?)m.TipoNotificacion ?? DBNull.Value),
                new OracleParameter("p_asunto", (object?)m.Asunto ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_fecha_limite_cumplimiento", (object?)m.FechaLimiteCumplimiento ?? DBNull.Value),
                new OracleParameter("p_documento_notificacion", OracleDbType.Blob) { Value = (object?)m.DocumentoNotificacion ?? DBNull.Value },
                new OracleParameter("p_area_responsable", (object?)m.AreaResponsable ?? DBNull.Value),
                new OracleParameter("p_estado_cumplimiento", (object?)m.EstadoCumplimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_cumplimiento", (object?)m.FechaCumplimiento ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar NotificacionesOaci: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_notificaciones_oaci.delete_notificacion(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar NotificacionesOaci: {ex.Message}"); return false; }
        }
    }
}
