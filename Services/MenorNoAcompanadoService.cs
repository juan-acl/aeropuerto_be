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
        public async Task<MenorNoAcompanado?> ObtenerPorId(int id) => await _context.MENORES_NO_ACOMPANADOS.FindAsync(id);

        public async Task<bool> Insertar(MenorNoAcompanado m)
        {
            try
            {
                string sql = "BEGIN pkg_menores_no_acompanados.insert_menor(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT MENOR: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(MenorNoAcompanado m)
        {
            try
            {
                string sql = "BEGIN pkg_menores_no_acompanados.update_menor(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE MENOR: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_menores_no_acompanados.delete_menor(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE MENOR: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(MenorNoAcompanado m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_menor),
            new OracleParameter("p2",  m.id_reserva),
            new OracleParameter("p3",  m.edad),
            new OracleParameter("p4",  m.nombre_entrega_origen),
            new OracleParameter("p5",  m.relacion_origen),
            new OracleParameter("p6",  m.telefono_origen),
            new OracleParameter("p7",  m.nombre_recoge_destino),
            new OracleParameter("p8",  m.relacion_destino),
            new OracleParameter("p9",  m.telefono_destino),
            new OracleParameter("p10", m.observaciones)
        };
    }
}