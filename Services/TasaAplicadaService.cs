using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class TasaAplicadaService : ITasaAplicadaService
    {
        private readonly DBContext _context;
        public TasaAplicadaService(DBContext context) => _context = context;

        public async Task<List<TasaAplicada>> ListarTodo() => await _context.TASAS_APLICADAS.ToListAsync();

        public async Task<bool> Insertar(TasaAplicada m)
        {
            try {
                string sql = "BEGIN pkg_tasas_aplicadas.insert_aplicacion(:p_tasa, :p_pas, :p_vuelo, :p_fec, :p_monto, :p_est); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_tasa", m.IdTasa),
                    new OracleParameter("p_pas", m.IdPasajero),
                    new OracleParameter("p_vuelo", m.IdVuelo),
                    new OracleParameter("p_fec", m.FechaCobro),
                    new OracleParameter("p_monto", m.MontoCobrado),
                    new OracleParameter("p_est", m.Estado)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch (Exception) { return false; }
        }
    }
}