using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class IncidenteSeguridadService : IIncidenteSeguridadService
    {
        private readonly DBContext _context;
        public IncidenteSeguridadService(DBContext context) => _context = context;

        public async Task<List<IncidentesSeguridadInformatica>> ListarTodo()
        {
            try { return await _context.IncidentesSeguridadInformatica.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo IncidentesSeguridadInformatica: {ex.Message}"); return new List<IncidentesSeguridadInformatica>(); }
        }

        public async Task<IncidentesSeguridadInformatica?> ObtenerPorId(int id)
        {
            try { return await _context.IncidentesSeguridadInformatica.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId IncidentesSeguridadInformatica: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(IncidentesSeguridadInformatica m)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes_seguridad.insert_incidente(:p_fecha_deteccion, :p_tipo_incidente, :p_nivel_gravedad, :p_descripcion, :p_ip_origen, :p_usuario_afectado, :p_acciones_tomadas, :p_fecha_resolucion, :p_responsable_resolucion, :p_requiere_notificacion_legal, :p_notificado_legal, :p_estado); END;";
                var p = new OracleParameter[] {
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
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar IncidentesSeguridadInformatica: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, IncidentesSeguridadInformatica m)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes_seguridad.update_incidente(:p_id_incidente_seguridad_info, :p_fecha_deteccion, :p_tipo_incidente, :p_nivel_gravedad, :p_descripcion, :p_ip_origen, :p_usuario_afectado, :p_acciones_tomadas, :p_fecha_resolucion, :p_responsable_resolucion, :p_requiere_notificacion_legal, :p_notificado_legal, :p_estado); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_incidente_seguridad_info", id),
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
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar IncidentesSeguridadInformatica: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes_seguridad.delete_incidente(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar IncidentesSeguridadInformatica: {ex.Message}"); return false; }
        }
    }
}
