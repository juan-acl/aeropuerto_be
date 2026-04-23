using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class IncidentesEvidenciaService : IIncidentesEvidenciaService
    {
        private readonly DBContext _context;

        public IncidentesEvidenciaService(DBContext context) => _context = context;

        public async Task<bool> CargarEvidencia(IncidentesEvidenciaModel m)
        {
            var sql = "pkg_incidentes_evidencia.insert_evidencia";

            var parametros = new[] {
                new OracleParameter("p_id_incidente", m.IdIncidente),
                new OracleParameter("p_tipo_evidencia", m.TipoEvidencia),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_archivo_evidencia", (object?)m.ArchivoEvidencia ?? DBNull.Value),
                new OracleParameter("p_registrado_por", (object?)m.RegistradoPor ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_incidente, :p_tipo_evidencia, :p_descripcion, :p_archivo_evidencia, :p_registrado_por); END;", parametros);
            return true;
        }

        public async Task<List<IncidentesEvidenciaModel>> ListarPorIncidente(int idIncidente)
        {
            return await _context.IncidentesEvidencia
                .Where(e => e.IdIncidente == idIncidente)
                .Select(e => new IncidentesEvidenciaModel
                {
                    IdEvidencia = e.IdEvidencia,
                    IdIncidente = e.IdIncidente,
                    TipoEvidencia = e.TipoEvidencia,
                    Descripcion = e.Descripcion,
                    FechaRegistro = e.FechaRegistro,
                    RegistradoPor = e.RegistradoPor,
                    // IMPORTANTE: No incluimos la propiedad ArchivoEvidencia aquí
                    ArchivoEvidencia = null
                })
                .ToListAsync();
        }

        public async Task<IncidentesEvidenciaModel?> ObtenerPorId(int id)
        {
            return await _context.IncidentesEvidencia.FindAsync(id);
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "pkg_incidentes_evidencia.delete_evidencia";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_evidencia); END;", new OracleParameter("p_id_evidencia", id));
            return true;
        }
    }
}