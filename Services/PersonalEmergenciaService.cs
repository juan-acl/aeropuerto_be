using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PersonalEmergenciaService : IPersonalEmergenciaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PersonalEmergenciaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PersonalEmergencia>> ListarTodo()
        {
            try { return await _replica.PersonalEmergencia.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PersonalEmergencia: {ex.Message}"); return new List<PersonalEmergencia>(); }
        }

        public async Task<PersonalEmergencia ?> ObtenerPorId(int id)
        {
            try { return await _replica.PersonalEmergencia.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PersonalEmergencia: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PersonalEmergencia m)
        {
            try
            {
                string sql = "BEGIN pkg_personal_emergencia.insert_personal(:p_id_empleado, :p_especialidad, :p_nivel_certificacion, :p_fecha_certificacion, :p_fecha_vencimiento_certificacion, :p_disponible_24h, :p_grupo_respuesta, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_empleado", (object?)m.IdEmpleado ?? DBNull.Value),
                    new OracleParameter("p_especialidad", (object?)m.Especialidad ?? DBNull.Value),
                    new OracleParameter("p_nivel_certificacion", (object?)m.NivelCertificacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_certificacion", (object?)m.FechaCertificacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_vencimiento_certificacion", (object?)m.FechaVencimientoCertificacion ?? DBNull.Value),
                    new OracleParameter("p_disponible_24h", (object?)m.Disponible24h ?? DBNull.Value),
                    new OracleParameter("p_grupo_respuesta", (object?)m.GrupoRespuesta ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PersonalEmergencia: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, PersonalEmergencia m)
        {
            try
            {
                string sql = "BEGIN pkg_personal_emergencia.update_personal(:p_id_personal_emergencia, :p_id_empleado, :p_especialidad, :p_nivel_certificacion, :p_fecha_certificacion, :p_fecha_vencimiento_certificacion, :p_disponible_24h, :p_grupo_respuesta, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_personal_emergencia", id),
                    new OracleParameter("p_id_empleado", (object?)m.IdEmpleado ?? DBNull.Value),
                    new OracleParameter("p_especialidad", (object?)m.Especialidad ?? DBNull.Value),
                    new OracleParameter("p_nivel_certificacion", (object?)m.NivelCertificacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_certificacion", (object?)m.FechaCertificacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_vencimiento_certificacion", (object?)m.FechaVencimientoCertificacion ?? DBNull.Value),
                    new OracleParameter("p_disponible_24h", (object?)m.Disponible24h ?? DBNull.Value),
                    new OracleParameter("p_grupo_respuesta", (object?)m.GrupoRespuesta ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PersonalEmergencia: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_personal_emergencia.delete_personal(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PersonalEmergencia: {ex.Message}"); throw; }
        }
    }
}
