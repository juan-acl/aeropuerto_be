using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class GastoService : IGastoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public GastoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<Gasto>> ListarTodo()
        {
            try { return await _replica.GASTOS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo Gasto: {ex.Message}"); return new List<Gasto>(); }
        }

        public async Task<Gasto ?> ObtenerPorId(int id)
        {
            try { return await _replica.GASTOS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId Gasto: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(Gasto m)
        {
            try
            {
                string sql = "BEGIN pkg_gastos.insert_gasto(:p_fecha, :p_concepto, :p_tipo_gasto, :p_id_departamento, :p_proveedor, :p_monto, :p_moneda, :p_factura, :p_autorizado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_fecha", m.Fecha),
                    new OracleParameter("p_concepto", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_gasto", (object?)m.Categoria ?? DBNull.Value),
                    new OracleParameter("p_id_departamento", (object?)m.IdDepartamento ?? DBNull.Value),
                    new OracleParameter("p_proveedor", (object?)m.Proveedor ?? DBNull.Value),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_factura", (object?)m.Factura ?? DBNull.Value),
                    new OracleParameter("p_autorizado_por", (object?)m.AutorizadoPor ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar Gasto: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, Gasto m)
        {
            try
            {
                string sql = "BEGIN pkg_gastos.update_gasto(:p_id_gasto, :p_fecha, :p_concepto, :p_tipo_gasto, :p_id_departamento, :p_proveedor, :p_monto, :p_moneda, :p_factura, :p_autorizado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_gasto", id),
                    new OracleParameter("p_fecha", m.Fecha),
                    new OracleParameter("p_concepto", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_gasto", (object?)m.Categoria ?? DBNull.Value),
                    new OracleParameter("p_id_departamento", (object?)m.IdDepartamento ?? DBNull.Value),
                    new OracleParameter("p_proveedor", (object?)m.Proveedor ?? DBNull.Value),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_factura", (object?)m.Factura ?? DBNull.Value),
                    new OracleParameter("p_autorizado_por", (object?)m.AutorizadoPor ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar Gasto: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_gastos.delete_gasto(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar Gasto: {ex.Message}"); throw; }
        }
    }
}
