using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class CampanaMarketingService : ICampanaMarketingService
    {
        private readonly DBContext _context;
        public CampanaMarketingService(DBContext context) => _context = context;

        public async Task<bool> Insertar(CampanasMarketing m)
        {
            var p = new[] {
                new OracleParameter("p_nombre_campana", (object?)m.NombreCampana ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_tipo_campana", (object?)m.TipoCampana ?? DBNull.Value),
                new OracleParameter("p_objetivo", (object?)m.Objetivo ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_presupuesto", (object?)m.Presupuesto ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_costo_real", (object?)m.CostoReal ?? DBNull.Value),
                new OracleParameter("p_publico_objetivo", (object?)m.PublicoObjetivo ?? DBNull.Value),
                new OracleParameter("p_segmento_objetivo", (object?)m.SegmentoObjetivo ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                new OracleParameter("p_responsable", (object?)m.Responsable ?? DBNull.Value),
                new OracleParameter("p_resultados", (object?)m.Resultados ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_campanas_marketing.insert_campana(:p_nombre_campana, :p_descripcion, :p_tipo_campana, :p_objetivo, :p_fecha_inicio, :p_fecha_fin, :p_presupuesto, :p_moneda, :p_costo_real, :p_publico_objetivo, :p_segmento_objetivo, :p_activa, :p_responsable, :p_resultados); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, CampanasMarketing m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_campana_marketing", m.IdCampanaMarketing)
            };
            p.AddRange(new[] {
                new OracleParameter("p_nombre_campana", (object?)m.NombreCampana ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_tipo_campana", (object?)m.TipoCampana ?? DBNull.Value),
                new OracleParameter("p_objetivo", (object?)m.Objetivo ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_presupuesto", (object?)m.Presupuesto ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_costo_real", (object?)m.CostoReal ?? DBNull.Value),
                new OracleParameter("p_publico_objetivo", (object?)m.PublicoObjetivo ?? DBNull.Value),
                new OracleParameter("p_segmento_objetivo", (object?)m.SegmentoObjetivo ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                new OracleParameter("p_responsable", (object?)m.Responsable ?? DBNull.Value),
                new OracleParameter("p_resultados", (object?)m.Resultados ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_campanas_marketing.update_campana(:p_id_campana_marketing, :p_nombre_campana, :p_descripcion, :p_tipo_campana, :p_objetivo, :p_fecha_inicio, :p_fecha_fin, :p_presupuesto, :p_moneda, :p_costo_real, :p_publico_objetivo, :p_segmento_objetivo, :p_activa, :p_responsable, :p_resultados); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_campanas_marketing.delete_campana(:p_id_campana_marketing); END;",
                new OracleParameter("p_id_campana_marketing", id));
            return true;
        }

        public async Task<List<CampanasMarketing>> ListarTodo() => await _context.Set<CampanasMarketing>().ToListAsync();

        public async Task<CampanasMarketing?> ObtenerPorId(int id) => await _context.Set<CampanasMarketing>().FindAsync(id);
    }
}
