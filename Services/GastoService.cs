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
        public async Task<Gasto?> ObtenerPorId(int id) => await _context.GASTOS.FindAsync(id);

        public async Task<bool> Insertar(Gasto m)
        {
            try
            {
                string sql = "BEGIN pkg_gastos.insert_gasto(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT GASTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(Gasto m)
        {
            try
            {
                string sql = "BEGIN pkg_gastos.update_gasto(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE GASTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_gastos.delete_gasto(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE GASTO: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(Gasto m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_gasto),
            new OracleParameter("p2",  m.fecha),
            new OracleParameter("p3",  m.concepto),
            new OracleParameter("p4",  m.tipo_gasto),
            new OracleParameter("p5",  m.id_departamento),
            new OracleParameter("p6",  m.proveedor),
            new OracleParameter("p7",  m.monto),
            new OracleParameter("p8",  m.moneda),
            new OracleParameter("p9",  m.factura),
            new OracleParameter("p10", m.autorizado_por)
        };
    }
}