using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PoliticasSeguridadService : IPoliticasSeguridadService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PoliticasSeguridadService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PoliticasSeguridad>> ListarTodo()
        {
            try { return await _replica.PoliticasSeguridad.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PoliticasSeguridad: {ex.Message}"); return new List<PoliticasSeguridad>(); }
        }

        public async Task<PoliticasSeguridad ?> ObtenerPorId(int id)
        {
            try { return await _replica.PoliticasSeguridad.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PoliticasSeguridad: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PoliticasSeguridad m)
        {
            try
            {
                string sql = "BEGIN pkg_politicas_seguridad.insert_politica(:p_nombre_politica, :p_version, :p_fecha_aprobacion, :p_fecha_vigencia, :p_fecha_revision, :p_contenido, :p_aprobado_por, :p_responsable_ejecucion, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nombre_politica", (object?)m.NombrePolitica ?? DBNull.Value),
                    new OracleParameter("p_version", (object?)m.Version ?? DBNull.Value),
                    new OracleParameter("p_fecha_aprobacion", (object?)m.FechaAprobacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_vigencia", (object?)m.FechaVigencia ?? DBNull.Value),
                    new OracleParameter("p_fecha_revision", (object?)m.FechaRevision ?? DBNull.Value),
                    new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                    new OracleParameter("p_aprobado_por", (object?)m.AprobadoPor ?? DBNull.Value),
                    new OracleParameter("p_responsable_ejecucion", (object?)m.ResponsableEjecucion ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PoliticasSeguridad: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, PoliticasSeguridad m)
        {
            try
            {
                string sql = "BEGIN pkg_politicas_seguridad.update_politica(:p_id_politica, :p_nombre_politica, :p_version, :p_fecha_aprobacion, :p_fecha_vigencia, :p_fecha_revision, :p_contenido, :p_aprobado_por, :p_responsable_ejecucion, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_politica", id),
                    new OracleParameter("p_nombre_politica", (object?)m.NombrePolitica ?? DBNull.Value),
                    new OracleParameter("p_version", (object?)m.Version ?? DBNull.Value),
                    new OracleParameter("p_fecha_aprobacion", (object?)m.FechaAprobacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_vigencia", (object?)m.FechaVigencia ?? DBNull.Value),
                    new OracleParameter("p_fecha_revision", (object?)m.FechaRevision ?? DBNull.Value),
                    new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                    new OracleParameter("p_aprobado_por", (object?)m.AprobadoPor ?? DBNull.Value),
                    new OracleParameter("p_responsable_ejecucion", (object?)m.ResponsableEjecucion ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PoliticasSeguridad: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_politicas_seguridad.delete_politica(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PoliticasSeguridad: {ex.Message}"); throw; }
        }
    }
}
