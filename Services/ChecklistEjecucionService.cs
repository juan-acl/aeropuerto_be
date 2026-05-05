using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ChecklistEjecucionService : IChecklistEjecucionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ChecklistEjecucionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ChecklistEjecucion>> ListarTodo()
        {
            try { return await _replica.CHECKLIST_EJECUCION.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ChecklistEjecucion: {ex.Message}"); return new List<ChecklistEjecucion>(); }
        }

        public async Task<ChecklistEjecucion ?> ObtenerPorId(int id)
        {
            try { return await _replica.CHECKLIST_EJECUCION.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ChecklistEjecucion: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ChecklistEjecucion m)
        {
            try
            {
                string sql = "BEGIN pkg_checklist_ejecucion.insert_ejecucion(:p_id_orden_mp, :p_id_checklist, :p_fecha_inicio, :p_fecha_fin, :p_tecnico_ejecutor, :p_supervisor, :p_resultado, :p_observaciones, :p_firma_tecnico, :p_firma_supervisor); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_orden_mp", DBNull.Value),
                    new OracleParameter("p_id_checklist", m.IdChecklist),
                    new OracleParameter("p_fecha_inicio", DBNull.Value),
                    new OracleParameter("p_fecha_fin", DBNull.Value),
                    new OracleParameter("p_tecnico_ejecutor", DBNull.Value),
                    new OracleParameter("p_supervisor", DBNull.Value),
                    new OracleParameter("p_resultado", DBNull.Value),
                    new OracleParameter("p_observaciones", DBNull.Value),
                    new OracleParameter("p_firma_tecnico", DBNull.Value),
                    new OracleParameter("p_firma_supervisor", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ChecklistEjecucion: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ChecklistEjecucion m)
        {
            try
            {
                string sql = "BEGIN pkg_checklist_ejecucion.update_ejecucion(:p_id_ejecucion, :p_id_orden_mp, :p_id_checklist, :p_fecha_inicio, :p_fecha_fin, :p_tecnico_ejecutor, :p_supervisor, :p_resultado, :p_observaciones, :p_firma_tecnico, :p_firma_supervisor); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_ejecucion", id),
                    new OracleParameter("p_id_orden_mp", DBNull.Value),
                    new OracleParameter("p_id_checklist", m.IdChecklist),
                    new OracleParameter("p_fecha_inicio", DBNull.Value),
                    new OracleParameter("p_fecha_fin", DBNull.Value),
                    new OracleParameter("p_tecnico_ejecutor", DBNull.Value),
                    new OracleParameter("p_supervisor", DBNull.Value),
                    new OracleParameter("p_resultado", DBNull.Value),
                    new OracleParameter("p_observaciones", DBNull.Value),
                    new OracleParameter("p_firma_tecnico", DBNull.Value),
                    new OracleParameter("p_firma_supervisor", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ChecklistEjecucion: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_checklist_ejecucion.delete_ejecucion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ChecklistEjecucion: {ex.Message}"); throw; }
        }
    }
}
