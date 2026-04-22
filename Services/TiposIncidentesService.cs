using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TiposIncidentesService : ITiposIncidentesService
    {
        private readonly DBContext _context;
        public TiposIncidentesService(DBContext context) => _context = context;

        public async Task<List<TiposIncidentesModel>> ListarTodo()
        {
            try { return await _context.TiposIncidentes.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TiposIncidentesModel: {ex.Message}"); return new List<TiposIncidentesModel>(); }
        }

        public async Task<TiposIncidentesModel?> ObtenerPorId(int id)
        {
            try { return await _context.TiposIncidentes.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TiposIncidentesModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TiposIncidentesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_tipos_incidentes.insert_tipo(:p_nombre_tipo, :p_descripcion, :p_protocolo_accion, :p_tiempo_respuesta, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_nombre_tipo", (object?)m.NombreTipo ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_protocolo_accion", (object?)m.ProtocoloAccion ?? DBNull.Value),
                new OracleParameter("p_tiempo_respuesta", DBNull.Value /* TiempoRespuesta */),
                new OracleParameter("p_activo", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar TiposIncidentesModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, TiposIncidentesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_tipos_incidentes.update_tipo(:p_id_tipo_incidente, :p_nombre_tipo, :p_descripcion, :p_protocolo_accion, :p_tiempo_respuesta, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_tipo_incidente", id),
                new OracleParameter("p_nombre_tipo", (object?)m.NombreTipo ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_protocolo_accion", (object?)m.ProtocoloAccion ?? DBNull.Value),
                new OracleParameter("p_tiempo_respuesta", DBNull.Value /* TiempoRespuesta */),
                new OracleParameter("p_activo", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar TiposIncidentesModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_tipos_incidentes.delete_tipo(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar TiposIncidentesModel: {ex.Message}"); return false; }
        }
    }
}
