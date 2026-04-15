using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class MonitoreoRuidoService : IMonitoreoRuidoService
    {
        private readonly DBContext _context;

        public MonitoreoRuidoService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(MonitoreoRuido m)
        {
            var parametros = new[]
            {
                new OracleParameter("p_id_estacion_ambiental",   (object?)m.IdEstacionAmbiental   ?? DBNull.Value),
                new OracleParameter("p_fecha_hora_medicion",     (object?)m.FechaHoraMedicion     ?? DBNull.Value),
                new OracleParameter("p_nivel_ruido_continua_db", (object?)m.NivelRuidoContinuaDb  ?? DBNull.Value),
                new OracleParameter("p_nivel_ruido_maximo_db",   (object?)m.NivelRuidoMaximoDb    ?? DBNull.Value),
                new OracleParameter("p_nivel_ruido_minimo_db",   (object?)m.NivelRuidoMinimoDb    ?? DBNull.Value),
                new OracleParameter("p_frecuencia_hz",           (object?)m.FrecuenciaHz          ?? DBNull.Value),
                new OracleParameter("p_duracion_segundos",       (object?)m.DuracionSegundos      ?? DBNull.Value),
                new OracleParameter("p_id_vuelo_asociado",       (object?)m.IdVueloAsociado       ?? DBNull.Value),
                new OracleParameter("p_tipo_fuente",             (object?)m.TipoFuente            ?? DBNull.Value),
                new OracleParameter("p_excede_limite",           (object?)m.ExcedeLimite          ?? DBNull.Value),
                new OracleParameter("p_alerta_generada",         (object?)m.AlertaGenerada        ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_monitoreo_ruido.insert_medicion_ruido(" +
                         ":p_id_estacion_ambiental, :p_fecha_hora_medicion, :p_nivel_ruido_continua_db, " +
                         ":p_nivel_ruido_maximo_db, :p_nivel_ruido_minimo_db, :p_frecuencia_hz, " +
                         ":p_duracion_segundos, :p_id_vuelo_asociado, :p_tipo_fuente, " +
                         ":p_excede_limite, :p_alerta_generada); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, MonitoreoRuido m)
        {
            var parametros = new[]
            {
                new OracleParameter("p_id_medicion_ruido",       id),
                new OracleParameter("p_id_estacion_ambiental",   (object?)m.IdEstacionAmbiental   ?? DBNull.Value),
                new OracleParameter("p_fecha_hora_medicion",     (object?)m.FechaHoraMedicion     ?? DBNull.Value),
                new OracleParameter("p_nivel_ruido_continua_db", (object?)m.NivelRuidoContinuaDb  ?? DBNull.Value),
                new OracleParameter("p_nivel_ruido_maximo_db",   (object?)m.NivelRuidoMaximoDb    ?? DBNull.Value),
                new OracleParameter("p_nivel_ruido_minimo_db",   (object?)m.NivelRuidoMinimoDb    ?? DBNull.Value),
                new OracleParameter("p_frecuencia_hz",           (object?)m.FrecuenciaHz          ?? DBNull.Value),
                new OracleParameter("p_duracion_segundos",       (object?)m.DuracionSegundos      ?? DBNull.Value),
                new OracleParameter("p_id_vuelo_asociado",       (object?)m.IdVueloAsociado       ?? DBNull.Value),
                new OracleParameter("p_tipo_fuente",             (object?)m.TipoFuente            ?? DBNull.Value),
                new OracleParameter("p_excede_limite",           (object?)m.ExcedeLimite          ?? DBNull.Value),
                new OracleParameter("p_alerta_generada",         (object?)m.AlertaGenerada        ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_monitoreo_ruido.update_medicion_ruido(" +
                         ":p_id_medicion_ruido, :p_id_estacion_ambiental, :p_fecha_hora_medicion, " +
                         ":p_nivel_ruido_continua_db, :p_nivel_ruido_maximo_db, :p_nivel_ruido_minimo_db, " +
                         ":p_frecuencia_hz, :p_duracion_segundos, :p_id_vuelo_asociado, " +
                         ":p_tipo_fuente, :p_excede_limite, :p_alerta_generada); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            string sql = "BEGIN pkg_monitoreo_ruido.delete_medicion_ruido(:p_id_medicion_ruido); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_medicion_ruido", id));
            return true;
        }

        public async Task<List<MonitoreoRuido>> ListarTodo() =>
            await _context.Set<MonitoreoRuido>().ToListAsync();

        public async Task<MonitoreoRuido?> ObtenerPorId(int id) =>
            await _context.Set<MonitoreoRuido>().FindAsync(id);
    }
}
