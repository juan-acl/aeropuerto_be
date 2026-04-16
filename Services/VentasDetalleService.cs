using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class VentasDetalleService : IVentasDetalleService
    {
        private readonly DBContext _context;

        public VentasDetalleService(DBContext context) => _context = context;

        public async Task<bool> RegistrarDetalle(VentasDetalleModel m)
        {
            var sql = @"INSERT INTO ventas_detalle 
                        (id_venta, id_producto, cantidad, precio_unitario, descuento_aplicado, subtotal_linea) 
                        VALUES (:p_ven, :p_prod, :p_cant, :p_precio, :p_desc, :p_subt)";

            var parametros = new[] {
                new OracleParameter("p_ven", (object?)m.IdVenta ?? DBNull.Value),
                new OracleParameter("p_prod", (object?)m.IdProducto ?? DBNull.Value),
                new OracleParameter("p_cant", (object?)m.Cantidad ?? DBNull.Value),
                new OracleParameter("p_precio", (object?)m.PrecioUnitario ?? DBNull.Value),
                new OracleParameter("p_desc", (object?)m.DescuentoAplicado ?? DBNull.Value),
                new OracleParameter("p_subt", (object?)m.SubtotalLinea ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> RegistrarMultiplesDetalles(List<VentasDetalleModel> detalles)
        {
            // Usamos una transacción para asegurar que si falla un producto, se haga rollback de todo el ticket
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (var item in detalles)
                {
                    await RegistrarDetalle(item);

                    // Lógica adicional: Descontar el stock automáticamente en la tabla tiendas_productos
                    var sqlStock = @"UPDATE tiendas_productos 
                                     SET stock_actual = stock_actual - :p_cant 
                                     WHERE id_producto = :p_prod";

                    await _context.Database.ExecuteSqlRawAsync(sqlStock,
                        new OracleParameter("p_cant", item.Cantidad),
                        new OracleParameter("p_prod", item.IdProducto));
                }

                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<VentasDetalleModel>> ListarPorVenta(int idVenta)
        {
            return await _context.VentasDetalle
                .Where(d => d.IdVenta == idVenta)
                .OrderBy(d => d.IdDetalle)
                .ToListAsync();
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM ventas_detalle WHERE id_detalle = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}