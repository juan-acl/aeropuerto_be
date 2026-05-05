using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class OrdenCompraService : IOrdenCompraService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public OrdenCompraService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<OrdenCompra>> ListarTodo()
        {
            try { return await _replica.ORDENES_COMPRA.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo OrdenCompra: {ex.Message}"); return new List<OrdenCompra>(); }
        }

        public async Task<OrdenCompra ?> ObtenerPorId(int id)
        {
            try { return await _replica.ORDENES_COMPRA.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId OrdenCompra: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(OrdenCompra m)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_compra.insert_orden(:p_id_proveedor, :p_fecha_orden, :p_fecha_entrega_estimada, :p_fecha_entrega_real, :p_estado, :p_subtotal, :p_impuestos, :p_total, :p_condiciones_entrega, :p_solicitado_por, :p_autorizado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_proveedor", m.IdProveedor),
                    new OracleParameter("p_fecha_orden", m.FechaOrden),
                    new OracleParameter("p_fecha_entrega_estimada", DBNull.Value),
                    new OracleParameter("p_fecha_entrega_real", DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_subtotal", DBNull.Value),
                    new OracleParameter("p_impuestos", DBNull.Value),
                    new OracleParameter("p_total", m.Total),
                    new OracleParameter("p_condiciones_entrega", DBNull.Value),
                    new OracleParameter("p_solicitado_por", DBNull.Value),
                    new OracleParameter("p_autorizado_por", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar OrdenCompra: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, OrdenCompra m)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_compra.update_orden(:p_id_orden, :p_id_proveedor, :p_fecha_orden, :p_fecha_entrega_estimada, :p_fecha_entrega_real, :p_estado, :p_subtotal, :p_impuestos, :p_total, :p_condiciones_entrega, :p_solicitado_por, :p_autorizado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_orden", id),
                    new OracleParameter("p_id_proveedor", m.IdProveedor),
                    new OracleParameter("p_fecha_orden", m.FechaOrden),
                    new OracleParameter("p_fecha_entrega_estimada", DBNull.Value),
                    new OracleParameter("p_fecha_entrega_real", DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_subtotal", DBNull.Value),
                    new OracleParameter("p_impuestos", DBNull.Value),
                    new OracleParameter("p_total", m.Total),
                    new OracleParameter("p_condiciones_entrega", DBNull.Value),
                    new OracleParameter("p_solicitado_por", DBNull.Value),
                    new OracleParameter("p_autorizado_por", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar OrdenCompra: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_compra.delete_orden(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar OrdenCompra: {ex.Message}"); throw; }
        }
    }
}
