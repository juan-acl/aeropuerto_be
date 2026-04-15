using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class SimulacroService : ISimulacroService
    {
        private readonly DBContext _context;
        public SimulacroService(DBContext context) => _context = context;

        public async Task<bool> Insertar(Simulacros m)
        {
            var p = new[] {
                new OracleParameter("p_fecha_simulacro", (object?)m.FechaSimulacro ?? DBNull.Value),
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
                new OracleParameter("p_fecha_proximo_simulacro", (object?)m.FechaProximoSimulacro ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_simulacros.insert_simulacro(:p_fecha_simulacro, :p_tipo_simulacro, :p_id_plan_emergencia, :p_alcance, :p_participantes, :p_duracion_horas, :p_objetivos, :p_resultados, :p_observaciones, :p_evaluacion, :p_coordinador, :p_fecha_proximo_simulacro); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, Simulacros m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_simulacro", m.IdSimulacro)
            };
            p.AddRange(new[] {
                new OracleParameter("p_fecha_simulacro", (object?)m.FechaSimulacro ?? DBNull.Value),
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
                new OracleParameter("p_fecha_proximo_simulacro", (object?)m.FechaProximoSimulacro ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_simulacros.update_simulacro(:p_id_simulacro, :p_fecha_simulacro, :p_tipo_simulacro, :p_id_plan_emergencia, :p_alcance, :p_participantes, :p_duracion_horas, :p_objetivos, :p_resultados, :p_observaciones, :p_evaluacion, :p_coordinador, :p_fecha_proximo_simulacro); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_simulacros.delete_simulacro(:p_id_simulacro); END;", 
                new OracleParameter("p_id_simulacro", id));
            return true;
        }

        public async Task<List<Simulacros>> ListarTodo() => await _context.Set<Simulacros>().ToListAsync();

        public async Task<Simulacros?> ObtenerPorId(int id) => await _context.Set<Simulacros>().FindAsync(id);
    }
}
