using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class BodegaCargaService : IBodegaCargaService
    {
        private readonly DBContext _context;
        public BodegaCargaService(DBContext context) => _context = context;

        public async Task<List<BodegaCarga>> ListarTodo() => await _context.BODEGAS_CARGA.ToListAsync();

        public async Task<bool> Insertar(BodegaCarga m)
        {
            try {
                string sql = "BEGIN pkg_bodegas_carga.insert_bodega(:p_nom, :p_ub, :p_cap, :p_tipo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nom", m.NombreBodega),
                    new OracleParameter("p_ub", m.Ubicacion),
                    new OracleParameter("p_cap", m.CapacidadMaxima),
                    new OracleParameter("p_tipo", m.TipoCarga)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}