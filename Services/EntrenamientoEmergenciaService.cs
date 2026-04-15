using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EntrenamientoEmergenciaService : IEntrenamientoEmergenciaService
    {
        private readonly DBContext _context;
        public EntrenamientoEmergenciaService(DBContext context) => _context = context;

        public async Task<bool> Insertar(EntrenamientosEmergencia m)
        {
            var p = new[] {
                new OracleParameter("p_nombre_entrenamiento", (object?)m.NombreEntrenamiento ?? DBNull.Value),
                new OracleParameter("p_tipo_entrenamiento", (object?)m.TipoEntrenamiento ?? DBNull.Value),
                new OracleParameter("p_fecha_realizacion", (object?)m.FechaRealizacion ?? DBNull.Value),
                new OracleParameter("p_duracion_horas", (object?)m.DuracionHoras ?? DBNull.Value),
                new OracleParameter("p_instructor", (object?)m.Instructor ?? DBNull.Value),
                new OracleParameter("p_participantes", (object?)m.Participantes ?? DBNull.Value),
                new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                new OracleParameter("p_evaluacion", (object?)m.Evaluacion ?? DBNull.Value),
                new OracleParameter("p_certificaciones_entregadas", (object?)m.CertificacionesEntregadas ?? DBNull.Value),
                new OracleParameter("p_fecha_proximo_entrenamiento", (object?)m.FechaProximoEntrenamiento ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_entrenamientos_emergencia.insert_entrenamiento(:p_nombre_entrenamiento, :p_tipo_entrenamiento, :p_fecha_realizacion, :p_duracion_horas, :p_instructor, :p_participantes, :p_contenido, :p_evaluacion, :p_certificaciones_entregadas, :p_fecha_proximo_entrenamiento); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, EntrenamientosEmergencia m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_entrenamiento", m.IdEntrenamiento)
            };
            p.AddRange(new[] {
                new OracleParameter("p_nombre_entrenamiento", (object?)m.NombreEntrenamiento ?? DBNull.Value),
                new OracleParameter("p_tipo_entrenamiento", (object?)m.TipoEntrenamiento ?? DBNull.Value),
                new OracleParameter("p_fecha_realizacion", (object?)m.FechaRealizacion ?? DBNull.Value),
                new OracleParameter("p_duracion_horas", (object?)m.DuracionHoras ?? DBNull.Value),
                new OracleParameter("p_instructor", (object?)m.Instructor ?? DBNull.Value),
                new OracleParameter("p_participantes", (object?)m.Participantes ?? DBNull.Value),
                new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                new OracleParameter("p_evaluacion", (object?)m.Evaluacion ?? DBNull.Value),
                new OracleParameter("p_certificaciones_entregadas", (object?)m.CertificacionesEntregadas ?? DBNull.Value),
                new OracleParameter("p_fecha_proximo_entrenamiento", (object?)m.FechaProximoEntrenamiento ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_entrenamientos_emergencia.update_entrenamiento(:p_id_entrenamiento, :p_nombre_entrenamiento, :p_tipo_entrenamiento, :p_fecha_realizacion, :p_duracion_horas, :p_instructor, :p_participantes, :p_contenido, :p_evaluacion, :p_certificaciones_entregadas, :p_fecha_proximo_entrenamiento); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_entrenamientos_emergencia.delete_entrenamiento(:p_id_entrenamiento); END;", 
                new OracleParameter("p_id_entrenamiento", id));
            return true;
        }

        public async Task<List<EntrenamientosEmergencia>> ListarTodo() => await _context.Set<EntrenamientosEmergencia>().ToListAsync();

        public async Task<EntrenamientosEmergencia?> ObtenerPorId(int id) => await _context.Set<EntrenamientosEmergencia>().FindAsync(id);
    }
}
