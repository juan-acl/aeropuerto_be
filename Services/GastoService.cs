using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class GastoService : IGastoService
    {
        private readonly DBContext _context;
        public GastoService(DBContext context) => _context = context;

        public async Task<List<Gasto>> ListarTodo() => await _context.GASTOS.ToListAsync();

        public async Task<bool> Insertar(Gasto m)
        {
            try
            {
                string sql = "BEGIN pkg_gastos.insert_gasto(:p_fec, :p_desc, :p_monto, :p_cat, :p_cta, :p_pres); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_fec", m.Fecha),
                    new OracleParameter("p_desc", m.Descripcion),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_cat", m.Categoria),
                    new OracleParameter("p_cta", m.IdCuentaContable),
                    new OracleParameter("p_pres", m.IdPresupuesto ?? (object)DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR GASTO: {ex.Message}");
                return false;
            }
        }
    }
}