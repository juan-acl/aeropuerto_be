using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PasajeroMenorService : IPasajeroMenorService
    {
        private readonly DBContext _context;
        public PasajeroMenorService(DBContext context) => _context = context;

        public async Task<List<PasajeroMenor>> ListarTodo() => await _context.PASAJEROS_MENORES.ToListAsync();

        public async Task<bool> Insertar(PasajeroMenor m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_menores.insert_pasajero_menor(:p_nom, :p_ape, :p_fec, :p_nac, :p_pas); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nom", m.Nombres),
                    new OracleParameter("p_ape", m.Apellidos),
                    new OracleParameter("p_fec", m.FechaNacimiento),
                    new OracleParameter("p_nac", m.Nacionalidad),
                    new OracleParameter("p_pas", m.Pasaporte)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR PASAJERO MENOR: {ex.Message}");
                return false;
            }
        }
    }
}