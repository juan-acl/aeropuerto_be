using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class AduanaCargaService : IAduanaCargaService
    {
        private readonly DBContext _context;
        public AduanaCargaService(DBContext context) => _context = context;

        public async Task<List<AduanaCarga>> ListarTodo() => await _context.ADUANAS_CARGA.ToListAsync();

        public async Task<bool> Insertar(AduanaCarga m)
        {
            try {
                string sql = "BEGIN pkg_aduanas_carga.insert_revision(:p_envio, :p_ins, :p_fec, :p_est, :p_obs, :p_imp); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_envio", m.IdEnvio),
                    new OracleParameter("p_ins", m.IdInspector),
                    new OracleParameter("p_fec", m.FechaRevision),
                    new OracleParameter("p_est", m.EstadoAduanero),
                    new OracleParameter("p_obs", m.Observaciones ?? (object)DBNull.Value),
                    new OracleParameter("p_imp", m.ImpuestosPagados)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}