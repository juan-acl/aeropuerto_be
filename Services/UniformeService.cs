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

        public async Task<List<UniformeEquipamiento>> ListarTodo() => 
            await _context.UNIFORMES_EQUIPAMIENTO.ToListAsync();

        public async Task<bool> Insertar(UniformeEquipamiento m)
        {
            try
            {
                string sql = "BEGIN pkg_uniformes_equipamiento.insert_asignacion(:p_id_emp, :p_tipo, :p_desc, :p_talla, :p_f_asig, :p_f_dev, :p_est, :p_obs); END;";
                
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_emp", m.IdEmpleado),
                    new OracleParameter("p_tipo", m.TipoEquipo),
                    new OracleParameter("p_desc", m.Descripcion),
                    new OracleParameter("p_talla", m.Talla),
                    new OracleParameter("p_f_asig", m.FechaAsignacion),
                    new OracleParameter("p_f_dev", m.FechaDevolucion ?? (object)DBNull.Value),
                    new OracleParameter("p_est", m.Estado),
                    new OracleParameter("p_obs", m.Observaciones ?? (object)DBNull.Value)
                };

                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR UNIFORME: {ex.Message}");
                return false;
            }
        }
    }
}