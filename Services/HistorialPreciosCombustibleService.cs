using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class HistorialPreciosCombustibleService : IHistorialPrecioCombustibleService
    {
        private readonly DBContext _context;

        public HistorialPreciosCombustibleService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(HistorialPreciosCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_fecha_precio", (object?)m.FechaPrecio ?? DBNull.Value),
                new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                new OracleParameter("p_precio_compra_local", (object?)m.PrecioCompraLocal ?? DBNull.Value),
                new OracleParameter("p_precio_venta_aerolineas", (object?)m.PrecioVentaAerolineas ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_precio_internacional_ref", (object?)m.PrecioInternacionalReferencia ?? DBNull.Value),
                new OracleParameter("p_variacion_porcentual", (object?)m.VariacionPorcentual ?? DBNull.Value),
                new OracleParameter("p_factor_ajuste", (object?)m.FactorAjuste ?? DBNull.Value),
                new OracleParameter("p_vigente", (object?)m.Vigente ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_historial_precios_combustible.insert_precio(:p_fecha_precio, :p_tipo_combustible, :p_precio_compra_local, :p_precio_venta_aerolineas, :p_moneda, :p_precio_internacional_ref, :p_variacion_porcentual, :p_factor_ajuste, :p_vigente); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, HistorialPreciosCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_precio", (object?)m.IdPrecioCombustible ?? DBNull.Value),
                new OracleParameter("p_fecha_precio", (object?)m.FechaPrecio ?? DBNull.Value),
                new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                new OracleParameter("p_precio_compra_local", (object?)m.PrecioCompraLocal ?? DBNull.Value),
                new OracleParameter("p_precio_venta_aerolineas", (object?)m.PrecioVentaAerolineas ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_precio_internacional_ref", (object?)m.PrecioInternacionalReferencia ?? DBNull.Value),
                new OracleParameter("p_variacion_porcentual", (object?)m.VariacionPorcentual ?? DBNull.Value),
                new OracleParameter("p_factor_ajuste", (object?)m.FactorAjuste ?? DBNull.Value),
                new OracleParameter("p_vigente", (object?)m.Vigente ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_historial_precios_combustible.update_precio(:p_id_precio, :p_fecha_precio, :p_tipo_combustible, :p_precio_compra_local, :p_precio_venta_aerolineas, :p_moneda, :p_precio_internacional_ref, :p_variacion_porcentual, :p_factor_ajuste, :p_vigente); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_historial_precios_combustible.delete_precio(:p_id_precio); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_precio", id));
            return true;
        }

        public async Task<List<HistorialPreciosCombustible>> ListarTodo()
        {
            return await _context.Set<HistorialPreciosCombustible>().ToListAsync();
        }

        public async Task<HistorialPreciosCombustible?> ObtenerPorId(int id) => await _context.Set<HistorialPreciosCombustible>().FindAsync(id);
    }
}
