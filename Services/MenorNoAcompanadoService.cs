using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class MenorNoAcompanadoService : IMenorNoAcompanadoService
    {
        private readonly DBContext _context;
        public MenorNoAcompanadoService(DBContext context) => _context = context;

        public async Task<List<MenorNoAcompanado>> ListarTodo() => await _context.MENORES_NO_ACOMPANADOS.ToListAsync();

        public async Task<bool> Insertar(MenorNoAcompanado m)
        {
            try
            {
                string sql = "BEGIN pkg_menores_no_acompanados.insert_servicio(:p_idm, :p_vuelo, :p_ent, :p_rec, :p_tel, :p_est); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_idm", m.IdPasajeroMenor),
                    new OracleParameter("p_vuelo", m.IdVuelo),
                    new OracleParameter("p_ent", m.PersonaEntrega),
                    new OracleParameter("p_rec", m.PersonaRecibe),
                    new OracleParameter("p_tel", m.TelefonoContacto),
                    new OracleParameter("p_est", m.EstadoServicio)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR SERVICIO MENOR: {ex.Message}");
                return false;
            }
        }
    }
}