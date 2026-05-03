using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class MovimientoBancarioService : IMovimientoBancarioService
    {
        private readonly DBContext _context;
        public MovimientoBancarioService(DBContext context) => _context = context;

        public async Task<List<MovimientoBancario>> ListarTodo() => await _context.MOVIMIENTOS_BANCARIOS.ToListAsync();
        public async Task<MovimientoBancario?> ObtenerPorId(int id) => await _context.MOVIMIENTOS_BANCARIOS.FindAsync(id);

        public async Task<bool> Insertar(MovimientoBancario m)
        {
            try
            {
                string sql = "BEGIN pkg_movimientos_bancarios.insert_movimiento(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT MOVIMIENTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(MovimientoBancario m)
        {
            try
            {
                string sql = "BEGIN pkg_movimientos_bancarios.update_movimiento(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE MOVIMIENTO: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_movimientos_bancarios.delete_movimiento(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE MOVIMIENTO: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(MovimientoBancario m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_movimiento),
            new OracleParameter("p2", m.id_cuenta),
            new OracleParameter("p3", m.fecha),
            new OracleParameter("p4", m.tipo_movimiento),
            new OracleParameter("p5", m.concepto),
            new OracleParameter("p6", m.monto),
            new OracleParameter("p7", m.saldo_resultante),
            new OracleParameter("p8", m.referencia),
            new OracleParameter("p9", m.conciliado)
        };
    }
}