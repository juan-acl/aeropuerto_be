using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class IncidenteSeguridadService : IIncidenteSeguridadInformaticaService
    {
        private readonly DBContext _context;
        public IncidenteSeguridadService(DBContext context) => _context = context;

        public async Task<bool> Insertar(IncidentesSeguridadInformatica m)
        {
            var p = new[] {
                new OracleParameter("p_fecha_deteccion", (object?)m.FechaDeteccion ?? DBNull.Value),
                new OracleParameter("p_tipo_incidente", (object?)m.TipoIncidente ?? DBNull.Value),
                new OracleParameter("p_nivel_gravedad", (object?)m.NivelGravedad ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_ip_origen", (object?)m.IpOrigen ?? DBNull.Value),
                new OracleParameter("p_usuario_afectado", (object?)m.UsuarioAfectado ?? DBNull.Value),
                new OracleParameter("p_acciones_tomadas", (object?)m.AccionesTomadas ?? DBNull.Value),
                new OracleParameter("p_fecha_resolucion", (object?)m.FechaResolucion ?? DBNull.Value),
                new OracleParameter("p_responsable_resolucion", (object?)m.ResponsableResolucion ?? DBNull.Value),
                new OracleParameter("p_requiere_notificacion_legal", (object?)m.RequiereNotificacionLegal ?? DBNull.Value),
                new OracleParameter("p_notificado_legal", (object?)m.NotificadoLegal ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_incidentes_seguridad.insert_incidente(:p_fecha_deteccion, :p_tipo_incidente, :p_nivel_gravedad, :p_descripcion, :p_ip_origen, :p_usuario_afectado, :p_acciones_tomadas, :p_fecha_resolucion, :p_responsable_resolucion, :p_requiere_notificacion_legal, :p_notificado_legal, :p_estado); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, IncidentesSeguridadInformatica m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_incidente_seguridad_info", m.IdIncidenteSeguridadInfo)
            };
            p.AddRange(new[] {
                new OracleParameter("p_fecha_deteccion", (object?)m.FechaDeteccion ?? DBNull.Value),
                new OracleParameter("p_tipo_incidente", (object?)m.TipoIncidente ?? DBNull.Value),
                new OracleParameter("p_nivel_gravedad", (object?)m.NivelGravedad ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_ip_origen", (object?)m.IpOrigen ?? DBNull.Value),
                new OracleParameter("p_usuario_afectado", (object?)m.UsuarioAfectado ?? DBNull.Value),
                new OracleParameter("p_acciones_tomadas", (object?)m.AccionesTomadas ?? DBNull.Value),
                new OracleParameter("p_fecha_resolucion", (object?)m.FechaResolucion ?? DBNull.Value),
                new OracleParameter("p_responsable_resolucion", (object?)m.ResponsableResolucion ?? DBNull.Value),
                new OracleParameter("p_requiere_notificacion_legal", (object?)m.RequiereNotificacionLegal ?? DBNull.Value),
                new OracleParameter("p_notificado_legal", (object?)m.NotificadoLegal ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_incidentes_seguridad.update_incidente(:p_id_incidente_seguridad_info, :p_fecha_deteccion, :p_tipo_incidente, :p_nivel_gravedad, :p_descripcion, :p_ip_origen, :p_usuario_afectado, :p_acciones_tomadas, :p_fecha_resolucion, :p_responsable_resolucion, :p_requiere_notificacion_legal, :p_notificado_legal, :p_estado); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_incidentes_seguridad.delete_incidente(:p_id_incidente_seguridad_info); END;",
                new OracleParameter("p_id_incidente_seguridad_info", id));
            return true;
        }

        public async Task<List<IncidentesSeguridadInformatica>> ListarTodo() => await _context.Set<IncidentesSeguridadInformatica>().ToListAsync();

        public async Task<IncidentesSeguridadInformatica?> ObtenerPorId(int id) => await _context.Set<IncidentesSeguridadInformatica>().FindAsync(id);
    }
}
