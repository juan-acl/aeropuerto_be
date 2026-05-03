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
        public async Task<CuentaBancaria?> ObtenerPorId(int id) => await _context.CUENTAS_BANCARIAS.FindAsync(id);

        public async Task<bool> Insertar(CuentaBancaria m)
        {
            try
            {
                string sql = "BEGIN pkg_cuentas_bancarias.insert_cuenta(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT CUENTA_BANCARIA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(CuentaBancaria m)
        {
            try
            {
                string sql = "BEGIN pkg_cuentas_bancarias.update_cuenta(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE CUENTA_BANCARIA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_cuentas_bancarias.delete_cuenta(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE CUENTA_BANCARIA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(CuentaBancaria m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_cuenta),
            new OracleParameter("p2", m.banco),
            new OracleParameter("p3", m.tipo_cuenta),
            new OracleParameter("p4", m.numero_cuenta),
            new OracleParameter("p5", m.moneda),
            new OracleParameter("p6", m.saldo_actual),
            new OracleParameter("p7", m.fecha_apertura),
            new OracleParameter("p8", m.estado),
            new OracleParameter("p9", m.responsable)
        };
    }
}