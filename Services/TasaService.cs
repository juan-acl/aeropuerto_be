using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class TasaService : ITasaService
    {
        private readonly DBContext _context;
        public TasaService(DBContext context) => _context = context;

        public async Task<List<TasaAeroportuaria>> ListarTodo() => await _context.TASAS_AEROPORTUARIAS.ToListAsync();

        public async Task<bool> Insertar(TasaAeroportuaria m)
        {
            try {
                string sql = "BEGIN pkg_tasas_aeroportuarias.insert_tasa(:p_nom, :p_desc, :p_monto, :p_tipo, :p_act); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nom", m.NombreTasa),
                    new OracleParameter("p_desc", m.Descripcion),
                    new OracleParameter("p_monto", m.Monto),
                    new OracleParameter("p_tipo", m.TipoTasa),
                    new OracleParameter("p_act", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch (Exception) { return false; }
        }
    }
}