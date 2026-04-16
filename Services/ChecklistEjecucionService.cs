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

        public async Task<bool> Insertar(ChecklistEjecucion m)
        {
            try {
                string sql = "BEGIN pkg_checklist_ejecucion.insert_ejecucion(:p_ord, :p_chk, :p_fec, :p_tec); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_ord", m.IdOrdenMant),
                    new OracleParameter("p_chk", m.IdChecklist),
                    new OracleParameter("p_fec", m.FechaEjecucion),
                    new OracleParameter("p_tec", m.TecnicoResponsable)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}