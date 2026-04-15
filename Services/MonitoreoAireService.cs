using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class MonitoreoAireService : IMonitoreoAireService
    {
        private readonly DBContext _context;

        public MonitoreoAireService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(MonitoreoAire m)
        {
            var parametros = new[]
            {
                new OracleParameter("p_id_estacion_ambiental",          (object?)m.IdEstacionAmbiental          ?? DBNull.Value),
                new OracleParameter("p_fecha_hora_medicion",            (object?)m.FechaHoraMedicion            ?? DBNull.Value),
                new OracleParameter("p_co2_ppm",                        (object?)m.Co2Ppm                       ?? DBNull.Value),
                new OracleParameter("p_co_ppm",                         (object?)m.CoPpm                        ?? DBNull.Value),
                new OracleParameter("p_nox_ppm",                        (object?)m.NoxPpm                       ?? DBNull.Value),
                new OracleParameter("p_so2_ppm",                        (object?)m.So2Ppm                       ?? DBNull.Value),
                new OracleParameter("p_particulas_pm10",                (object?)m.ParticulasPm10               ?? DBNull.Value),
                new OracleParameter("p_particulas_pm25",                (object?)m.ParticulasPm25               ?? DBNull.Value),
                new OracleParameter("p_compuestos_organicos_volatiles", (object?)m.CompuestosOrganicosVolatiles  ?? DBNull.Value),
                new OracleParameter("p_temperatura_ambiente",           (object?)m.TemperaturaAmbiente          ?? DBNull.Value),
                new OracleParameter("p_humedad_relativa",               (object?)m.HumedadRelativa              ?? DBNull.Value),
                new OracleParameter("p_presion_atmosferica",            (object?)m.PresionAtmosferica           ?? DBNull.Value),
                new OracleParameter("p_velocidad_viento",               (object?)m.VelocidadViento              ?? DBNull.Value),
                new OracleParameter("p_direccion_viento",               (object?)m.DireccionViento              ?? DBNull.Value),
                new OracleParameter("p_indice_calidad_aire",            (object?)m.IndiceCalidadAire            ?? DBNull.Value),
                new OracleParameter("p_alerta_generada",                (object?)m.AlertaGenerada               ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_monitoreo_aire.insert_medicion_aire(" +
                         ":p_id_estacion_ambiental, :p_fecha_hora_medicion, :p_co2_ppm, :p_co_ppm, " +
                         ":p_nox_ppm, :p_so2_ppm, :p_particulas_pm10, :p_particulas_pm25, " +
                         ":p_compuestos_organicos_volatiles, :p_temperatura_ambiente, :p_humedad_relativa, " +
                         ":p_presion_atmosferica, :p_velocidad_viento, :p_direccion_viento, " +
                         ":p_indice_calidad_aire, :p_alerta_generada); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, MonitoreoAire m)
        {
            var parametros = new[]
            {
                new OracleParameter("p_id_medicion_aire",               id),
                new OracleParameter("p_id_estacion_ambiental",          (object?)m.IdEstacionAmbiental          ?? DBNull.Value),
                new OracleParameter("p_fecha_hora_medicion",            (object?)m.FechaHoraMedicion            ?? DBNull.Value),
                new OracleParameter("p_co2_ppm",                        (object?)m.Co2Ppm                       ?? DBNull.Value),
                new OracleParameter("p_co_ppm",                         (object?)m.CoPpm                        ?? DBNull.Value),
                new OracleParameter("p_nox_ppm",                        (object?)m.NoxPpm                       ?? DBNull.Value),
                new OracleParameter("p_so2_ppm",                        (object?)m.So2Ppm                       ?? DBNull.Value),
                new OracleParameter("p_particulas_pm10",                (object?)m.ParticulasPm10               ?? DBNull.Value),
                new OracleParameter("p_particulas_pm25",                (object?)m.ParticulasPm25               ?? DBNull.Value),
                new OracleParameter("p_compuestos_organicos_volatiles", (object?)m.CompuestosOrganicosVolatiles  ?? DBNull.Value),
                new OracleParameter("p_temperatura_ambiente",           (object?)m.TemperaturaAmbiente          ?? DBNull.Value),
                new OracleParameter("p_humedad_relativa",               (object?)m.HumedadRelativa              ?? DBNull.Value),
                new OracleParameter("p_presion_atmosferica",            (object?)m.PresionAtmosferica           ?? DBNull.Value),
                new OracleParameter("p_velocidad_viento",               (object?)m.VelocidadViento              ?? DBNull.Value),
                new OracleParameter("p_direccion_viento",               (object?)m.DireccionViento              ?? DBNull.Value),
                new OracleParameter("p_indice_calidad_aire",            (object?)m.IndiceCalidadAire            ?? DBNull.Value),
                new OracleParameter("p_alerta_generada",                (object?)m.AlertaGenerada               ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_monitoreo_aire.update_medicion_aire(" +
                         ":p_id_medicion_aire, :p_id_estacion_ambiental, :p_fecha_hora_medicion, " +
                         ":p_co2_ppm, :p_co_ppm, :p_nox_ppm, :p_so2_ppm, :p_particulas_pm10, " +
                         ":p_particulas_pm25, :p_compuestos_organicos_volatiles, :p_temperatura_ambiente, " +
                         ":p_humedad_relativa, :p_presion_atmosferica, :p_velocidad_viento, " +
                         ":p_direccion_viento, :p_indice_calidad_aire, :p_alerta_generada); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            string sql = "BEGIN pkg_monitoreo_aire.delete_medicion_aire(:p_id_medicion_aire); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_medicion_aire", id));
            return true;
        }

        public async Task<List<MonitoreoAire>> ListarTodo() =>
            await _context.Set<MonitoreoAire>().ToListAsync();

        public async Task<MonitoreoAire?> ObtenerPorId(int id) =>
            await _context.Set<MonitoreoAire>().FindAsync((decimal)id);
    }
}
