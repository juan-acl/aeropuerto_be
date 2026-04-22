using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TiendasProductosService : ITiendasProductosService
    {
        private readonly DBContext _context;
        public TiendasProductosService(DBContext context) => _context = context;

        public async Task<List<TiendasProductosModel>> ListarTodo()
        {
            try { return await _context.TiendasProductos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TiendasProductosModel: {ex.Message}"); return new List<TiendasProductosModel>(); }
        }

        public async Task<TiendasProductosModel?> ObtenerPorId(int id)
        {
            try { return await _context.TiendasProductos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TiendasProductosModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TiendasProductosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_tiendas_productos.insert_producto(:p_id_concesion, :p_codigo_producto, :p_nombre_producto, :p_descripcion, :p_categoria, :p_precio, :p_moneda, :p_stock_actual, :p_stock_minimo, :p_iva_aplicable, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_concesion", (object?)m.IdConcesion ?? DBNull.Value),
                new OracleParameter("p_codigo_producto", (object?)m.CodigoProducto ?? DBNull.Value),
                new OracleParameter("p_nombre_producto", (object?)m.NombreProducto ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_categoria", (object?)m.Categoria ?? DBNull.Value),
                new OracleParameter("p_precio", (object?)m.Precio ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_stock_actual", (object?)m.StockActual ?? DBNull.Value),
                new OracleParameter("p_stock_minimo", (object?)m.StockMinimo ?? DBNull.Value),
                new OracleParameter("p_iva_aplicable", (object?)m.IvaAplicable ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar TiendasProductosModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, TiendasProductosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_tiendas_productos.update_producto(:p_id_producto, :p_id_concesion, :p_codigo_producto, :p_nombre_producto, :p_descripcion, :p_categoria, :p_precio, :p_moneda, :p_stock_actual, :p_stock_minimo, :p_iva_aplicable, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_producto", id),
                new OracleParameter("p_id_concesion", (object?)m.IdConcesion ?? DBNull.Value),
                new OracleParameter("p_codigo_producto", (object?)m.CodigoProducto ?? DBNull.Value),
                new OracleParameter("p_nombre_producto", (object?)m.NombreProducto ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_categoria", (object?)m.Categoria ?? DBNull.Value),
                new OracleParameter("p_precio", (object?)m.Precio ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_stock_actual", (object?)m.StockActual ?? DBNull.Value),
                new OracleParameter("p_stock_minimo", (object?)m.StockMinimo ?? DBNull.Value),
                new OracleParameter("p_iva_aplicable", (object?)m.IvaAplicable ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar TiendasProductosModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_tiendas_productos.delete_producto(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar TiendasProductosModel: {ex.Message}"); return false; }
        }
    }
}
