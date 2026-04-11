using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class CuentaBancariaService : ICuentaBancariaService
    {
        private readonly DBContext _context;
        public CuentaBancariaService(DBContext context) => _context = context;

        public async Task<List<CuentaBancaria>> ListarTodo() => await _context.CUENTAS_BANCARIAS.ToListAsync();

        public async Task<bool> Insertar(CuentaBancaria m)
        {
            try {
                string sql = "BEGIN pkg_cuentas_bancarias.insert_cuenta_banco(:p_banco, :p_num, :p_tipo, :p_saldo, :p_mon, :p_act); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_banco", m.Banco),
                    new OracleParameter("p_num", m.NumeroCuenta),
                    new OracleParameter("p_tipo", m.TipoCuenta),
                    new OracleParameter("p_saldo", m.Saldo),
                    new OracleParameter("p_mon", m.Moneda),
                    new OracleParameter("p_act", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch (Exception) { return false; }
        }
    }
}