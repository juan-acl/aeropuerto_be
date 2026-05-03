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
        public async Task<PasajeroMascota?> ObtenerPorId(int id) => await _context.PASAJEROS_MASCOTAS.FindAsync(id);

        public async Task<bool> Insertar(PasajeroMascota m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_mascotas.insert_mascota(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT MASCOTA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(PasajeroMascota m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_mascotas.update_mascota(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE MASCOTA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_mascotas.delete_mascota(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE MASCOTA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(PasajeroMascota m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_mascota),
            new OracleParameter("p2",  m.id_pasajero),
            new OracleParameter("p3",  m.id_reserva),
            new OracleParameter("p4",  m.nombre_mascota),
            new OracleParameter("p5",  m.tipo_mascota),
            new OracleParameter("p6",  m.raza),
            new OracleParameter("p7",  m.peso_kg),
            new OracleParameter("p8",  m.certificado_salud),
            new OracleParameter("p9",  m.vacunas),
            new OracleParameter("p10", m.transportadora_dimensiones),
            new OracleParameter("p11", m.autorizado)
        };
    }
}