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
        public async Task<PasajeroMenor?> ObtenerPorId(int id) => await _context.PASAJEROS_MENORES.FindAsync(id);

        public async Task<bool> Insertar(PasajeroMenor m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_menores.insert_pasajero_menor(:p1, :p2, :p3, :p4, :p5, :p6); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT PASAJERO_MENOR: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(PasajeroMenor m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_menores.update_pasajero_menor(:p1, :p2, :p3, :p4, :p5, :p6); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE PASAJERO_MENOR: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_menores.delete_pasajero_menor(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE PASAJERO_MENOR: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(PasajeroMenor m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_relacion),
            new OracleParameter("p2", m.id_menor),
            new OracleParameter("p3", m.id_acompanante),
            new OracleParameter("p4", m.tipo_relacion),
            new OracleParameter("p5", m.autorizado),
            new OracleParameter("p6", m.documento_autorizacion)
        };
    }
}