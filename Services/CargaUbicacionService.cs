using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class CargaUbicacionService : ICargaUbicacionService
    {
        private readonly DBContext _context;
        public CargaUbicacionService(DBContext context) => _context = context;

        public async Task<List<CargaUbicacion>> ListarTodo() => await _context.CARGA_UBICACION.ToListAsync();

        public async Task<bool> Insertar(CargaUbicacion m)
        {
            try {
                string sql = "BEGIN pkg_carga_ubicacion.insert_ubicacion(:p_env, :p_bod, :p_pas, :p_est, :p_fin, :p_fout); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_env", m.IdEnvio),
                    new OracleParameter("p_bod", m.IdBodega),
                    new OracleParameter("p_pas", m.Pasillo),
                    new OracleParameter("p_est", m.Estante),
                    new OracleParameter("p_fin", m.FechaIngreso),
                    new OracleParameter("p_fout", m.FechaSalida ?? (object)DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}