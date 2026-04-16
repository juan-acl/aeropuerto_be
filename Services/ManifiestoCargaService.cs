using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ManifiestoCargaService : IManifiestoCargaService
    {
        private readonly DBContext _context;
        public ManifiestoCargaService(DBContext context) => _context = context;

        public async Task<List<ManifiestoCarga>> ListarTodo() => await _context.MANIFIESTOS_CARGA.ToListAsync();

        public async Task<bool> Insertar(ManifiestoCarga m)
        {
            try {
                string sql = "BEGIN pkg_manifiestos_carga.insert_manifiesto(:p_vuelo, :p_fec, :p_est, :p_peso); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_vuelo", m.IdVuelo),
                    new OracleParameter("p_fec", m.FechaCreacion),
                    new OracleParameter("p_est", m.Estado),
                    new OracleParameter("p_peso", m.PesoTotal)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}