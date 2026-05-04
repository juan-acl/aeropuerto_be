using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class SeriesVueloAsignadasService : ISeriesVueloAsignadasService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public SeriesVueloAsignadasService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<SeriesVueloAsignadas>> ListarTodo()
        {
            try { return await _replica.SeriesVueloAsignadas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo SeriesVueloAsignadas: {ex.Message}"); return new List<SeriesVueloAsignadas>(); }
        }

        public async Task<SeriesVueloAsignadas ?> ObtenerPorId(int id)
        {
            try { return await _replica.SeriesVueloAsignadas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId SeriesVueloAsignadas: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(SeriesVueloAsignadas m)
        {
            try
            {
                string sql = "BEGIN pkg_series_vuelo.insert_serie(:p_id_pais_oaci, :p_id_aerolinea, :p_rango_numeros_inicio, :p_rango_numeros_fin, :p_fecha_asignacion, :p_fecha_vencimiento, :p_activa, :p_documento_asignacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pais_oaci", m.IdPaisOaci),
                    new OracleParameter("p_id_aerolinea", m.IdAerolinea),
                    new OracleParameter("p_rango_numeros_inicio", (object?)m.RangoNumerosInicio ?? DBNull.Value),
                    new OracleParameter("p_rango_numeros_fin", (object?)m.RangoNumerosFin ?? DBNull.Value),
                    new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                    new OracleParameter("p_documento_asignacion", (object?)m.DocumentoAsignacion ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar SeriesVueloAsignadas: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, SeriesVueloAsignadas m)
        {
            try
            {
                string sql = "BEGIN pkg_series_vuelo.update_serie(:p_id_serie_vuelo, :p_id_pais_oaci, :p_id_aerolinea, :p_rango_numeros_inicio, :p_rango_numeros_fin, :p_fecha_asignacion, :p_fecha_vencimiento, :p_activa, :p_documento_asignacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_serie_vuelo", id),
                    new OracleParameter("p_id_pais_oaci", m.IdPaisOaci),
                    new OracleParameter("p_id_aerolinea", m.IdAerolinea),
                    new OracleParameter("p_rango_numeros_inicio", (object?)m.RangoNumerosInicio ?? DBNull.Value),
                    new OracleParameter("p_rango_numeros_fin", (object?)m.RangoNumerosFin ?? DBNull.Value),
                    new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                    new OracleParameter("p_documento_asignacion", (object?)m.DocumentoAsignacion ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar SeriesVueloAsignadas: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_series_vuelo.delete_serie(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar SeriesVueloAsignadas: {ex.Message}"); throw; }
        }
    }
}
