using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class HistorialPreciosCombustibleService : IHistorialPreciosCombustibleService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public HistorialPreciosCombustibleService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<HistorialPreciosCombustible>> ListarTodo()
        {
            try { return await _replica.HistorialPreciosCombustible.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo HistorialPreciosCombustible: {ex.Message}"); return new List<HistorialPreciosCombustible>(); }
        }

        public async Task<HistorialPreciosCombustible ?> ObtenerPorId(int id)
        {
            try { return await _replica.HistorialPreciosCombustible.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId HistorialPreciosCombustible: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(HistorialPreciosCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_historial_precios_combustible.insert_precio(:p_fecha_precio, :p_tipo_combustible, :p_precio_compra_local, :p_precio_venta_aerolineas, :p_moneda, :p_precio_internacional_ref, :p_variacion_porcentual, :p_factor_ajuste, :p_vigente); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_fecha_precio", m.FechaPrecio),
                    new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                    new OracleParameter("p_precio_compra_local", (object?)m.PrecioCompraLocal ?? DBNull.Value),
                    new OracleParameter("p_precio_venta_aerolineas", (object?)m.PrecioVentaAerolineas ?? DBNull.Value),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_precio_internacional_ref", DBNull.Value),
                    new OracleParameter("p_variacion_porcentual", (object?)m.VariacionPorcentual ?? DBNull.Value),
                    new OracleParameter("p_factor_ajuste", (object?)m.FactorAjuste ?? DBNull.Value),
                    new OracleParameter("p_vigente", (object?)m.Vigente ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar HistorialPreciosCombustible: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, HistorialPreciosCombustible m)
        {
            try
            {
                string sql = "BEGIN pkg_historial_precios_combustible.update_precio(:p_id_precio_combustible, :p_fecha_precio, :p_tipo_combustible, :p_precio_compra_local, :p_precio_venta_aerolineas, :p_moneda, :p_precio_internacional_ref, :p_variacion_porcentual, :p_factor_ajuste, :p_vigente); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_precio_combustible", id),
                    new OracleParameter("p_fecha_precio", m.FechaPrecio),
                    new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                    new OracleParameter("p_precio_compra_local", (object?)m.PrecioCompraLocal ?? DBNull.Value),
                    new OracleParameter("p_precio_venta_aerolineas", (object?)m.PrecioVentaAerolineas ?? DBNull.Value),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_precio_internacional_ref", DBNull.Value),
                    new OracleParameter("p_variacion_porcentual", (object?)m.VariacionPorcentual ?? DBNull.Value),
                    new OracleParameter("p_factor_ajuste", (object?)m.FactorAjuste ?? DBNull.Value),
                    new OracleParameter("p_vigente", (object?)m.Vigente ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar HistorialPreciosCombustible: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_historial_precios_combustible.delete_precio(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar HistorialPreciosCombustible: {ex.Message}"); throw; }
        }
    }
}
