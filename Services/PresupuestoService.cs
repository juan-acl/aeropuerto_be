using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PresupuestoService : IPresupuestoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PresupuestoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<Presupuesto>> ListarTodo()
        {
            try { return await _replica.PRESUPUESTOS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo Presupuesto: {ex.Message}"); return new List<Presupuesto>(); }
        }

        public async Task<Presupuesto ?> ObtenerPorId(int id)
        {
            try { return await _replica.PRESUPUESTOS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId Presupuesto: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(Presupuesto m)
        {
            try
            {
                string sql = "BEGIN pkg_presupuestos.insert_presupuesto(:p_anio_fiscal, :p_mes, :p_concepto, :p_id_departamento, :p_monto_asignado, :p_monto_ejecutado, :p_tipo_gasto, :p_observaciones, :p_fecha_actualizacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_anio_fiscal", DBNull.Value),
                    new OracleParameter("p_mes", DBNull.Value),
                    new OracleParameter("p_concepto", DBNull.Value),
                    new OracleParameter("p_id_departamento", m.IdDepartamento),
                    new OracleParameter("p_monto_asignado", m.MontoAsignado),
                    new OracleParameter("p_monto_ejecutado", m.MontoEjecutado),
                    new OracleParameter("p_tipo_gasto", DBNull.Value),
                    new OracleParameter("p_observaciones", DBNull.Value),
                    new OracleParameter("p_fecha_actualizacion", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar Presupuesto: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, Presupuesto m)
        {
            try
            {
                string sql = "BEGIN pkg_presupuestos.update_presupuesto(:p_id_presupuesto, :p_anio_fiscal, :p_mes, :p_concepto, :p_id_departamento, :p_monto_asignado, :p_monto_ejecutado, :p_tipo_gasto, :p_observaciones, :p_fecha_actualizacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_presupuesto", id),
                    new OracleParameter("p_anio_fiscal", DBNull.Value),
                    new OracleParameter("p_mes", DBNull.Value),
                    new OracleParameter("p_concepto", DBNull.Value),
                    new OracleParameter("p_id_departamento", m.IdDepartamento),
                    new OracleParameter("p_monto_asignado", m.MontoAsignado),
                    new OracleParameter("p_monto_ejecutado", m.MontoEjecutado),
                    new OracleParameter("p_tipo_gasto", DBNull.Value),
                    new OracleParameter("p_observaciones", DBNull.Value),
                    new OracleParameter("p_fecha_actualizacion", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar Presupuesto: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_presupuestos.delete_presupuesto(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar Presupuesto: {ex.Message}"); throw; }
        }
    }
}
