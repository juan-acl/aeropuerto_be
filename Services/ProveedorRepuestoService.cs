using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ProveedorRepuestoService : IProveedorRepuestoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ProveedorRepuestoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ProveedorRepuesto>> ListarTodo()
        {
            try { return await _replica.PROVEEDORES_REPUESTOS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ProveedorRepuesto: {ex.Message}"); return new List<ProveedorRepuesto>(); }
        }

        public async Task<ProveedorRepuesto ?> ObtenerPorId(int id)
        {
            try { return await _replica.PROVEEDORES_REPUESTOS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ProveedorRepuesto: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ProveedorRepuesto m)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores_repuestos.insert_proveedor_repuesto(:p_id_proveedor, :p_id_pieza, :p_precio_contrato, :p_tiempo_entrega_dias, :p_calificacion, :p_ultima_compra, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_proveedor", DBNull.Value),
                    new OracleParameter("p_id_pieza", DBNull.Value),
                    new OracleParameter("p_precio_contrato", DBNull.Value),
                    new OracleParameter("p_tiempo_entrega_dias", DBNull.Value),
                    new OracleParameter("p_calificacion", DBNull.Value),
                    new OracleParameter("p_ultima_compra", DBNull.Value),
                    new OracleParameter("p_activo", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ProveedorRepuesto: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ProveedorRepuesto m)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores_repuestos.update_proveedor_repuesto(:p_id_proveedor_repuesto, :p_id_proveedor, :p_id_pieza, :p_precio_contrato, :p_tiempo_entrega_dias, :p_calificacion, :p_ultima_compra, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_proveedor_repuesto", id),
                    new OracleParameter("p_id_proveedor", DBNull.Value),
                    new OracleParameter("p_id_pieza", DBNull.Value),
                    new OracleParameter("p_precio_contrato", DBNull.Value),
                    new OracleParameter("p_tiempo_entrega_dias", DBNull.Value),
                    new OracleParameter("p_calificacion", DBNull.Value),
                    new OracleParameter("p_ultima_compra", DBNull.Value),
                    new OracleParameter("p_activo", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ProveedorRepuesto: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_proveedores_repuestos.delete_proveedor_repuesto(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ProveedorRepuesto: {ex.Message}"); throw; }
        }
    }
}
