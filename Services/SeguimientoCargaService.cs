using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class SeguimientoCargaService : ISeguimientoCargaService
    {
        private readonly DBContext _context;
        public SeguimientoCargaService(DBContext context) => _context = context;

        public async Task<List<SeguimientoCarga>> ListarTodo() => await _context.SEGUIMIENTO_CARGA.ToListAsync();

        public async Task<bool> Insertar(SeguimientoCarga m)
        {
            try {
                string sql = "BEGIN pkg_seguimiento_carga.insert_seguimiento(:p_envio, :p_fec, :p_ub, :p_est, :p_com); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_envio", m.IdEnvio),
                    new OracleParameter("p_fec", m.FechaEvento),
                    new OracleParameter("p_ub", m.UbicacionActual),
                    new OracleParameter("p_est", m.EstadoCarga),
                    new OracleParameter("p_com", m.Comentarios ?? (object)DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}