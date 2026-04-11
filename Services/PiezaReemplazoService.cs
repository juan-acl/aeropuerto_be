using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PiezaReemplazoService : IPiezaReemplazoService
    {
        private readonly DBContext _context;
        public PiezaReemplazoService(DBContext context) => _context = context;

        public async Task<List<PiezaReemplazo>> ListarTodo() => await _context.PIEZAS_REEMPLAZO.ToListAsync();

        public async Task<bool> Insertar(PiezaReemplazo m)
        {
            try {
                string sql = "BEGIN pkg_piezas_reemplazo.insert_pieza(:p_nom, :p_num, :p_stk, :p_min, :p_pre); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nom", m.NombrePieza),
                    new OracleParameter("p_num", m.NumeroParte),
                    new OracleParameter("p_stk", m.Stock),
                    new OracleParameter("p_min", m.StockMinimo),
                    new OracleParameter("p_pre", m.PrecioUnitario)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}