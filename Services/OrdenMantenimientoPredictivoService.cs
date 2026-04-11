using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class OrdenMantenimientoPredictivoService : IOrdenMantenimientoPredictivoService
    {
        private readonly DBContext _context;
        public OrdenMantenimientoPredictivoService(DBContext context) => _context = context;

        public async Task<List<OrdenMantenimientoPredictivo>> ListarTodo() => await _context.ORDENES_MANTENIMIENTO_PRED.ToListAsync();

        public async Task<bool> Insertar(OrdenMantenimientoPredictivo m)
        {
            try {
                string sql = "BEGIN pkg_ordenes_mantenimiento_pred.insert_orden(:p_aero, :p_fec, :p_tipo, :p_est, :p_obs); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_aero", m.IdAeronave),
                    new OracleParameter("p_fec", m.FechaProgramada),
                    new OracleParameter("p_tipo", m.TipoMantenimiento),
                    new OracleParameter("p_est", m.Estado),
                    new OracleParameter("p_obs", m.Observaciones ?? (object)DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}