using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class OrdenDetalleService : IOrdenDetalleService
    {
        private readonly DBContext _context;
        public OrdenDetalleService(DBContext context) => _context = context;

        public async Task<List<OrdenDetalle>> ListarTodo() => await _context.ORDENES_DETALLE.ToListAsync();

        public async Task<bool> Insertar(OrdenDetalle m)
        {
            try {
                string sql = "BEGIN pkg_ordenes_detalle.insert_detalle(:p_ord, :p_desc, :p_cant, :p_pre, :p_sub); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_ord", m.IdOrden),
                    new OracleParameter("p_desc", m.Descripcion),
                    new OracleParameter("p_cant", m.Cantidad),
                    new OracleParameter("p_pre", m.PrecioUnitario),
                    new OracleParameter("p_sub", m.Subtotal)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch (Exception) { return false; }
        }
    }
}