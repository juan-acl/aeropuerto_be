using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CampanasMarketingService : ICampanasMarketingService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CampanasMarketingService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CampanasMarketing>> ListarTodo()
        {
            try { return await _replica.CampanasMarketing.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CampanasMarketing: {ex.Message}"); return new List<CampanasMarketing>(); }
        }

        public async Task<CampanasMarketing ?> ObtenerPorId(int id)
        {
            try { return await _replica.CampanasMarketing.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CampanasMarketing: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CampanasMarketing m)
        {
            try
            {
                string sql = "BEGIN pkg_campanas_marketing.insert_campana(:p_nombre_campana, :p_descripcion, :p_tipo_campana, :p_objetivo, :p_fecha_inicio, :p_fecha_fin, :p_presupuesto, :p_moneda, :p_costo_real, :p_publico_objetivo, :p_segmento_objetivo, :p_activa, :p_responsable, :p_resultados); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nombre_campana", (object?)m.NombreCampana ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_campana", (object?)m.TipoCampana ?? DBNull.Value),
                    new OracleParameter("p_objetivo", (object?)m.Objetivo ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", m.FechaInicio),
                    new OracleParameter("p_fecha_fin", m.FechaFin),
                    new OracleParameter("p_presupuesto", (object?)m.Presupuesto ?? DBNull.Value),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_costo_real", (object?)m.CostoReal ?? DBNull.Value),
                    new OracleParameter("p_publico_objetivo", (object?)m.PublicoObjetivo ?? DBNull.Value),
                    new OracleParameter("p_segmento_objetivo", (object?)m.SegmentoObjetivo ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                    new OracleParameter("p_responsable", (object?)m.Responsable ?? DBNull.Value),
                    new OracleParameter("p_resultados", (object?)m.Resultados ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar CampanasMarketing: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, CampanasMarketing m)
        {
            try
            {
                string sql = "BEGIN pkg_campanas_marketing.update_campana(:p_id_campana_marketing, :p_nombre_campana, :p_descripcion, :p_tipo_campana, :p_objetivo, :p_fecha_inicio, :p_fecha_fin, :p_presupuesto, :p_moneda, :p_costo_real, :p_publico_objetivo, :p_segmento_objetivo, :p_activa, :p_responsable, :p_resultados); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_campana_marketing", id),
                    new OracleParameter("p_nombre_campana", (object?)m.NombreCampana ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_campana", (object?)m.TipoCampana ?? DBNull.Value),
                    new OracleParameter("p_objetivo", (object?)m.Objetivo ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", m.FechaInicio),
                    new OracleParameter("p_fecha_fin", m.FechaFin),
                    new OracleParameter("p_presupuesto", (object?)m.Presupuesto ?? DBNull.Value),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_costo_real", (object?)m.CostoReal ?? DBNull.Value),
                    new OracleParameter("p_publico_objetivo", (object?)m.PublicoObjetivo ?? DBNull.Value),
                    new OracleParameter("p_segmento_objetivo", (object?)m.SegmentoObjetivo ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                    new OracleParameter("p_responsable", (object?)m.Responsable ?? DBNull.Value),
                    new OracleParameter("p_resultados", (object?)m.Resultados ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar CampanasMarketing: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_campanas_marketing.delete_campana(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar CampanasMarketing: {ex.Message}"); throw; }
        }
    }
}
