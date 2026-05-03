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

        public async Task<List<EvaluacionDesempeno>> ListarTodo() => await _context.EVALUACIONES_DESEMPENO.ToListAsync();
        public async Task<EvaluacionDesempeno?> ObtenerPorId(int id) => await _context.EVALUACIONES_DESEMPENO.FindAsync(id);

        public async Task<bool> Insertar(EvaluacionDesempeno m)
        {
            try
            {
                string sql = "BEGIN pkg_evaluaciones_desempeno.insert_evaluacion(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT EVALUACION: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(EvaluacionDesempeno m)
        {
            try
            {
                string sql = "BEGIN pkg_evaluaciones_desempeno.update_evaluacion(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE EVALUACION: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_evaluaciones_desempeno.delete_evaluacion(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE EVALUACION: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(EvaluacionDesempeno m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_evaluacion),
            new OracleParameter("p2",  m.id_empleado),
            new OracleParameter("p3",  m.fecha_evaluacion),
            new OracleParameter("p4",  m.evaluador_id),
            new OracleParameter("p5",  m.periodo_evaluado),
            new OracleParameter("p6",  m.puntuacion_total),
            new OracleParameter("p7",  m.puntuacion_productividad),
            new OracleParameter("p8",  m.puntuacion_calidad),
            new OracleParameter("p9",  m.puntuacion_asistencia),
            new OracleParameter("p10", m.puntuacion_trabajo_equipo),
            new OracleParameter("p11", m.comentarios),
            new OracleParameter("p12", m.metas_futuras)
        };
    }
}