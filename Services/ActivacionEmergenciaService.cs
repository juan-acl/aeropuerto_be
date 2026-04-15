using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ActivacionEmergenciaService : IActivacionEmergenciaService
    {
        private readonly DBContext _context;
        public ActivacionEmergenciaService(DBContext context) => _context = context;

        public async Task<bool> Insertar(ActivacionesEmergencia m)
        {
            var p = new[] {
                new OracleParameter("p_fecha_hora_activacion", (object?)m.FechaHoraActivacion ?? DBNull.Value),
                new OracleParameter("p_tipo_emergencia", (object?)m.TipoEmergencia ?? DBNull.Value),
                new OracleParameter("p_id_plan_emergencia", (object?)m.IdPlanEmergencia ?? DBNull.Value),
                new OracleParameter("p_nivel_activacion", (object?)m.NivelActivacion ?? DBNull.Value),
                new OracleParameter("p_descripcion_incidente", (object?)m.DescripcionIncidente ?? DBNull.Value),
                new OracleParameter("p_lugar_incidente", (object?)m.LugarIncidente ?? DBNull.Value),
                new OracleParameter("p_personas_afectadas", (object?)m.PersonasAfectadas ?? DBNull.Value),
                new OracleParameter("p_personas_atendidas", (object?)m.PersonasAtendidas ?? DBNull.Value),
                new OracleParameter("p_recursos_movilizados", (object?)m.RecursosMovilizados ?? DBNull.Value),
                new OracleParameter("p_hora_control", (object?)m.HoraControl ?? DBNull.Value),
                new OracleParameter("p_hora_fin", (object?)m.HoraFin ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_responsable_coordinacion", (object?)m.ResponsableCoordinacion ?? DBNull.Value),
                new OracleParameter("p_informe_incidente", (object?)m.InformeIncidente ?? DBNull.Value),
                new OracleParameter("p_lecciones_aprendidas", (object?)m.LeccionesAprendidas ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_activaciones_emergencia.insert_activacion(:p_fecha_hora_activacion, :p_tipo_emergencia, :p_id_plan_emergencia, :p_nivel_activacion, :p_descripcion_incidente, :p_lugar_incidente, :p_personas_afectadas, :p_personas_atendidas, :p_recursos_movilizados, :p_hora_control, :p_hora_fin, :p_estado, :p_responsable_coordinacion, :p_informe_incidente, :p_lecciones_aprendidas); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, ActivacionesEmergencia m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_activacion", m.IdActivacion)
            };
            p.AddRange(new[] {
                new OracleParameter("p_fecha_hora_activacion", (object?)m.FechaHoraActivacion ?? DBNull.Value),
                new OracleParameter("p_tipo_emergencia", (object?)m.TipoEmergencia ?? DBNull.Value),
                new OracleParameter("p_id_plan_emergencia", (object?)m.IdPlanEmergencia ?? DBNull.Value),
                new OracleParameter("p_nivel_activacion", (object?)m.NivelActivacion ?? DBNull.Value),
                new OracleParameter("p_descripcion_incidente", (object?)m.DescripcionIncidente ?? DBNull.Value),
                new OracleParameter("p_lugar_incidente", (object?)m.LugarIncidente ?? DBNull.Value),
                new OracleParameter("p_personas_afectadas", (object?)m.PersonasAfectadas ?? DBNull.Value),
                new OracleParameter("p_personas_atendidas", (object?)m.PersonasAtendidas ?? DBNull.Value),
                new OracleParameter("p_recursos_movilizados", (object?)m.RecursosMovilizados ?? DBNull.Value),
                new OracleParameter("p_hora_control", (object?)m.HoraControl ?? DBNull.Value),
                new OracleParameter("p_hora_fin", (object?)m.HoraFin ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_responsable_coordinacion", (object?)m.ResponsableCoordinacion ?? DBNull.Value),
                new OracleParameter("p_informe_incidente", (object?)m.InformeIncidente ?? DBNull.Value),
                new OracleParameter("p_lecciones_aprendidas", (object?)m.LeccionesAprendidas ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_activaciones_emergencia.update_activacion(:p_id_activacion, :p_fecha_hora_activacion, :p_tipo_emergencia, :p_id_plan_emergencia, :p_nivel_activacion, :p_descripcion_incidente, :p_lugar_incidente, :p_personas_afectadas, :p_personas_atendidas, :p_recursos_movilizados, :p_hora_control, :p_hora_fin, :p_estado, :p_responsable_coordinacion, :p_informe_incidente, :p_lecciones_aprendidas); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_activaciones_emergencia.delete_activacion(:p_id_activacion); END;", 
                new OracleParameter("p_id_activacion", id));
            return true;
        }

        public async Task<List<ActivacionesEmergencia>> ListarTodo() => await _context.Set<ActivacionesEmergencia>().ToListAsync();

        public async Task<ActivacionesEmergencia?> ObtenerPorId(int id) => await _context.Set<ActivacionesEmergencia>().FindAsync(id);
    }
}
