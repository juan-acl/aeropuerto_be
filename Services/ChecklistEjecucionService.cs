using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ChecklistEjecucionService : IChecklistEjecucionService
    {
        private readonly DBContext _context;
        public ChecklistEjecucionService(DBContext context) => _context = context;

        public async Task<List<ChecklistEjecucion>> ListarTodo() => await _context.CHECKLIST_EJECUCION.ToListAsync();
        public async Task<ChecklistEjecucion?> ObtenerPorId(int id) => await _context.CHECKLIST_EJECUCION.FindAsync(id);

        public async Task<bool> Insertar(ChecklistEjecucion m)
        {
            try
            {
                string sql = "BEGIN pkg_checklist_ejecucion.insert_checklist_ejecucion(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT CHECKLIST_EJECUCION: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(ChecklistEjecucion m)
        {
            try
            {
                string sql = "BEGIN pkg_checklist_ejecucion.update_checklist_ejecucion(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE CHECKLIST_EJECUCION: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_checklist_ejecucion.delete_checklist_ejecucion(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE CHECKLIST_EJECUCION: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(ChecklistEjecucion m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_ejecucion),
            new OracleParameter("p2", (object?)m.id_orden_mp ?? DBNull.Value),
            new OracleParameter("p3", (object?)m.id_checklist ?? DBNull.Value),
            new OracleParameter("p4", (object?)m.fecha_inicio ?? DBNull.Value),
            new OracleParameter("p5", (object?)m.fecha_fin ?? DBNull.Value),
            new OracleParameter("p6", (object?)m.tecnico_ejecutor ?? DBNull.Value),
            new OracleParameter("p7", (object?)m.supervisor ?? DBNull.Value),
            new OracleParameter("p8", (object?)m.resultado ?? DBNull.Value),
            new OracleParameter("p9", (object?)m.observaciones ?? DBNull.Value)
        };
    }
}