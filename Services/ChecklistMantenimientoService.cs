using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ChecklistMantenimientoService : IChecklistMantenimientoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ChecklistMantenimientoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ChecklistMantenimiento>> ListarTodo()
        {
            try { return await _replica.CHECKLISTS_MANTENIMIENTO.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ChecklistMantenimiento: {ex.Message}"); return new List<ChecklistMantenimiento>(); }
        }

        public async Task<ChecklistMantenimiento ?> ObtenerPorId(int id)
        {
            try { return await _replica.CHECKLISTS_MANTENIMIENTO.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ChecklistMantenimiento: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ChecklistMantenimiento m)
        {
            try
            {
                string sql = "BEGIN pkg_checklists_mantenimiento.insert_checklist(:p_id_modelo_avion, :p_codigo_checklist, :p_nombre_checklist, :p_tipo_mantenimiento, :p_frecuencia_horas_vuelo, :p_frecuencia_dias, :p_tiempo_estimado_minutos, :p_requiere_herramientas_especiales, :p_requiere_certificacion, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_modelo_avion", DBNull.Value),
                    new OracleParameter("p_codigo_checklist", DBNull.Value),
                    new OracleParameter("p_nombre_checklist", (object?)m.NombreChecklist ?? DBNull.Value),
                    new OracleParameter("p_tipo_mantenimiento", DBNull.Value),
                    new OracleParameter("p_frecuencia_horas_vuelo", DBNull.Value),
                    new OracleParameter("p_frecuencia_dias", DBNull.Value),
                    new OracleParameter("p_tiempo_estimado_minutos", DBNull.Value),
                    new OracleParameter("p_requiere_herramientas_especiales", DBNull.Value),
                    new OracleParameter("p_requiere_certificacion", DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ChecklistMantenimiento: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ChecklistMantenimiento m)
        {
            try
            {
                string sql = "BEGIN pkg_checklists_mantenimiento.update_checklist(:p_id_checklist, :p_id_modelo_avion, :p_codigo_checklist, :p_nombre_checklist, :p_tipo_mantenimiento, :p_frecuencia_horas_vuelo, :p_frecuencia_dias, :p_tiempo_estimado_minutos, :p_requiere_herramientas_especiales, :p_requiere_certificacion, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_checklist", id),
                    new OracleParameter("p_id_modelo_avion", DBNull.Value),
                    new OracleParameter("p_codigo_checklist", DBNull.Value),
                    new OracleParameter("p_nombre_checklist", (object?)m.NombreChecklist ?? DBNull.Value),
                    new OracleParameter("p_tipo_mantenimiento", DBNull.Value),
                    new OracleParameter("p_frecuencia_horas_vuelo", DBNull.Value),
                    new OracleParameter("p_frecuencia_dias", DBNull.Value),
                    new OracleParameter("p_tiempo_estimado_minutos", DBNull.Value),
                    new OracleParameter("p_requiere_herramientas_especiales", DBNull.Value),
                    new OracleParameter("p_requiere_certificacion", DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ChecklistMantenimiento: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_checklists_mantenimiento.delete_checklist(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ChecklistMantenimiento: {ex.Message}"); throw; }
        }
    }
}
