using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class RetrasoVueloService : IRetrasoVueloService
    {
        private readonly DBContext _context;
        public RetrasoVueloService(DBContext context) => _context = context;

        public async Task<List<RetrasoVueloModel>> ListarTodo()
        {
            try { return await _context.RetrasosVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo RetrasoVueloModel: {ex.Message}"); return new List<RetrasoVueloModel>(); }
        }

        public async Task<RetrasoVueloModel?> ObtenerPorId(int id)
        {
            try { return await _context.RetrasosVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId RetrasoVueloModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(RetrasoVueloModel m)
        {
            try
            {
                string sql = "BEGIN pkg_retrasos_vuelo.insert_retraso(:p_id_vuelo, :p_minutos_retraso, :p_tipo_retraso, :p_causa, :p_responsable, :p_compensacion_pasajeros); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_vuelo", m.IdVuelo),
                new OracleParameter("p_minutos_retraso", (object?)m.MinutosRetraso ?? DBNull.Value),
                new OracleParameter("p_tipo_retraso", (object?)m.TipoRetraso ?? DBNull.Value),
                new OracleParameter("p_causa", (object?)m.Causa ?? DBNull.Value),
                new OracleParameter("p_responsable", (object?)m.Responsable ?? DBNull.Value),
                new OracleParameter("p_compensacion_pasajeros", (object?)m.CompensacionPasajeros ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar RetrasoVueloModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, RetrasoVueloModel m)
        {
            try
            {
                string sql = "BEGIN pkg_retrasos_vuelo.update_retraso(:p_id_retraso, :p_id_vuelo, :p_minutos_retraso, :p_tipo_retraso, :p_causa, :p_responsable, :p_compensacion_pasajeros); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_retraso", id),
                new OracleParameter("p_id_vuelo", m.IdVuelo),
                new OracleParameter("p_minutos_retraso", (object?)m.MinutosRetraso ?? DBNull.Value),
                new OracleParameter("p_tipo_retraso", (object?)m.TipoRetraso ?? DBNull.Value),
                new OracleParameter("p_causa", (object?)m.Causa ?? DBNull.Value),
                new OracleParameter("p_responsable", (object?)m.Responsable ?? DBNull.Value),
                new OracleParameter("p_compensacion_pasajeros", (object?)m.CompensacionPasajeros ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar RetrasoVueloModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_retrasos_vuelo.delete_retraso(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar RetrasoVueloModel: {ex.Message}"); return false; }
        }
    }
}
