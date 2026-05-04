using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class SimulacrosService : ISimulacrosService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public SimulacrosService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<Simulacros>> ListarTodo()
        {
            try { return await _replica.Simulacros.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo Simulacros: {ex.Message}"); return new List<Simulacros>(); }
        }

        public async Task<Simulacros ?> ObtenerPorId(int id)
        {
            try { return await _replica.Simulacros.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId Simulacros: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(Simulacros m)
        {
            try
            {
                string sql = "BEGIN pkg_simulacros.insert_simulacro(:p_fecha_simulacro, :p_tipo_simulacro, :p_id_plan_emergencia, :p_alcance, :p_participantes, :p_duracion_horas, :p_objetivos, :p_resultados, :p_observaciones, :p_evaluacion, :p_coordinador, :p_fecha_proximo_simulacro); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_fecha_simulacro", m.FechaSimulacro),
                    new OracleParameter("p_tipo_simulacro", (object?)m.TipoSimulacro ?? DBNull.Value),
                    new OracleParameter("p_id_plan_emergencia", (object?)m.IdPlanEmergencia ?? DBNull.Value),
                    new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                    new OracleParameter("p_participantes", (object?)m.Participantes ?? DBNull.Value),
                    new OracleParameter("p_duracion_horas", (object?)m.DuracionHoras ?? DBNull.Value),
                    new OracleParameter("p_objetivos", (object?)m.Objetivos ?? DBNull.Value),
                    new OracleParameter("p_resultados", (object?)m.Resultados ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
                    new OracleParameter("p_evaluacion", (object?)m.Evaluacion ?? DBNull.Value),
                    new OracleParameter("p_coordinador", (object?)m.Coordinador ?? DBNull.Value),
                    new OracleParameter("p_fecha_proximo_simulacro", (object?)m.FechaProximoSimulacro ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar Simulacros: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, Simulacros m)
        {
            try
            {
                string sql = "BEGIN pkg_simulacros.update_simulacro(:p_id_simulacro, :p_fecha_simulacro, :p_tipo_simulacro, :p_id_plan_emergencia, :p_alcance, :p_participantes, :p_duracion_horas, :p_objetivos, :p_resultados, :p_observaciones, :p_evaluacion, :p_coordinador, :p_fecha_proximo_simulacro); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_simulacro", id),
                    new OracleParameter("p_fecha_simulacro", m.FechaSimulacro),
                    new OracleParameter("p_tipo_simulacro", (object?)m.TipoSimulacro ?? DBNull.Value),
                    new OracleParameter("p_id_plan_emergencia", (object?)m.IdPlanEmergencia ?? DBNull.Value),
                    new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                    new OracleParameter("p_participantes", (object?)m.Participantes ?? DBNull.Value),
                    new OracleParameter("p_duracion_horas", (object?)m.DuracionHoras ?? DBNull.Value),
                    new OracleParameter("p_objetivos", (object?)m.Objetivos ?? DBNull.Value),
                    new OracleParameter("p_resultados", (object?)m.Resultados ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
                    new OracleParameter("p_evaluacion", (object?)m.Evaluacion ?? DBNull.Value),
                    new OracleParameter("p_coordinador", (object?)m.Coordinador ?? DBNull.Value),
                    new OracleParameter("p_fecha_proximo_simulacro", (object?)m.FechaProximoSimulacro ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar Simulacros: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_simulacros.delete_simulacro(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar Simulacros: {ex.Message}"); throw; }
        }
    }
}
