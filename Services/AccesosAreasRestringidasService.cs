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
            var sql = "pkg_accesos_areas_restringidas.insert_acceso";

            var parametros = new[] {
                new OracleParameter("p_id_empleado", (object?)m.IdEmpleado ?? DBNull.Value),
                new OracleParameter("p_area_acceso", (object?)m.AreaAcceso ?? DBNull.Value),
                new OracleParameter("p_tipo_acceso", m.TipoAcceso),
                new OracleParameter("p_metodo_autenticacion", (object?)m.MetodoAutenticacion ?? DBNull.Value),
                new OracleParameter("p_autorizado", m.Autorizado),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_empleado, :p_area_acceso, :p_tipo_acceso, :p_metodo_autenticacion, :p_autorizado, :p_observaciones); END;", parametros);
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
            var sql = "pkg_accesos_areas_restringidas.delete_acceso";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_acceso); END;", new OracleParameter("p_id_acceso", id));
            return true;
        }
    }
}