using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class VisitasSeguridadService : IVisitasSeguridadService
    {
        private readonly DBContext _context;
        public VisitasSeguridadService(DBContext context) => _context = context;

        public async Task<List<VisitasSeguridadModel>> ListarTodo()
        {
            try { return await _context.VisitasSeguridad.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo VisitasSeguridadModel: {ex.Message}"); return new List<VisitasSeguridadModel>(); }
        }

        public async Task<VisitasSeguridadModel?> ObtenerPorId(int id)
        {
            try { return await _context.VisitasSeguridad.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId VisitasSeguridadModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(VisitasSeguridadModel m)
        {
            try
            {
                string sql = "BEGIN pkg_visitas_seguridad.insert_visita(:p_codigo_aeropuerto, :p_fecha_visita, :p_hora_entrada, :p_hora_salida, :p_nombre_visitante, :p_tipo_documento, :p_numero_documento, :p_empresa, :p_motivo_visita, :p_persona_autoriza, :p_area_visitada, :p_escort_requerido, :p_escort_asignado); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_fecha_visita", (object?)m.FechaVisita ?? DBNull.Value),
                new OracleParameter("p_hora_entrada", (object?)m.HoraEntrada ?? DBNull.Value),
                new OracleParameter("p_hora_salida", (object?)m.HoraSalida ?? DBNull.Value),
                new OracleParameter("p_nombre_visitante", (object?)m.NombreVisitante ?? DBNull.Value),
                new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_numero_documento", (object?)m.NumeroDocumento ?? DBNull.Value),
                new OracleParameter("p_empresa", (object?)m.Empresa ?? DBNull.Value),
                new OracleParameter("p_motivo_visita", (object?)m.MotivoVisita ?? DBNull.Value),
                new OracleParameter("p_persona_autoriza", (object?)m.PersonaAutoriza ?? DBNull.Value),
                new OracleParameter("p_area_visitada", (object?)m.AreaVisitada ?? DBNull.Value),
                new OracleParameter("p_escort_requerido", m.EscortRequerido),
                new OracleParameter("p_escort_asignado", (object?)m.EscortAsignado ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar VisitasSeguridadModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, VisitasSeguridadModel m)
        {
            try
            {
                string sql = "BEGIN pkg_visitas_seguridad.update_visita(:p_id_visita, :p_codigo_aeropuerto, :p_fecha_visita, :p_hora_entrada, :p_hora_salida, :p_nombre_visitante, :p_tipo_documento, :p_numero_documento, :p_empresa, :p_motivo_visita, :p_persona_autoriza, :p_area_visitada, :p_escort_requerido, :p_escort_asignado); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_visita", id),
                new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_fecha_visita", (object?)m.FechaVisita ?? DBNull.Value),
                new OracleParameter("p_hora_entrada", (object?)m.HoraEntrada ?? DBNull.Value),
                new OracleParameter("p_hora_salida", (object?)m.HoraSalida ?? DBNull.Value),
                new OracleParameter("p_nombre_visitante", (object?)m.NombreVisitante ?? DBNull.Value),
                new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_numero_documento", (object?)m.NumeroDocumento ?? DBNull.Value),
                new OracleParameter("p_empresa", (object?)m.Empresa ?? DBNull.Value),
                new OracleParameter("p_motivo_visita", (object?)m.MotivoVisita ?? DBNull.Value),
                new OracleParameter("p_persona_autoriza", (object?)m.PersonaAutoriza ?? DBNull.Value),
                new OracleParameter("p_area_visitada", (object?)m.AreaVisitada ?? DBNull.Value),
                new OracleParameter("p_escort_requerido", m.EscortRequerido),
                new OracleParameter("p_escort_asignado", (object?)m.EscortAsignado ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar VisitasSeguridadModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_visitas_seguridad.delete_visita(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar VisitasSeguridadModel: {ex.Message}"); return false; }
        }
    }
}
