using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class NotificacionLegalService : INotificacionLegalService
    {
        private readonly DBContext _context;
        public NotificacionLegalService(DBContext context) => _context = context;

        public async Task<bool> Insertar(NotificacionesLegales m)
        {
            var p = new[] {
                new OracleParameter("p_numero_notificacion", (object?)m.NumeroNotificacion ?? DBNull.Value),
                new OracleParameter("p_remitente_nombre", (object?)m.RemitenteNombre ?? DBNull.Value),
                new OracleParameter("p_remitente_tipo", (object?)m.RemitenteTipo ?? DBNull.Value),
                new OracleParameter("p_destinatario_interno", (object?)m.DestinatarioInterno ?? DBNull.Value),
                new OracleParameter("p_asunto", (object?)m.Asunto ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_fecha_recepcion", (object?)m.FechaRecepcion ?? DBNull.Value),
                new OracleParameter("p_fecha_respuesta_requerida", (object?)m.FechaRespuestaRequerida ?? DBNull.Value),
                new OracleParameter("p_prioridad", (object?)m.Prioridad ?? DBNull.Value),
                new OracleParameter("p_documento_recibido", (object?)m.DocumentoRecibido ?? DBNull.Value),
                new OracleParameter("p_area_responsable", (object?)m.AreaResponsable ?? DBNull.Value),
                new OracleParameter("p_usuario_asignado", (object?)m.UsuarioAsignado ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_fecha_respuesta", (object?)m.FechaRespuesta ?? DBNull.Value),
                new OracleParameter("p_respuesta", (object?)m.Respuesta ?? DBNull.Value),
                new OracleParameter("p_documento_respuesta", (object?)m.DocumentoRespuesta ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_notificaciones_legales.insert_notificacion(:p_numero_notificacion, :p_remitente_nombre, :p_remitente_tipo, :p_destinatario_interno, :p_asunto, :p_descripcion, :p_fecha_recepcion, :p_fecha_respuesta_requerida, :p_prioridad, :p_documento_recibido, :p_area_responsable, :p_usuario_asignado, :p_estado, :p_fecha_respuesta, :p_respuesta, :p_documento_respuesta); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, NotificacionesLegales m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_notificacion_legal", m.IdNotificacionLegal)
            };
            p.AddRange(new[] {
                new OracleParameter("p_numero_notificacion", (object?)m.NumeroNotificacion ?? DBNull.Value),
                new OracleParameter("p_remitente_nombre", (object?)m.RemitenteNombre ?? DBNull.Value),
                new OracleParameter("p_remitente_tipo", (object?)m.RemitenteTipo ?? DBNull.Value),
                new OracleParameter("p_destinatario_interno", (object?)m.DestinatarioInterno ?? DBNull.Value),
                new OracleParameter("p_asunto", (object?)m.Asunto ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_fecha_recepcion", (object?)m.FechaRecepcion ?? DBNull.Value),
                new OracleParameter("p_fecha_respuesta_requerida", (object?)m.FechaRespuestaRequerida ?? DBNull.Value),
                new OracleParameter("p_prioridad", (object?)m.Prioridad ?? DBNull.Value),
                new OracleParameter("p_documento_recibido", (object?)m.DocumentoRecibido ?? DBNull.Value),
                new OracleParameter("p_area_responsable", (object?)m.AreaResponsable ?? DBNull.Value),
                new OracleParameter("p_usuario_asignado", (object?)m.UsuarioAsignado ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_fecha_respuesta", (object?)m.FechaRespuesta ?? DBNull.Value),
                new OracleParameter("p_respuesta", (object?)m.Respuesta ?? DBNull.Value),
                new OracleParameter("p_documento_respuesta", (object?)m.DocumentoRespuesta ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_notificaciones_legales.update_notificacion(:p_id_notificacion_legal, :p_numero_notificacion, :p_remitente_nombre, :p_remitente_tipo, :p_destinatario_interno, :p_asunto, :p_descripcion, :p_fecha_recepcion, :p_fecha_respuesta_requerida, :p_prioridad, :p_documento_recibido, :p_area_responsable, :p_usuario_asignado, :p_estado, :p_fecha_respuesta, :p_respuesta, :p_documento_respuesta); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_notificaciones_legales.delete_notificacion(:p_id_notificacion_legal); END;", 
                new OracleParameter("p_id_notificacion_legal", id));
            return true;
        }

        public async Task<List<NotificacionesLegales>> ListarTodo() => await _context.Set<NotificacionesLegales>().ToListAsync();

        public async Task<NotificacionesLegales?> ObtenerPorId(int id) => await _context.Set<NotificacionesLegales>().FindAsync(id);
    }
}
