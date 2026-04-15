using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class SerieVueloService  : ISerieVueloAsignadaService
    {
        private readonly DBContext _context;
        public SerieVueloService(DBContext context) => _context = context;

        public async Task<bool> Insertar(SeriesVueloAsignadas m)
        {
            var p = new[] {
                new OracleParameter("p_id_pais_oaci", (object?)m.IdPaisOaci ?? DBNull.Value),
                new OracleParameter("p_id_aerolinea", (object?)m.IdAerolinea ?? DBNull.Value),
                new OracleParameter("p_rango_numeros_inicio", (object?)m.RangoNumerosInicio ?? DBNull.Value),
                new OracleParameter("p_rango_numeros_fin", (object?)m.RangoNumerosFin ?? DBNull.Value),
                new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                new OracleParameter("p_documento_asignacion", (object?)m.DocumentoAsignacion ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_series_vuelo.insert_serie(:p_id_pais_oaci, :p_id_aerolinea, :p_rango_numeros_inicio, :p_rango_numeros_fin, :p_fecha_asignacion, :p_fecha_vencimiento, :p_activa, :p_documento_asignacion); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, SeriesVueloAsignadas m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_serie_vuelo", m.IdSerieVuelo)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_pais_oaci", (object?)m.IdPaisOaci ?? DBNull.Value),
                new OracleParameter("p_id_aerolinea", (object?)m.IdAerolinea ?? DBNull.Value),
                new OracleParameter("p_rango_numeros_inicio", (object?)m.RangoNumerosInicio ?? DBNull.Value),
                new OracleParameter("p_rango_numeros_fin", (object?)m.RangoNumerosFin ?? DBNull.Value),
                new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                new OracleParameter("p_documento_asignacion", (object?)m.DocumentoAsignacion ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_series_vuelo.update_serie(:p_id_serie_vuelo, :p_id_pais_oaci, :p_id_aerolinea, :p_rango_numeros_inicio, :p_rango_numeros_fin, :p_fecha_asignacion, :p_fecha_vencimiento, :p_activa, :p_documento_asignacion); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_series_vuelo.delete_serie(:p_id_serie_vuelo); END;", 
                new OracleParameter("p_id_serie_vuelo", id));
            return true;
        }

        public async Task<List<SeriesVueloAsignadas>> ListarTodo() => await _context.Set<SeriesVueloAsignadas>().ToListAsync();

        public async Task<SeriesVueloAsignadas?> ObtenerPorId(int id) => await _context.Set<SeriesVueloAsignadas>().FindAsync(id);
    }
}
