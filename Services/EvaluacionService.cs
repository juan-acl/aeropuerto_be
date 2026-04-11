using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EvaluacionService : IEvaluacionService
    {
        private readonly DBContext _context;
        public EvaluacionService(DBContext context) => _context = context;

        public async Task<List<EvaluacionDesempeno>> ListarTodo() => 
            await _context.EVALUACIONES_DESEMPENO.ToListAsync();

        public async Task<bool> Insertar(EvaluacionDesempeno m)
        {
            try
            {
                string sql = @"BEGIN pkg_evaluaciones_desempeno.insert_evaluacion(
                    :p_id_emp, :p_fec, :p_eval_id, :p_per, :p_total, :p_prod, :p_cal, :p_asist, :p_equipo, :p_coment, :p_metas); END;";
                
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_emp", m.IdEmpleado),
                    new OracleParameter("p_fec", m.FechaEvaluacion),
                    new OracleParameter("p_eval_id", m.EvaluadorId),
                    new OracleParameter("p_per", m.PeriodoEvaluado),
                    new OracleParameter("p_total", m.PuntuacionTotal),
                    new OracleParameter("p_prod", m.PuntuacionProductividad),
                    new OracleParameter("p_cal", m.PuntuacionCalidad),
                    new OracleParameter("p_asist", m.PuntuacionAsistencia),
                    new OracleParameter("p_equipo", m.PuntuacionTrabajoEquipo),
                    new OracleParameter("p_coment", m.Comentarios),
                    new OracleParameter("p_metas", m.MetasFuturas)
                };

                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR EVALUACION: {ex.Message}");
                return false;
            }
        }
    }
}