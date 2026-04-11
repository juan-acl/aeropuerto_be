using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ChecklistMantenimientoService : IChecklistMantenimientoService
    {
        private readonly DBContext _context;
        public ChecklistMantenimientoService(DBContext context) => _context = context;

        public async Task<List<ChecklistMantenimiento>> ListarTodo() => await _context.CHECKLISTS_MANTENIMIENTO.ToListAsync();

        public async Task<bool> Insertar(ChecklistMantenimiento m)
        {
            try {
                string sql = "BEGIN pkg_checklists_mantenimiento.insert_checklist(:p_nom, :p_desc, :p_act); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nom", m.NombreChecklist),
                    new OracleParameter("p_desc", m.Descripcion),
                    new OracleParameter("p_act", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}