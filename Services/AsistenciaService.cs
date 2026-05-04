using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AsistenciaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<Asistencia>> ListarTodo()
        {
            try { return await _replica.ASISTENCIAS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo Asistencia: {ex.Message}"); return new List<Asistencia>(); }
        }

        public async Task<Asistencia ?> ObtenerPorId(int id)
        {
            try { return await _replica.ASISTENCIAS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId Asistencia: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(Asistencia m)
        {
            try
            {
                string sql = "BEGIN pkg_asistencias.insert_asistencia(:p_id_empleado, :p_fecha, :p_hora_entrada, :p_hora_salida, :p_horas_trabajadas, :p_tipo_jornada, :p_observaciones, :p_registrado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_empleado", m.IdEmpleado),
                    new OracleParameter("p_fecha", m.Fecha),
                    new OracleParameter("p_hora_entrada", m.HoraEntrada),
                    new OracleParameter("p_hora_salida", m.HoraSalida),
                    new OracleParameter("p_horas_trabajadas", m.HorasTrabajadas),
                    new OracleParameter("p_tipo_jornada", (object?)m.TipoJornada ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
                    new OracleParameter("p_registrado_por", m.RegistradoPor)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar Asistencia: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, Asistencia m)
        {
            try
            {
                string sql = "BEGIN pkg_asistencias.update_asistencia(:p_id_asistencia, :p_id_empleado, :p_fecha, :p_hora_entrada, :p_hora_salida, :p_horas_trabajadas, :p_tipo_jornada, :p_observaciones, :p_registrado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_asistencia", id),
                    new OracleParameter("p_id_empleado", m.IdEmpleado),
                    new OracleParameter("p_fecha", m.Fecha),
                    new OracleParameter("p_hora_entrada", m.HoraEntrada),
                    new OracleParameter("p_hora_salida", m.HoraSalida),
                    new OracleParameter("p_horas_trabajadas", m.HorasTrabajadas),
                    new OracleParameter("p_tipo_jornada", (object?)m.TipoJornada ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
                    new OracleParameter("p_registrado_por", m.RegistradoPor)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar Asistencia: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_asistencias.delete_asistencia(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar Asistencia: {ex.Message}"); throw; }
        }
    }
}
