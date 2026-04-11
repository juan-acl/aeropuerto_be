using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class OrdenCompraService : IOrdenCompraService
    {
        private readonly DBContext _context;
        public OrdenCompraService(DBContext context) => _context = context;

        public async Task<List<OrdenCompra>> ListarTodo() => await _context.ORDENES_COMPRA.ToListAsync();

        public async Task<bool> Insertar(OrdenCompra m)
        {
            try {
                string sql = "BEGIN pkg_ordenes_compra.insert_orden(:p_prov, :p_fec, :p_total, :p_est, :p_obs); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_prov", m.IdProveedor),
                    new OracleParameter("p_fec", m.FechaOrden),
                    new OracleParameter("p_total", m.Total),
                    new OracleParameter("p_est", m.Estado),
                    new OracleParameter("p_obs", m.Observaciones ?? (object)DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch (Exception) { return false; }
        }
    }
}