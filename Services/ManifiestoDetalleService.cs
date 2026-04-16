using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ManifiestoDetalleService : IManifiestoDetalleService
    {
        private readonly DBContext _context;
        public ManifiestoDetalleService(DBContext context) => _context = context;

        public async Task<List<ManifiestoDetalle>> ListarTodo() => await _context.MANIFIESTOS_DETALLE.ToListAsync();

        public async Task<bool> Insertar(ManifiestoDetalle m)
        {
            try {
                string sql = "BEGIN pkg_manifiestos_detalle.insert_detalle(:p_mani, :p_envio, :p_ub); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_mani", m.IdManifiesto),
                    new OracleParameter("p_envio", m.IdEnvio),
                    new OracleParameter("p_ub", m.UbicacionBodega)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}