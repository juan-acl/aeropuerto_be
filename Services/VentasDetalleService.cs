using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class VentasDetalleService : IVentasDetalleService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public VentasDetalleService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<VentasDetalleModel>> ListarTodo()
        {
            try { return await _replica.VentasDetalle.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo VentasDetalleModel: {ex.Message}"); return new List<VentasDetalleModel>(); }
        }

        public async Task<VentasDetalleModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.VentasDetalle.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId VentasDetalleModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(VentasDetalleModel m)
        {
            try
            {
                string sql = "BEGIN pkg_ventas_detalle.insert_detalle(:p_id_venta, :p_id_producto, :p_cantidad, :p_precio_unitario, :p_descuento_aplicado, :p_subtotal_linea); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_venta", (object?)m.IdVenta ?? DBNull.Value),
                    new OracleParameter("p_id_producto", (object?)m.IdProducto ?? DBNull.Value),
                    new OracleParameter("p_cantidad", (object?)m.Cantidad ?? DBNull.Value),
                    new OracleParameter("p_precio_unitario", (object?)m.PrecioUnitario ?? DBNull.Value),
                    new OracleParameter("p_descuento_aplicado", (object?)m.DescuentoAplicado ?? DBNull.Value),
                    new OracleParameter("p_subtotal_linea", (object?)m.SubtotalLinea ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar VentasDetalleModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, VentasDetalleModel m)
        {
            try
            {
                string sql = "BEGIN pkg_ventas_detalle.update_detalle(:p_id_detalle, :p_id_venta, :p_id_producto, :p_cantidad, :p_precio_unitario, :p_descuento_aplicado, :p_subtotal_linea); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_detalle", id),
                    new OracleParameter("p_id_venta", (object?)m.IdVenta ?? DBNull.Value),
                    new OracleParameter("p_id_producto", (object?)m.IdProducto ?? DBNull.Value),
                    new OracleParameter("p_cantidad", (object?)m.Cantidad ?? DBNull.Value),
                    new OracleParameter("p_precio_unitario", (object?)m.PrecioUnitario ?? DBNull.Value),
                    new OracleParameter("p_descuento_aplicado", (object?)m.DescuentoAplicado ?? DBNull.Value),
                    new OracleParameter("p_subtotal_linea", (object?)m.SubtotalLinea ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar VentasDetalleModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_ventas_detalle.delete_detalle(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar VentasDetalleModel: {ex.Message}"); throw; }
        }
    }
}
