using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly DBContext _context;
        public AsistenciaService(DBContext context) => _context = context;

        public async Task<List<Asistencia>> ListarTodo() => await _context.ASISTENCIAS.ToListAsync();
        public async Task<Asistencia?> ObtenerPorId(int id) => await _context.ASISTENCIAS.FindAsync(id);

        public async Task<bool> Insertar(Asistencia m)
        {
            try
            {
                string sql = "BEGIN pkg_asistencias.insert_asistencia(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT ASISTENCIA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(Asistencia m)
        {
            try
            {
                string sql = "BEGIN pkg_asistencias.update_asistencia(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE ASISTENCIA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_asistencias.delete_asistencia(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE ASISTENCIA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(Asistencia m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_asistencia),
            new OracleParameter("p2", m.id_empleado),
            new OracleParameter("p3", m.fecha),
            new OracleParameter("p4", m.hora_entrada),
            new OracleParameter("p5", m.hora_salida),
            new OracleParameter("p6", m.horas_trabajadas),
            new OracleParameter("p7", m.tipo_jornada),
            new OracleParameter("p8", m.observaciones)
        };
    }
}