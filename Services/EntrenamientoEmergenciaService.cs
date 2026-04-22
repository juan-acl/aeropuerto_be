using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EntrenamientoEmergenciaService : IEntrenamientoEmergenciaService
    {
        private readonly DBContext _context;
        public EntrenamientoEmergenciaService(DBContext context) => _context = context;

        public async Task<List<EntrenamientosEmergencia>> ListarTodo()
        {
            try { return await _context.EntrenamientosEmergencia.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EntrenamientosEmergencia: {ex.Message}"); return new List<EntrenamientosEmergencia>(); }
        }

        public async Task<EntrenamientosEmergencia?> ObtenerPorId(int id)
        {
            try { return await _context.EntrenamientosEmergencia.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EntrenamientosEmergencia: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EntrenamientosEmergencia m)
        {
            try
            {
                string sql = "BEGIN pkg_entrenamientos_emergencia.insert_entrenamiento(:p_nombre_entrenamiento, :p_tipo_entrenamiento, :p_fecha_realizacion, :p_duracion_horas, :p_instructor, :p_participantes, :p_contenido, :p_evaluacion, :p_certificaciones_entregadas, :p_fecha_proximo_entrenamiento); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_nombre_entrenamiento", (object?)m.NombreEntrenamiento ?? DBNull.Value),
                new OracleParameter("p_tipo_entrenamiento", (object?)m.TipoEntrenamiento ?? DBNull.Value),
                new OracleParameter("p_fecha_realizacion", m.FechaRealizacion),
                new OracleParameter("p_duracion_horas", (object?)m.DuracionHoras ?? DBNull.Value),
                new OracleParameter("p_instructor", (object?)m.Instructor ?? DBNull.Value),
                new OracleParameter("p_participantes", (object?)m.Participantes ?? DBNull.Value),
                new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                new OracleParameter("p_evaluacion", (object?)m.Evaluacion ?? DBNull.Value),
                new OracleParameter("p_certificaciones_entregadas", (object?)m.CertificacionesEntregadas ?? DBNull.Value),
                new OracleParameter("p_fecha_proximo_entrenamiento", (object?)m.FechaProximoEntrenamiento ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar EntrenamientosEmergencia: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, EntrenamientosEmergencia m)
        {
            try
            {
                string sql = "BEGIN pkg_entrenamientos_emergencia.update_entrenamiento(:p_id_entrenamiento, :p_nombre_entrenamiento, :p_tipo_entrenamiento, :p_fecha_realizacion, :p_duracion_horas, :p_instructor, :p_participantes, :p_contenido, :p_evaluacion, :p_certificaciones_entregadas, :p_fecha_proximo_entrenamiento); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_entrenamiento", id),
                new OracleParameter("p_nombre_entrenamiento", (object?)m.NombreEntrenamiento ?? DBNull.Value),
                new OracleParameter("p_tipo_entrenamiento", (object?)m.TipoEntrenamiento ?? DBNull.Value),
                new OracleParameter("p_fecha_realizacion", m.FechaRealizacion),
                new OracleParameter("p_duracion_horas", (object?)m.DuracionHoras ?? DBNull.Value),
                new OracleParameter("p_instructor", (object?)m.Instructor ?? DBNull.Value),
                new OracleParameter("p_participantes", (object?)m.Participantes ?? DBNull.Value),
                new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                new OracleParameter("p_evaluacion", (object?)m.Evaluacion ?? DBNull.Value),
                new OracleParameter("p_certificaciones_entregadas", (object?)m.CertificacionesEntregadas ?? DBNull.Value),
                new OracleParameter("p_fecha_proximo_entrenamiento", (object?)m.FechaProximoEntrenamiento ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar EntrenamientosEmergencia: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_entrenamientos_emergencia.delete_entrenamiento(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar EntrenamientosEmergencia: {ex.Message}"); return false; }
        }
    }
}
