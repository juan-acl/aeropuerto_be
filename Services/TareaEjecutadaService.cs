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

        public async Task<bool> Insertar(TareaEjecutada m)
        {
            try {
                string sql = "BEGIN pkg_tareas_ejecutadas.insert_tarea(:p_ejec, :p_desc, :p_res, :p_hall); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_ejec", m.IdEjecucion),
                    new OracleParameter("p_desc", m.DescripcionTarea),
                    new OracleParameter("p_res", m.Resultado),
                    new OracleParameter("p_hall", m.Hallazgos ?? (object)DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}