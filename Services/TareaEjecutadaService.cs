using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class TareaEjecutadaService : ITareaEjecutadaService
    {
        private readonly DBContext _context;
        public TareaEjecutadaService(DBContext context) => _context = context;

        public async Task<List<TareaEjecutada>> ListarTodo() => await _context.TAREAS_EJECUTADAS.ToListAsync();
        public async Task<TareaEjecutada?> ObtenerPorId(int id) => await _context.TAREAS_EJECUTADAS.FindAsync(id);

        public async Task<bool> Insertar(TareaEjecutada m)
        {
            try
            {
                string sql = "BEGIN pkg_tareas_ejecutadas.insert_tarea_ejecutada(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT TAREA_EJECUTADA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(TareaEjecutada m)
        {
            try
            {
                string sql = "BEGIN pkg_tareas_ejecutadas.update_tarea_ejecutada(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE TAREA_EJECUTADA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_tareas_ejecutadas.delete_tarea_ejecutada(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE TAREA_EJECUTADA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(TareaEjecutada m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_tarea_ejecutada),
            new OracleParameter("p2", (object?)m.id_ejecucion ?? DBNull.Value),
            new OracleParameter("p3", (object?)m.id_tarea ?? DBNull.Value),
            new OracleParameter("p4", (object?)m.fecha_ejecucion ?? DBNull.Value),
            new OracleParameter("p5", (object?)m.tiempo_real_minutos ?? DBNull.Value),
            new OracleParameter("p6", (object?)m.resultados_medicion ?? DBNull.Value),
            new OracleParameter("p7", (object?)m.conforme ?? DBNull.Value),
            new OracleParameter("p8", (object?)m.observaciones_tarea ?? DBNull.Value)
        };
    }
}