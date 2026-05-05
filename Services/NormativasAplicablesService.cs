using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class NormativasAplicablesService : INormativasAplicablesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public NormativasAplicablesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<NormativasAplicables>> ListarTodo()
        {
            try { return await _replica.NormativasAplicables.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo NormativasAplicables: {ex.Message}"); return new List<NormativasAplicables>(); }
        }

        public async Task<NormativasAplicables ?> ObtenerPorId(int id)
        {
            try { return await _replica.NormativasAplicables.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId NormativasAplicables: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(NormativasAplicables m)
        {
            try
            {
                string sql = "BEGIN pkg_normativas_aplicables.insert_normativa(:p_codigo_normativa, :p_titulo_normativa, :p_descripcion, :p_entidad_emisora, :p_pais_origen, :p_ambito_aplicacion, :p_fecha_publicacion, :p_fecha_vigencia, :p_fecha_ultima_actualizacion, :p_version, :p_documento_oficial, :p_url_referencia, :p_obligatoria, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_normativa", (object?)m.CodigoNormativa ?? DBNull.Value),
                    new OracleParameter("p_titulo_normativa", (object?)m.TituloNormativa ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_entidad_emisora", (object?)m.EntidadEmisora ?? DBNull.Value),
                    new OracleParameter("p_pais_origen", (object?)m.PaisOrigen ?? DBNull.Value),
                    new OracleParameter("p_ambito_aplicacion", (object?)m.AmbitoAplicacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_publicacion", (object?)m.FechaPublicacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_vigencia", (object?)m.FechaVigencia ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultima_actualizacion", (object?)m.FechaUltimaActualizacion ?? DBNull.Value),
                    new OracleParameter("p_version", (object?)m.Version ?? DBNull.Value),
                    new OracleParameter("p_documento_oficial", (object?)m.DocumentoOficial ?? DBNull.Value),
                    new OracleParameter("p_url_referencia", (object?)m.UrlReferencia ?? DBNull.Value),
                    new OracleParameter("p_obligatoria", (object?)m.Obligatoria ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar NormativasAplicables: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, NormativasAplicables m)
        {
            try
            {
                string sql = "BEGIN pkg_normativas_aplicables.update_normativa(:p_id_normativa, :p_codigo_normativa, :p_titulo_normativa, :p_descripcion, :p_entidad_emisora, :p_pais_origen, :p_ambito_aplicacion, :p_fecha_publicacion, :p_fecha_vigencia, :p_fecha_ultima_actualizacion, :p_version, :p_documento_oficial, :p_url_referencia, :p_obligatoria, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_normativa", id),
                    new OracleParameter("p_codigo_normativa", (object?)m.CodigoNormativa ?? DBNull.Value),
                    new OracleParameter("p_titulo_normativa", (object?)m.TituloNormativa ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_entidad_emisora", (object?)m.EntidadEmisora ?? DBNull.Value),
                    new OracleParameter("p_pais_origen", (object?)m.PaisOrigen ?? DBNull.Value),
                    new OracleParameter("p_ambito_aplicacion", (object?)m.AmbitoAplicacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_publicacion", (object?)m.FechaPublicacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_vigencia", (object?)m.FechaVigencia ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultima_actualizacion", (object?)m.FechaUltimaActualizacion ?? DBNull.Value),
                    new OracleParameter("p_version", (object?)m.Version ?? DBNull.Value),
                    new OracleParameter("p_documento_oficial", (object?)m.DocumentoOficial ?? DBNull.Value),
                    new OracleParameter("p_url_referencia", (object?)m.UrlReferencia ?? DBNull.Value),
                    new OracleParameter("p_obligatoria", (object?)m.Obligatoria ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar NormativasAplicables: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_normativas_aplicables.delete_normativa(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar NormativasAplicables: {ex.Message}"); throw; }
        }
    }
}
