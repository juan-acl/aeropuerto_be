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
        public async Task<ChecklistMantenimiento?> ObtenerPorId(int id) => await _context.CHECKLISTS_MANTENIMIENTO.FindAsync(id);

        public async Task<bool> Insertar(ChecklistMantenimiento m)
        {
            try
            {
                string sql = "BEGIN pkg_checklists_mantenimiento.insert_checklist_mantenimiento(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT CHECKLIST_MANTENIMIENTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(ChecklistMantenimiento m)
        {
            try
            {
                string sql = "BEGIN pkg_checklists_mantenimiento.update_checklist_mantenimiento(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE CHECKLIST_MANTENIMIENTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_checklists_mantenimiento.delete_checklist_mantenimiento(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE CHECKLIST_MANTENIMIENTO: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(ChecklistMantenimiento m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_checklist),
            new OracleParameter("p2", (object?)m.id_modelo_avion ?? DBNull.Value),
            new OracleParameter("p3", (object?)m.codigo_checklist ?? DBNull.Value),
            new OracleParameter("p4", (object?)m.nombre_checklist ?? DBNull.Value),
            new OracleParameter("p5", (object?)m.tipo_mantenimiento ?? DBNull.Value),
            new OracleParameter("p6", (object?)m.frecuencia_horas_vuelo ?? DBNull.Value),
            new OracleParameter("p7", (object?)m.frecuencia_dias ?? DBNull.Value),
            new OracleParameter("p8", (object?)m.tiempo_estimado_minutos ?? DBNull.Value),
            new OracleParameter("p9", (object?)m.requiere_herramientas_especiales ?? DBNull.Value),
            new OracleParameter("p10", (object?)m.requiere_certificacion ?? DBNull.Value),
            new OracleParameter("p11", (object?)m.activo ?? DBNull.Value)
        };
    }
}