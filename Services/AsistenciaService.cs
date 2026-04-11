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

        public async Task<bool> Insertar(Asistencia m)
        {
            try
            {
                // Ajusta los nombres de parámetros (:p_id, etc) según tu SP en Oracle
                string sql = "BEGIN PKG_ASISTENCIAS.insert_asistencia(:p_id_emp, :p_fec, :p_hen, :p_hsal, :p_htrab, :p_tipo, :p_obs, :p_reg); END;";
                
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_emp", m.IdEmpleado),
                    new OracleParameter("p_fec", m.Fecha),
                    new OracleParameter("p_hen", m.HoraEntrada),
                    new OracleParameter("p_hsal", m.HoraSalida),
                    new OracleParameter("p_htrab", m.HorasTrabajadas),
                    new OracleParameter("p_tipo", m.TipoJornada),
                    new OracleParameter("p_obs", m.Observaciones ?? (object)DBNull.Value),
                    new OracleParameter("p_reg", m.RegistradoPor)
                };

                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR ASISTENCIA: {ex.Message}");
                return false;
            }
        }
    }
}