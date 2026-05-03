using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class AutorizacionMenorService : IAutorizacionMenorService
    {
        private readonly DBContext _context;
        public AutorizacionMenorService(DBContext context) => _context = context;

        public async Task<List<AutorizacionMenor>> ListarTodo() => await _context.AUTORIZACIONES_MENORES.ToListAsync();
        public async Task<AutorizacionMenor?> ObtenerPorId(int id) => await _context.AUTORIZACIONES_MENORES.FindAsync(id);

        public async Task<bool> Insertar(AutorizacionMenor m)
        {
            try
            {
                string sql = "BEGIN pkg_autorizaciones_menores.insert_autorizacion(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT AUTORIZACION_MENOR: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(AutorizacionMenor m)
        {
            try
            {
                string sql = "BEGIN pkg_autorizaciones_menores.update_autorizacion(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE AUTORIZACION_MENOR: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_autorizaciones_menores.delete_autorizacion(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE AUTORIZACION_MENOR: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(AutorizacionMenor m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_autorizacion_menor),
            new OracleParameter("p2", m.id_menor),
            new OracleParameter("p3", m.numero_autorizacion),
            new OracleParameter("p4", m.fecha_emision),
            new OracleParameter("p5", m.fecha_expiracion),
            new OracleParameter("p6", m.autoridad_emisora),
            new OracleParameter("p7", m.documento_autorizacion),
            new OracleParameter("p8", m.verificado)
        };
    }
}