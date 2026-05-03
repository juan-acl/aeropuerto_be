using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class UniformeService : IUniformeService
    {
        private readonly DBContext _context;
        public UniformeService(DBContext context) => _context = context;

        public async Task<List<UniformeEquipamiento>> ListarTodo() => await _context.UNIFORMES_EQUIPAMIENTO.ToListAsync();
        public async Task<UniformeEquipamiento?> ObtenerPorId(int id) => await _context.UNIFORMES_EQUIPAMIENTO.FindAsync(id);

        public async Task<bool> Insertar(UniformeEquipamiento m)
        {
            try
            {
                string sql = "BEGIN pkg_uniformes_equipamiento.insert_uniforme(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT UNIFORME: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(UniformeEquipamiento m)
        {
            try
            {
                string sql = "BEGIN pkg_uniformes_equipamiento.update_uniforme(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE UNIFORME: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_uniformes_equipamiento.delete_uniforme(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE UNIFORME: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(UniformeEquipamiento m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_asignacion),
            new OracleParameter("p2", m.id_empleado),
            new OracleParameter("p3", m.tipo_equipo),
            new OracleParameter("p4", m.descripcion),
            new OracleParameter("p5", m.talla),
            new OracleParameter("p6", m.fecha_asignacion),
            new OracleParameter("p7", m.fecha_devolucion),
            new OracleParameter("p8", m.estado),
            new OracleParameter("p9", m.observaciones)
        };
    }
}