using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PoliticaSeguridadService : IPoliticaSeguridadService
    {
        private readonly DBContext _context;
        public PoliticaSeguridadService(DBContext context) => _context = context;

        public async Task<bool> Insertar(PoliticasSeguridad m)
        {
            var p = new[] {
                new OracleParameter("p_nombre_politica", (object?)m.NombrePolitica ?? DBNull.Value),
                new OracleParameter("p_version", (object?)m.Version ?? DBNull.Value),
                new OracleParameter("p_fecha_aprobacion", (object?)m.FechaAprobacion ?? DBNull.Value),
                new OracleParameter("p_fecha_vigencia", (object?)m.FechaVigencia ?? DBNull.Value),
                new OracleParameter("p_fecha_revision", (object?)m.FechaRevision ?? DBNull.Value),
                new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                new OracleParameter("p_aprobado_por", (object?)m.AprobadoPor ?? DBNull.Value),
                new OracleParameter("p_responsable_ejecucion", (object?)m.ResponsableEjecucion ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_politicas_seguridad.insert_politica(:p_nombre_politica, :p_version, :p_fecha_aprobacion, :p_fecha_vigencia, :p_fecha_revision, :p_contenido, :p_aprobado_por, :p_responsable_ejecucion, :p_activa); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, PoliticasSeguridad m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_politica", m.IdPolitica)
            };
            p.AddRange(new[] {
                new OracleParameter("p_nombre_politica", (object?)m.NombrePolitica ?? DBNull.Value),
                new OracleParameter("p_version", (object?)m.Version ?? DBNull.Value),
                new OracleParameter("p_fecha_aprobacion", (object?)m.FechaAprobacion ?? DBNull.Value),
                new OracleParameter("p_fecha_vigencia", (object?)m.FechaVigencia ?? DBNull.Value),
                new OracleParameter("p_fecha_revision", (object?)m.FechaRevision ?? DBNull.Value),
                new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                new OracleParameter("p_aprobado_por", (object?)m.AprobadoPor ?? DBNull.Value),
                new OracleParameter("p_responsable_ejecucion", (object?)m.ResponsableEjecucion ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_politicas_seguridad.update_politica(:p_id_politica, :p_nombre_politica, :p_version, :p_fecha_aprobacion, :p_fecha_vigencia, :p_fecha_revision, :p_contenido, :p_aprobado_por, :p_responsable_ejecucion, :p_activa); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_politicas_seguridad.delete_politica(:p_id_politica); END;",
                new OracleParameter("p_id_politica", id));
            return true;
        }

        public async Task<List<PoliticasSeguridad>> ListarTodo() => await _context.Set<PoliticasSeguridad>().ToListAsync();

        public async Task<PoliticasSeguridad?> ObtenerPorId(int id) => await _context.Set<PoliticasSeguridad>().FindAsync(id);
    }
}
