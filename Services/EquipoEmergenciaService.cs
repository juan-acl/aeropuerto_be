using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EquipoEmergenciaService : IEquipoEmergenciaService
    {
        private readonly DBContext _context;
        public EquipoEmergenciaService(DBContext context) => _context = context;

        public async Task<bool> Insertar(EquiposEmergencia m)
        {
            var p = new[] {
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
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_equipos_emergencia.insert_equipo(:p_codigo_equipo, :p_nombre_equipo, :p_tipo_equipo, :p_descripcion, :p_ubicacion_habitual, :p_disponible_24h, :p_personal_asignado, :p_estado, :p_fecha_ultimo_mantenimiento, :p_fecha_proximo_mantenimiento, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, EquiposEmergencia m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_equipo_emergencia", m.IdEquipoEmergencia)
            };
            p.AddRange(new[] {
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
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_equipos_emergencia.update_equipo(:p_id_equipo_emergencia, :p_codigo_equipo, :p_nombre_equipo, :p_tipo_equipo, :p_descripcion, :p_ubicacion_habitual, :p_disponible_24h, :p_personal_asignado, :p_estado, :p_fecha_ultimo_mantenimiento, :p_fecha_proximo_mantenimiento, :p_activo); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_equipos_emergencia.delete_equipo(:p_id_equipo_emergencia); END;",
                new OracleParameter("p_id_equipo_emergencia", id));
            return true;
        }

        public async Task<List<EquiposEmergencia>> ListarTodo() => await _context.Set<EquiposEmergencia>().ToListAsync();

        public async Task<EquiposEmergencia?> ObtenerPorId(int id) => await _context.Set<EquiposEmergencia>().FindAsync(id);
    }
}
