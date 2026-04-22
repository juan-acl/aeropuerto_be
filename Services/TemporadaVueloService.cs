using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TemporadaVueloService : ITemporadaVueloService
    {
        private readonly DBContext _context;
        public TemporadaVueloService(DBContext context) => _context = context;

        public async Task<List<TemporadaVueloModel>> ListarTodo()
        {
            try { return await _context.TemporadasVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TemporadaVueloModel: {ex.Message}"); return new List<TemporadaVueloModel>(); }
        }

        public async Task<TemporadaVueloModel?> ObtenerPorId(int id)
        {
            try { return await _context.TemporadasVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TemporadaVueloModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TemporadaVueloModel m)
        {
            try
            {
                string sql = "BEGIN pkg_temporadas_vuelo.insert_temporada(:p_nombre_temporada, :p_fecha_inicio, :p_fecha_fin, :p_factor_demanda, :p_activa); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_nombre_temporada", (object?)m.NombreTemporada ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_factor_demanda", (object?)m.FactorDemanda ?? DBNull.Value),
                new OracleParameter("p_activa", m.Activa)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar TemporadaVueloModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, TemporadaVueloModel m)
        {
            try
            {
                string sql = "BEGIN pkg_temporadas_vuelo.update_temporada(:p_id_temporada, :p_nombre_temporada, :p_fecha_inicio, :p_fecha_fin, :p_factor_demanda, :p_activa); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_temporada", id),
                new OracleParameter("p_nombre_temporada", (object?)m.NombreTemporada ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_factor_demanda", (object?)m.FactorDemanda ?? DBNull.Value),
                new OracleParameter("p_activa", m.Activa)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar TemporadaVueloModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_temporadas_vuelo.delete_temporada(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar TemporadaVueloModel: {ex.Message}"); return false; }
        }
    }
}
