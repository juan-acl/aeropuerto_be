using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class NotificacionLegalService : INotificacionLegalService
    {
        private readonly DBContext _context;
        public NotificacionLegalService(DBContext context) => _context = context;

        public async Task<List<NotificacionesLegales>> ListarTodo()
        {
            try { return await _context.NotificacionesLegales.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo NotificacionesLegales: {ex.Message}"); return new List<NotificacionesLegales>(); }
        }

        public async Task<NotificacionesLegales?> ObtenerPorId(int id)
        {
            try { return await _context.NotificacionesLegales.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId NotificacionesLegales: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(NotificacionesLegales m)
        {
            try
            {
                string sql = "BEGIN pkg_notificaciones_legales.insert_notificacion(:p_numero_notificacion, :p_remitente_nombre, :p_remitente_tipo, :p_destinatario_interno, :p_asunto, :p_descripcion, :p_fecha_recepcion, :p_fecha_respuesta_requerida, :p_prioridad, :p_documento_recibido, :p_area_responsable, :p_usuario_asignado, :p_estado, :p_fecha_respuesta, :p_respuesta, :p_documento_respuesta); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_numero_notificacion", (object?)m.NumeroNotificacion ?? DBNull.Value),
                new OracleParameter("p_remitente_nombre", (object?)m.RemitenteNombre ?? DBNull.Value),
                new OracleParameter("p_remitente_tipo", (object?)m.RemitenteTipo ?? DBNull.Value),
                new OracleParameter("p_destinatario_interno", (object?)m.DestinatarioInterno ?? DBNull.Value),
                new OracleParameter("p_asunto", (object?)m.Asunto ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_fecha_recepcion", (object?)m.FechaRecepcion ?? DBNull.Value),
                new OracleParameter("p_fecha_respuesta_requerida", (object?)m.FechaRespuestaRequerida ?? DBNull.Value),
                new OracleParameter("p_prioridad", (object?)m.Prioridad ?? DBNull.Value),
                new OracleParameter("p_documento_recibido", OracleDbType.Blob) { Value = (object?)m.DocumentoRecibido ?? DBNull.Value },
                new OracleParameter("p_area_responsable", (object?)m.AreaResponsable ?? DBNull.Value),
                new OracleParameter("p_usuario_asignado", (object?)m.UsuarioAsignado ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_fecha_respuesta", (object?)m.FechaRespuesta ?? DBNull.Value),
                new OracleParameter("p_respuesta", (object?)m.Respuesta ?? DBNull.Value),
                new OracleParameter("p_documento_respuesta", OracleDbType.Blob) { Value = (object?)m.DocumentoRespuesta ?? DBNull.Value }
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar NotificacionesLegales: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, NotificacionesLegales m)
        {
            try
            {
                string sql = "BEGIN pkg_notificaciones_legales.update_notificacion(:p_id_notificacion_legal, :p_numero_notificacion, :p_remitente_nombre, :p_remitente_tipo, :p_destinatario_interno, :p_asunto, :p_descripcion, :p_fecha_recepcion, :p_fecha_respuesta_requerida, :p_prioridad, :p_documento_recibido, :p_area_responsable, :p_usuario_asignado, :p_estado, :p_fecha_respuesta, :p_respuesta, :p_documento_respuesta); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_notificacion_legal", id),
                new OracleParameter("p_numero_notificacion", (object?)m.NumeroNotificacion ?? DBNull.Value),
                new OracleParameter("p_remitente_nombre", (object?)m.RemitenteNombre ?? DBNull.Value),
                new OracleParameter("p_remitente_tipo", (object?)m.RemitenteTipo ?? DBNull.Value),
                new OracleParameter("p_destinatario_interno", (object?)m.DestinatarioInterno ?? DBNull.Value),
                new OracleParameter("p_asunto", (object?)m.Asunto ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_fecha_recepcion", (object?)m.FechaRecepcion ?? DBNull.Value),
                new OracleParameter("p_fecha_respuesta_requerida", (object?)m.FechaRespuestaRequerida ?? DBNull.Value),
                new OracleParameter("p_prioridad", (object?)m.Prioridad ?? DBNull.Value),
                new OracleParameter("p_documento_recibido", OracleDbType.Blob) { Value = (object?)m.DocumentoRecibido ?? DBNull.Value },
                new OracleParameter("p_area_responsable", (object?)m.AreaResponsable ?? DBNull.Value),
                new OracleParameter("p_usuario_asignado", (object?)m.UsuarioAsignado ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_fecha_respuesta", (object?)m.FechaRespuesta ?? DBNull.Value),
                new OracleParameter("p_respuesta", (object?)m.Respuesta ?? DBNull.Value),
                new OracleParameter("p_documento_respuesta", OracleDbType.Blob) { Value = (object?)m.DocumentoRespuesta ?? DBNull.Value }
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar NotificacionesLegales: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_notificaciones_legales.delete_notificacion(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar NotificacionesLegales: {ex.Message}"); return false; }
        }
    }
}
