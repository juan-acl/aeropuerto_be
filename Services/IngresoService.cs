using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class IngresoService : IIngresoService
    {
        private readonly DBContext _context;
        public IngresoService(DBContext context) => _context = context;

        public async Task<List<Ingreso>> ListarTodo() => await _context.INGRESOS.ToListAsync();

        public async Task<bool> Insertar(Ingreso m)
        {
            try
            {
                string sql = "BEGIN pkg_ingresos.insert_ingreso(:p_fec, :p_desc, :p_monto, :p_fuente, :p_cta, :p_metodo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_fec", m.Fecha),
                    new OracleParameter("p_desc", m.Descripcion),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_fuente", m.Fuente),
                    new OracleParameter("p_cta", m.IdCuentaContable),
                    new OracleParameter("p_metodo", m.MetodoPago)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR INGRESO: {ex.Message}");
                return false;
            }
        }
    }
}