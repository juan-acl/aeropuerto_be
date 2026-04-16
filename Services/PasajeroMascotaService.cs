using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PasajeroMascotaService : IPasajeroMascotaService
    {
        private readonly DBContext _context;
        public PasajeroMascotaService(DBContext context) => _context = context;

        public async Task<List<PasajeroMascota>> ListarTodo() => await _context.PASAJEROS_MASCOTAS.ToListAsync();

        public async Task<bool> Insertar(PasajeroMascota m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_mascotas.insert_mascota(:p_resp, :p_nom, :p_esp, :p_raza, :p_peso, :p_cert); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_resp", m.IdPasajeroResponsable),
                    new OracleParameter("p_nom", m.NombreMascota),
                    new OracleParameter("p_esp", m.Especie),
                    new OracleParameter("p_raza", m.Raza),
                    new OracleParameter("p_peso", m.Peso),
                    new OracleParameter("p_cert", m.CertificadoSalud)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR MASCOTA: {ex.Message}");
                return false;
            }
        }
    }
}