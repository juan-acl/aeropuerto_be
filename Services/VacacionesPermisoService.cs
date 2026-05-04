using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class VacacionesPermisoService : IVacacionesPermisoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public VacacionesPermisoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<VacacionesPermiso>> ListarTodo()
        {
            try { return await _replica.VACACIONES_PERMISOS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo VacacionesPermiso: {ex.Message}"); return new List<VacacionesPermiso>(); }
        }

        public async Task<VacacionesPermiso ?> ObtenerPorId(int id)
        {
            try { return await _replica.VACACIONES_PERMISOS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId VacacionesPermiso: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(VacacionesPermiso m)
        {
            try
            {
                string sql = "BEGIN pkg_vacaciones_permisos.insert_solicitud(:p_id_empleado, :p_tipo_solicitud, :p_fecha_inicio, :p_fecha_fin, :p_dias_solicitados, :p_motivo, :p_fecha_solicitud, :p_estado, :p_autorizado_por, :p_fecha_autorizacion, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_empleado", m.IdEmpleado),
                    new OracleParameter("p_tipo_solicitud", (object?)m.TipoSolicitud ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", m.FechaInicio),
                    new OracleParameter("p_fecha_fin", m.FechaFin),
                    new OracleParameter("p_dias_solicitados", m.DiasSolicitados),
                    new OracleParameter("p_motivo", (object?)m.Motivo ?? DBNull.Value),
                    new OracleParameter("p_fecha_solicitud", m.FechaSolicitud),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_autorizado_por", (object?)m.AutorizadoPor ?? DBNull.Value),
                    new OracleParameter("p_fecha_autorizacion", (object?)m.FechaAutorizacion ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar VacacionesPermiso: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, VacacionesPermiso m)
        {
            try
            {
                string sql = "BEGIN pkg_vacaciones_permisos.update_solicitud(:p_id_solicitud, :p_id_empleado, :p_tipo_solicitud, :p_fecha_inicio, :p_fecha_fin, :p_dias_solicitados, :p_motivo, :p_fecha_solicitud, :p_estado, :p_autorizado_por, :p_fecha_autorizacion, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_solicitud", id),
                    new OracleParameter("p_id_empleado", m.IdEmpleado),
                    new OracleParameter("p_tipo_solicitud", (object?)m.TipoSolicitud ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", m.FechaInicio),
                    new OracleParameter("p_fecha_fin", m.FechaFin),
                    new OracleParameter("p_dias_solicitados", m.DiasSolicitados),
                    new OracleParameter("p_motivo", (object?)m.Motivo ?? DBNull.Value),
                    new OracleParameter("p_fecha_solicitud", m.FechaSolicitud),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_autorizado_por", (object?)m.AutorizadoPor ?? DBNull.Value),
                    new OracleParameter("p_fecha_autorizacion", (object?)m.FechaAutorizacion ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar VacacionesPermiso: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_vacaciones_permisos.delete_solicitud(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar VacacionesPermiso: {ex.Message}"); throw; }
        }
    }
}
