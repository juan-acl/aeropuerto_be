using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class IndicadoresDesempenoAmbientalService : IIndicadoresDesempenoAmbientalService
    {
        private readonly DBContext _context;

        public IndicadoresDesempenoAmbientalService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(IndicadoresDesempenoAmbiental m)
        {
            var parametros = new[]
            {
                new OracleParameter("p_anio",                    (object?)m.Anio                   ?? DBNull.Value),
                new OracleParameter("p_mes",                     (object?)m.Mes                    ?? DBNull.Value),
                new OracleParameter("p_indicador",               (object?)m.Indicador              ?? DBNull.Value),
                new OracleParameter("p_valor_medido",            (object?)m.ValorMedido            ?? DBNull.Value),
                new OracleParameter("p_unidad_medida",           (object?)m.UnidadMedida           ?? DBNull.Value),
                new OracleParameter("p_valor_objetivo",          (object?)m.ValorObjetivo          ?? DBNull.Value),
                new OracleParameter("p_cumplimiento_porcentaje", (object?)m.CumplimientoPorcentaje ?? DBNull.Value),
                new OracleParameter("p_tendencia",               (object?)m.Tendencia              ?? DBNull.Value),
                new OracleParameter("p_observaciones",           (object?)m.Observaciones          ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_indicadores_desempeno_ambiental.insert_indicador(" +
                         ":p_anio, :p_mes, :p_indicador, :p_valor_medido, :p_unidad_medida, " +
                         ":p_valor_objetivo, :p_cumplimiento_porcentaje, :p_tendencia, :p_observaciones); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, IndicadoresDesempenoAmbiental m)
        {
            var parametros = new[]
            {
                new OracleParameter("p_id_indicador_ambiental",  id),
                new OracleParameter("p_anio",                    (object?)m.Anio                   ?? DBNull.Value),
                new OracleParameter("p_mes",                     (object?)m.Mes                    ?? DBNull.Value),
                new OracleParameter("p_indicador",               (object?)m.Indicador              ?? DBNull.Value),
                new OracleParameter("p_valor_medido",            (object?)m.ValorMedido            ?? DBNull.Value),
                new OracleParameter("p_unidad_medida",           (object?)m.UnidadMedida           ?? DBNull.Value),
                new OracleParameter("p_valor_objetivo",          (object?)m.ValorObjetivo          ?? DBNull.Value),
                new OracleParameter("p_cumplimiento_porcentaje", (object?)m.CumplimientoPorcentaje ?? DBNull.Value),
                new OracleParameter("p_tendencia",               (object?)m.Tendencia              ?? DBNull.Value),
                new OracleParameter("p_observaciones",           (object?)m.Observaciones          ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_indicadores_desempeno_ambiental.update_indicador(" +
                         ":p_id_indicador_ambiental, :p_anio, :p_mes, :p_indicador, :p_valor_medido, " +
                         ":p_unidad_medida, :p_valor_objetivo, :p_cumplimiento_porcentaje, " +
                         ":p_tendencia, :p_observaciones); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            string sql = "BEGIN pkg_indicadores_desempeno_ambiental.delete_indicador(:p_id_indicador_ambiental); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_indicador_ambiental", id));
            return true;
        }

        public async Task<List<IndicadoresDesempenoAmbiental>> ListarTodo() =>
            await _context.Set<IndicadoresDesempenoAmbiental>().ToListAsync();

        public async Task<IndicadoresDesempenoAmbiental?> ObtenerPorId(int id) =>
            await _context.Set<IndicadoresDesempenoAmbiental>().FindAsync(id);
    }
}
