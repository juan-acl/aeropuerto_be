using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class AccesosAreasRestringidasService : IAccesosAreasRestringidasService
    {
        private readonly DBContext _context;

        public AccesosAreasRestringidasService(DBContext context) => _context = context;

        public async Task<bool> RegistrarAcceso(AccesosAreasRestringidasModel m)
        {
            var sql = @"INSERT INTO accesos_areas_restringidas 
                        (id_empleado, area_acceso, fecha_hora_acceso, tipo_acceso, 
                         metodo_autenticacion, autorizado, observaciones) 
                        VALUES (:p_emp, :p_area, SYSTIMESTAMP, :p_tipo, 
                                :p_metodo, :p_aut, :p_obs)";

            var parametros = new[] {
                new OracleParameter("p_emp", (object?)m.IdEmpleado ?? DBNull.Value),
                new OracleParameter("p_area", (object?)m.AreaAcceso ?? DBNull.Value),
                new OracleParameter("p_tipo", m.TipoAcceso),
                new OracleParameter("p_metodo", (object?)m.MetodoAutenticacion ?? DBNull.Value),
                new OracleParameter("p_aut", m.Autorizado),
                new OracleParameter("p_obs", (object?)m.Observaciones ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<AccesosAreasRestringidasModel>> ListarPorEmpleado(int idEmpleado)
        {
            return await _context.AccesosAreasRestringidas
                .Where(a => a.IdEmpleado == idEmpleado)
                .OrderByDescending(a => a.FechaHoraAcceso)
                .ToListAsync();
        }

        public async Task<List<AccesosAreasRestringidasModel>> ListarAccesosDenegados()
        {
            return await _context.AccesosAreasRestringidas
                .Where(a => a.Autorizado == 0)
                .OrderByDescending(a => a.FechaHoraAcceso)
                .ToListAsync();
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM accesos_areas_restringidas WHERE id_acceso = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}