using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EquiposEmergenciaService : IEquiposEmergenciaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public EquiposEmergenciaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<EquiposEmergencia>> ListarTodo()
        {
            try { return await _replica.EquiposEmergencia.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EquiposEmergencia: {ex.Message}"); return new List<EquiposEmergencia>(); }
        }

        public async Task<EquiposEmergencia ?> ObtenerPorId(int id)
        {
            try { return await _replica.EquiposEmergencia.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EquiposEmergencia: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EquiposEmergencia m)
        {
            try
            {
                string sql = "BEGIN pkg_equipos_emergencia.insert_equipo(:p_codigo_equipo, :p_nombre_equipo, :p_tipo_equipo, :p_descripcion, :p_ubicacion_habitual, :p_disponible_24h, :p_personal_asignado, :p_estado, :p_fecha_ultimo_mantenimiento, :p_fecha_proximo_mantenimiento, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_equipo", (object?)m.CodigoEquipo ?? DBNull.Value),
                    new OracleParameter("p_nombre_equipo", (object?)m.NombreEquipo ?? DBNull.Value),
                    new OracleParameter("p_tipo_equipo", (object?)m.TipoEquipo ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_ubicacion_habitual", (object?)m.UbicacionHabitual ?? DBNull.Value),
                    new OracleParameter("p_disponible_24h", (object?)m.Disponible24h ?? DBNull.Value),
                    new OracleParameter("p_personal_asignado", (object?)m.PersonalAsignado ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultimo_mantenimiento", (object?)m.FechaUltimoMantenimiento ?? DBNull.Value),
                    new OracleParameter("p_fecha_proximo_mantenimiento", (object?)m.FechaProximoMantenimiento ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar EquiposEmergencia: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, EquiposEmergencia m)
        {
            try
            {
                string sql = "BEGIN pkg_equipos_emergencia.update_equipo(:p_id_equipo_emergencia, :p_codigo_equipo, :p_nombre_equipo, :p_tipo_equipo, :p_descripcion, :p_ubicacion_habitual, :p_disponible_24h, :p_personal_asignado, :p_estado, :p_fecha_ultimo_mantenimiento, :p_fecha_proximo_mantenimiento, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_equipo_emergencia", id),
                    new OracleParameter("p_codigo_equipo", (object?)m.CodigoEquipo ?? DBNull.Value),
                    new OracleParameter("p_nombre_equipo", (object?)m.NombreEquipo ?? DBNull.Value),
                    new OracleParameter("p_tipo_equipo", (object?)m.TipoEquipo ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_ubicacion_habitual", (object?)m.UbicacionHabitual ?? DBNull.Value),
                    new OracleParameter("p_disponible_24h", (object?)m.Disponible24h ?? DBNull.Value),
                    new OracleParameter("p_personal_asignado", (object?)m.PersonalAsignado ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultimo_mantenimiento", (object?)m.FechaUltimoMantenimiento ?? DBNull.Value),
                    new OracleParameter("p_fecha_proximo_mantenimiento", (object?)m.FechaProximoMantenimiento ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar EquiposEmergencia: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_equipos_emergencia.delete_equipo(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar EquiposEmergencia: {ex.Message}"); throw; }
        }
    }
}
