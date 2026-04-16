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
            var sql = @"INSERT INTO incidentes_evidencia 
                        (id_incidente, tipo_evidencia, descripcion, archivo_evidencia, fecha_registro, registrado_por) 
                        VALUES (:p_inc, :p_tipo, :p_desc, :p_file, SYSTIMESTAMP, :p_user)";

            var parametros = new[] {
                new OracleParameter("p_inc", m.IdIncidente),
                new OracleParameter("p_tipo", m.TipoEvidencia),
                new OracleParameter("p_desc", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_file", (object?)m.ArchivoEvidencia ?? DBNull.Value),
                new OracleParameter("p_user", (object?)m.RegistradoPor ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
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
            var sql = "DELETE FROM incidentes_evidencia WHERE id_evidencia = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}