using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CuentaBancariaService : ICuentaBancariaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CuentaBancariaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CuentaBancaria>> ListarTodo()
        {
            try { return await _replica.CUENTAS_BANCARIAS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CuentaBancaria: {ex.Message}"); return new List<CuentaBancaria>(); }
        }

        public async Task<CuentaBancaria ?> ObtenerPorId(int id)
        {
            try { return await _replica.CUENTAS_BANCARIAS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CuentaBancaria: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CuentaBancaria m)
        {
            try
            {
                string sql = "BEGIN pkg_cuentas_bancarias.insert_cuenta(:p_banco, :p_tipo_cuenta, :p_numero_cuenta, :p_moneda, :p_saldo_actual, :p_fecha_apertura, :p_estado, :p_responsable); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_banco", (object?)m.Banco ?? DBNull.Value),
                    new OracleParameter("p_tipo_cuenta", (object?)m.TipoCuenta ?? DBNull.Value),
                    new OracleParameter("p_numero_cuenta", (object?)m.NumeroCuenta ?? DBNull.Value),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_saldo_actual", DBNull.Value),
                    new OracleParameter("p_fecha_apertura", DBNull.Value),
                    new OracleParameter("p_estado", DBNull.Value),
                    new OracleParameter("p_responsable", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar CuentaBancaria: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, CuentaBancaria m)
        {
            try
            {
                string sql = "BEGIN pkg_cuentas_bancarias.update_cuenta(:p_id_cuenta, :p_banco, :p_tipo_cuenta, :p_numero_cuenta, :p_moneda, :p_saldo_actual, :p_fecha_apertura, :p_estado, :p_responsable); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_cuenta", id),
                    new OracleParameter("p_banco", (object?)m.Banco ?? DBNull.Value),
                    new OracleParameter("p_tipo_cuenta", (object?)m.TipoCuenta ?? DBNull.Value),
                    new OracleParameter("p_numero_cuenta", (object?)m.NumeroCuenta ?? DBNull.Value),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_saldo_actual", DBNull.Value),
                    new OracleParameter("p_fecha_apertura", DBNull.Value),
                    new OracleParameter("p_estado", DBNull.Value),
                    new OracleParameter("p_responsable", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar CuentaBancaria: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_cuentas_bancarias.delete_cuenta(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar CuentaBancaria: {ex.Message}"); throw; }
        }
    }
}
