using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class IncidenteVueloService : IIncidenteVueloService
    {
        private readonly DBContext _context;
        public IncidenteVueloService(DBContext context) => _context = context;

        public async Task<List<IncidenteVueloModel>> ListarTodo()
        {
            try { return await _context.IncidentesVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo IncidenteVueloModel: {ex.Message}"); return new List<IncidenteVueloModel>(); }
        }

        public async Task<IncidenteVueloModel?> ObtenerPorId(int id)
        {
            try { return await _context.IncidentesVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId IncidenteVueloModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(IncidenteVueloModel m)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes_vuelo.insert_incidente(:p_id_vuelo, :p_fecha_incidente, :p_tipo_incidente, :p_descripcion, :p_gravedad, :p_acciones_tomadas, :p_reportado_por); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_vuelo", m.IdVuelo),
                new OracleParameter("p_fecha_incidente", (object?)m.FechaIncidente ?? DBNull.Value),
                new OracleParameter("p_tipo_incidente", (object?)m.TipoIncidente ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_gravedad", (object?)m.Gravedad ?? DBNull.Value),
                new OracleParameter("p_acciones_tomadas", (object?)m.AccionesTomadas ?? DBNull.Value),
                new OracleParameter("p_reportado_por", (object?)m.ReportadoPor ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar IncidenteVueloModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, IncidenteVueloModel m)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes_vuelo.update_incidente(:p_id_incidente_vuelo, :p_id_vuelo, :p_fecha_incidente, :p_tipo_incidente, :p_descripcion, :p_gravedad, :p_acciones_tomadas, :p_reportado_por); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_incidente_vuelo", id),
                new OracleParameter("p_id_vuelo", m.IdVuelo),
                new OracleParameter("p_fecha_incidente", (object?)m.FechaIncidente ?? DBNull.Value),
                new OracleParameter("p_tipo_incidente", (object?)m.TipoIncidente ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_gravedad", (object?)m.Gravedad ?? DBNull.Value),
                new OracleParameter("p_acciones_tomadas", (object?)m.AccionesTomadas ?? DBNull.Value),
                new OracleParameter("p_reportado_por", (object?)m.ReportadoPor ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar IncidenteVueloModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes_vuelo.delete_incidente(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar IncidenteVueloModel: {ex.Message}"); return false; }
        }
    }
}
