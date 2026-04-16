using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EmpCapaService : IEmpCapaService
    {
        private readonly DBContext _context;
        public EmpCapaService(DBContext context) => _context = context;

        public async Task<List<EmpleadoCapacitacion>> ListarTodo() => 
            await _context.EMPLEADOS_CAPACITACION.ToListAsync();

        public async Task<bool> Insertar(EmpleadoCapacitacion m)
        {
            try
            {
                string sql = "BEGIN pkg_empleados_capacitacion.insert_empleado_capacitacion(:p_id_emp, :p_id_cap, :p_f_asig, :p_est, :p_f_comp, :p_cal, :p_cert); END;";
                
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_emp", m.IdEmpleado),
                    new OracleParameter("p_id_cap", m.IdCapacitacion),
                    new OracleParameter("p_f_asig", m.FechaAsignacion),
                    new OracleParameter("p_est", m.Estado),
                    new OracleParameter("p_f_comp", m.FechaCompletado ?? (object)DBNull.Value),
                    new OracleParameter("p_cal", m.Calificacion ?? (object)DBNull.Value),
                    new OracleParameter("p_cert", m.CertificadoObtenido)
                };

                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR EMPLEADO_CAPA: {ex.Message}");
                return false;
            }
        }
    }
}