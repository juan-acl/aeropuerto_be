using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class InspectorAduanaService : IInspectorAduanaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public InspectorAduanaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<InspectorAduana>> ListarTodo()
        {
            try { return await _replica.INSPECTORES_ADUANAS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo InspectorAduana: {ex.Message}"); return new List<InspectorAduana>(); }
        }

        public async Task<InspectorAduana ?> ObtenerPorId(int id)
        {
            try { return await _replica.INSPECTORES_ADUANAS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId InspectorAduana: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(InspectorAduana m)
        {
            try
            {
                string sql = "BEGIN pkg_inspectores_aduanas.insert_inspector(:p_id_empleado, :p_numero_licencia, :p_nivel_autorizacion, :p_fecha_certificacion, :p_fecha_vencimiento_certificacion, :p_especialidad, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_empleado", DBNull.Value),
                    new OracleParameter("p_numero_licencia", DBNull.Value),
                    new OracleParameter("p_nivel_autorizacion", DBNull.Value),
                    new OracleParameter("p_fecha_certificacion", DBNull.Value),
                    new OracleParameter("p_fecha_vencimiento_certificacion", DBNull.Value),
                    new OracleParameter("p_especialidad", DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar InspectorAduana: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, InspectorAduana m)
        {
            try
            {
                string sql = "BEGIN pkg_inspectores_aduanas.update_inspector(:p_id_inspector, :p_id_empleado, :p_numero_licencia, :p_nivel_autorizacion, :p_fecha_certificacion, :p_fecha_vencimiento_certificacion, :p_especialidad, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_inspector", id),
                    new OracleParameter("p_id_empleado", DBNull.Value),
                    new OracleParameter("p_numero_licencia", DBNull.Value),
                    new OracleParameter("p_nivel_autorizacion", DBNull.Value),
                    new OracleParameter("p_fecha_certificacion", DBNull.Value),
                    new OracleParameter("p_fecha_vencimiento_certificacion", DBNull.Value),
                    new OracleParameter("p_especialidad", DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar InspectorAduana: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_inspectores_aduanas.delete_inspector(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar InspectorAduana: {ex.Message}"); throw; }
        }
    }
}
