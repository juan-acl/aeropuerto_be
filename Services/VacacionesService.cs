using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class VacacionesService : IVacacionesService
    {
        private readonly DBContext _context;
        public VacacionesService(DBContext context) => _context = context;

        public async Task<List<VacacionesPermiso>> ListarTodo() => 
            await _context.VACACIONES_PERMISOS.ToListAsync();

        public async Task<bool> Insertar(VacacionesPermiso m)
        {
            try
            {
                string sql = "BEGIN pkg_vacaciones_permisos.insert_solicitud(:p_id_emp, :p_tipo, :p_ini, :p_fin, :p_dias, :p_mot, :p_fsol, :p_est, :p_aut, :p_faut, :p_obs); END;";
                
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_emp", m.IdEmpleado),
                    new OracleParameter("p_tipo", m.TipoSolicitud),
                    new OracleParameter("p_ini", m.FechaInicio),
                    new OracleParameter("p_fin", m.FechaFin),
                    new OracleParameter("p_dias", m.DiasSolicitados),
                    new OracleParameter("p_mot", m.Motivo),
                    new OracleParameter("p_fsol", m.FechaSolicitud),
                    new OracleParameter("p_est", m.Estado),
                    new OracleParameter("p_aut", m.AutorizadoPor ?? (object)DBNull.Value),
                    new OracleParameter("p_faut", m.FechaAutorizacion ?? (object)DBNull.Value),
                    new OracleParameter("p_obs", m.Observaciones ?? (object)DBNull.Value)
                };

                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR VACACIONES: {ex.Message}");
                return false;
            }
        }
    }
}