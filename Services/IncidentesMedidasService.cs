using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class IncidentesMedidasService : IIncidentesMedidasService
    {
        private readonly DBContext _context;

        public IncidentesMedidasService(DBContext context) => _context = context;

        public async Task<bool> AplicarMedida(IncidentesMedidasModel m)
        {
            var sql = @"INSERT INTO incidentes_medidas 
                        (id_incidente, tipo_medida, descripcion, fecha_aplicacion, aplicado_por, 
                         vigencia_dias, fecha_vencimiento, observaciones) 
                        VALUES (:p_inc, :p_tipo, :p_desc, SYSTIMESTAMP, :p_user, 
                                :p_dias, :p_venc, :p_obs)";

            // Cálculo opcional de fecha de vencimiento si hay vigencia
            object fechaVenc = DBNull.Value;
            if (m.VigenciaDias.HasValue)
            {
                fechaVenc = DateTime.Now.AddDays(m.VigenciaDias.Value);
            }

            var parametros = new[] {
                new OracleParameter("p_inc", m.IdIncidente),
                new OracleParameter("p_tipo", m.TipoMedida),
                new OracleParameter("p_desc", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_user", (object?)m.AplicadoPor ?? DBNull.Value),
                new OracleParameter("p_dias", (object?)m.VigenciaDias ?? DBNull.Value),
                new OracleParameter("p_venc", m.FechaVencimiento ?? fechaVenc),
                new OracleParameter("p_obs", (object?)m.Observaciones ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<IncidentesMedidasModel>> ListarPorIncidente(int idIncidente)
        {
            return await _context.IncidentesMedidas
                .Where(m => m.IdIncidente == idIncidente)
                .ToListAsync();
        }

        public async Task<bool> ActualizarMedida(int id, IncidentesMedidasModel m)
        {
            var sql = @"UPDATE incidentes_medidas 
                        SET tipo_medida = :p_tipo, descripcion = :p_desc, observaciones = :p_obs 
                        WHERE id_medida = :p_id";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_tipo", m.TipoMedida),
                new OracleParameter("p_desc", m.Descripcion),
                new OracleParameter("p_obs", m.Observaciones),
                new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM incidentes_medidas WHERE id_medida = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}