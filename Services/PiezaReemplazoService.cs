using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PiezaReemplazoService : IPiezaReemplazoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PiezaReemplazoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PiezaReemplazo>> ListarTodo()
        {
            try { return await _replica.PIEZAS_REEMPLAZO.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PiezaReemplazo: {ex.Message}"); return new List<PiezaReemplazo>(); }
        }

        public async Task<PiezaReemplazo ?> ObtenerPorId(int id)
        {
            try { return await _replica.PIEZAS_REEMPLAZO.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PiezaReemplazo: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PiezaReemplazo m)
        {
            try
            {
                string sql = "BEGIN pkg_piezas_reemplazo.insert_pieza(:p_codigo_pieza, :p_nombre_pieza, :p_descripcion, :p_id_modelo_avion, :p_id_fabricante, :p_numero_parte_fabricante, :p_stock_actual, :p_stock_minimo, :p_stock_maximo, :p_ubicacion_almacen, :p_precio_unitario, :p_moneda, :p_tiempo_reorden_dias, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_pieza", DBNull.Value),
                    new OracleParameter("p_nombre_pieza", (object?)m.NombrePieza ?? DBNull.Value),
                    new OracleParameter("p_descripcion", DBNull.Value),
                    new OracleParameter("p_id_modelo_avion", DBNull.Value),
                    new OracleParameter("p_id_fabricante", DBNull.Value),
                    new OracleParameter("p_numero_parte_fabricante", DBNull.Value),
                    new OracleParameter("p_stock_actual", DBNull.Value),
                    new OracleParameter("p_stock_minimo", m.StockMinimo),
                    new OracleParameter("p_stock_maximo", DBNull.Value),
                    new OracleParameter("p_ubicacion_almacen", DBNull.Value),
                    new OracleParameter("p_precio_unitario", m.PrecioUnitario),
                    new OracleParameter("p_moneda", DBNull.Value),
                    new OracleParameter("p_tiempo_reorden_dias", DBNull.Value),
                    new OracleParameter("p_activo", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PiezaReemplazo: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, PiezaReemplazo m)
        {
            try
            {
                string sql = "BEGIN pkg_piezas_reemplazo.update_pieza(:p_id_pieza, :p_codigo_pieza, :p_nombre_pieza, :p_descripcion, :p_id_modelo_avion, :p_id_fabricante, :p_numero_parte_fabricante, :p_stock_actual, :p_stock_minimo, :p_stock_maximo, :p_ubicacion_almacen, :p_precio_unitario, :p_moneda, :p_tiempo_reorden_dias, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pieza", id),
                    new OracleParameter("p_codigo_pieza", DBNull.Value),
                    new OracleParameter("p_nombre_pieza", (object?)m.NombrePieza ?? DBNull.Value),
                    new OracleParameter("p_descripcion", DBNull.Value),
                    new OracleParameter("p_id_modelo_avion", DBNull.Value),
                    new OracleParameter("p_id_fabricante", DBNull.Value),
                    new OracleParameter("p_numero_parte_fabricante", DBNull.Value),
                    new OracleParameter("p_stock_actual", DBNull.Value),
                    new OracleParameter("p_stock_minimo", m.StockMinimo),
                    new OracleParameter("p_stock_maximo", DBNull.Value),
                    new OracleParameter("p_ubicacion_almacen", DBNull.Value),
                    new OracleParameter("p_precio_unitario", m.PrecioUnitario),
                    new OracleParameter("p_moneda", DBNull.Value),
                    new OracleParameter("p_tiempo_reorden_dias", DBNull.Value),
                    new OracleParameter("p_activo", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PiezaReemplazo: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_piezas_reemplazo.delete_pieza(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PiezaReemplazo: {ex.Message}"); throw; }
        }
    }
}
