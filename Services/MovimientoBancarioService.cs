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

        public async Task<bool> Insertar(MovimientoBancario m)
        {
            try {
                string sql = "BEGIN pkg_movimientos_bancarios.insert_movimiento(:p_cta, :p_fec, :p_tipo, :p_monto, :p_desc); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_cta", m.IdCuentaBanco),
                    new OracleParameter("p_fec", m.Fecha),
                    new OracleParameter("p_tipo", m.TipoMovimiento),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_desc", m.Descripcion)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch (Exception) { return false; }
        }
    }
}