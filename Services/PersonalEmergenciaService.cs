using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PersonalEmergenciaService : IPersonalEmergenciaService
    {
        private readonly DBContext _context;
        public PersonalEmergenciaService(DBContext context) => _context = context;

        public async Task<bool> Insertar(PersonalEmergencia m)
        {
            var p = new[] {
                new OracleParameter("p_id_empleado", (object?)m.IdEmpleado ?? DBNull.Value),
                new OracleParameter("p_especialidad", (object?)m.Especialidad ?? DBNull.Value),
                new OracleParameter("p_nivel_certificacion", (object?)m.NivelCertificacion ?? DBNull.Value),
                new OracleParameter("p_fecha_certificacion", (object?)m.FechaCertificacion ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento_certificacion", (object?)m.FechaVencimientoCertificacion ?? DBNull.Value),
                new OracleParameter("p_disponible_24h", (object?)m.Disponible24h ?? DBNull.Value),
                new OracleParameter("p_grupo_respuesta", (object?)m.GrupoRespuesta ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_personal_emergencia.insert_personal(:p_id_empleado, :p_especialidad, :p_nivel_certificacion, :p_fecha_certificacion, :p_fecha_vencimiento_certificacion, :p_disponible_24h, :p_grupo_respuesta, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, PersonalEmergencia m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_personal_emergencia", m.IdPersonalEmergencia)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_empleado", (object?)m.IdEmpleado ?? DBNull.Value),
                new OracleParameter("p_especialidad", (object?)m.Especialidad ?? DBNull.Value),
                new OracleParameter("p_nivel_certificacion", (object?)m.NivelCertificacion ?? DBNull.Value),
                new OracleParameter("p_fecha_certificacion", (object?)m.FechaCertificacion ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento_certificacion", (object?)m.FechaVencimientoCertificacion ?? DBNull.Value),
                new OracleParameter("p_disponible_24h", (object?)m.Disponible24h ?? DBNull.Value),
                new OracleParameter("p_grupo_respuesta", (object?)m.GrupoRespuesta ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_personal_emergencia.update_personal(:p_id_personal_emergencia, :p_id_empleado, :p_especialidad, :p_nivel_certificacion, :p_fecha_certificacion, :p_fecha_vencimiento_certificacion, :p_disponible_24h, :p_grupo_respuesta, :p_activo); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_personal_emergencia.delete_personal(:p_id_personal_emergencia); END;", 
                new OracleParameter("p_id_personal_emergencia", id));
            return true;
        }

        public async Task<List<PersonalEmergencia>> ListarTodo() => await _context.Set<PersonalEmergencia>().ToListAsync();

        public async Task<PersonalEmergencia?> ObtenerPorId(int id) => await _context.Set<PersonalEmergencia>().FindAsync(id);
    }
}
