using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class InspectorAduanaService : IInspectorAduanaService
    {
        private readonly DBContext _context;
        public InspectorAduanaService(DBContext context) => _context = context;

        public async Task<List<InspectorAduana>> ListarTodo() => await _context.INSPECTORES_ADUANAS.ToListAsync();

        public async Task<bool> Insertar(InspectorAduana m)
        {
            try {
                string sql = "BEGIN pkg_inspectores_aduanas.insert_inspector(:p_nom, :p_cred, :p_turno, :p_act); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nom", m.Nombre),
                    new OracleParameter("p_cred", m.Credencial),
                    new OracleParameter("p_turno", m.Turno),
                    new OracleParameter("p_act", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}