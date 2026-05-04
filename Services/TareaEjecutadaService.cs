using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TareaEjecutadaService : ITareaEjecutadaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TareaEjecutadaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TareaEjecutada>> ListarTodo()
        {
            try { return await _replica.TAREAS_EJECUTADAS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TareaEjecutada: {ex.Message}"); return new List<TareaEjecutada>(); }
        }

        public async Task<TareaEjecutada ?> ObtenerPorId(int id)
        {
            try { return await _replica.TAREAS_EJECUTADAS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TareaEjecutada: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TareaEjecutada m)
        {
            try
            {
                string sql = "BEGIN pkg_tareas_ejecutadas.insert_tarea(:p_id_ejecucion, :p_id_tarea, :p_fecha_ejecucion, :p_tiempo_real_minutos, :p_resultados_medicion, :p_conforme, :p_observaciones_tarea); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_ejecucion", m.IdEjecucion),
                    new OracleParameter("p_id_tarea", DBNull.Value),
                    new OracleParameter("p_fecha_ejecucion", DBNull.Value),
                    new OracleParameter("p_tiempo_real_minutos", DBNull.Value),
                    new OracleParameter("p_resultados_medicion", DBNull.Value),
                    new OracleParameter("p_conforme", DBNull.Value),
                    new OracleParameter("p_observaciones_tarea", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar TareaEjecutada: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, TareaEjecutada m)
        {
            try
            {
                string sql = "BEGIN pkg_tareas_ejecutadas.update_tarea(:p_id_tarea_ejecutada, :p_id_ejecucion, :p_id_tarea, :p_fecha_ejecucion, :p_tiempo_real_minutos, :p_resultados_medicion, :p_conforme, :p_observaciones_tarea); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_tarea_ejecutada", id),
                    new OracleParameter("p_id_ejecucion", m.IdEjecucion),
                    new OracleParameter("p_id_tarea", DBNull.Value),
                    new OracleParameter("p_fecha_ejecucion", DBNull.Value),
                    new OracleParameter("p_tiempo_real_minutos", DBNull.Value),
                    new OracleParameter("p_resultados_medicion", DBNull.Value),
                    new OracleParameter("p_conforme", DBNull.Value),
                    new OracleParameter("p_observaciones_tarea", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar TareaEjecutada: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_tareas_ejecutadas.delete_tarea(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar TareaEjecutada: {ex.Message}"); throw; }
        }
    }
}
