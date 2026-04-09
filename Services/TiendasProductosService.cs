using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class TiendasProductosService : ITiendasProductosService
    {
        private readonly DBContext _context;

        public TiendasProductosService(DBContext context) => _context = context;

        public async Task<bool> RegistrarProducto(TiendasProductosModel m)
        {
            var sql = @"INSERT INTO tiendas_productos 
                        (id_concesion, codigo_producto, nombre_producto, descripcion, categoria, 
                         precio, moneda, stock_actual, stock_minimo, iva_aplicable, activo) 
                        VALUES (:p_con, :p_cod, :p_nom, :p_desc, :p_cat, 
                                :p_pre, :p_mon, :p_stock, :p_min, :p_iva, 1)";

            var parametros = new[] {
                new OracleParameter("p_con", (object?)m.IdConcesion ?? DBNull.Value),
                new OracleParameter("p_cod", (object?)m.CodigoProducto ?? DBNull.Value),
                new OracleParameter("p_nom", (object?)m.NombreProducto ?? DBNull.Value),
                new OracleParameter("p_desc", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_cat", (object?)m.Categoria ?? DBNull.Value),
                new OracleParameter("p_pre", (object?)m.Precio ?? DBNull.Value),
                new OracleParameter("p_mon", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_stock", (object?)m.StockActual ?? DBNull.Value),
                new OracleParameter("p_min", (object?)m.StockMinimo ?? DBNull.Value),
                new OracleParameter("p_iva", (object?)m.IvaAplicable ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<TiendasProductosModel>> ListarPorConcesion(int idConcesion)
        {
            return await _context.TiendasProductos
                .Where(p => p.IdConcesion == idConcesion && p.Activo == 1)
                .OrderBy(p => p.NombreProducto)
                .ToListAsync();
        }

        public async Task<List<TiendasProductosModel>> ListarBajoStockMinimo(int idConcesion)
        {
            // Retorna productos que necesitan reabastecimiento urgente
            return await _context.TiendasProductos
                .Where(p => p.IdConcesion == idConcesion && p.Activo == 1 && p.StockActual <= p.StockMinimo)
                .OrderBy(p => p.StockActual)
                .ToListAsync();
        }

        public async Task<bool> ActualizarStock(int idProducto, int nuevoStock)
        {
            var sql = @"UPDATE tiendas_productos 
                        SET stock_actual = :p_stock 
                        WHERE id_producto = :p_id";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_stock", nuevoStock),
                new OracleParameter("p_id", idProducto));
            return true;
        }

        public async Task<bool> DesactivarProducto(int id)
        {
            // Soft delete para mantener el histórico de ventas
            var sql = "UPDATE tiendas_productos SET activo = 0 WHERE id_producto = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM tiendas_productos WHERE id_producto = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}