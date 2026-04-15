using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class NormativaAplicableService : INormativaAplicableService
    {
        private readonly DBContext _context;
        public NormativaAplicableService(DBContext context) => _context = context;

        public async Task<bool> Insertar(NormativasAplicables m)
        {
            var p = new[] {
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
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_normativas_aplicables.insert_normativa(:p_codigo_normativa, :p_titulo_normativa, :p_descripcion, :p_entidad_emisora, :p_pais_origen, :p_ambito_aplicacion, :p_fecha_publicacion, :p_fecha_vigencia, :p_fecha_ultima_actualizacion, :p_version, :p_documento_oficial, :p_url_referencia, :p_obligatoria, :p_activa); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, NormativasAplicables m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_normativa", m.IdNormativa)
            };
            p.AddRange(new[] {
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
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_normativas_aplicables.update_normativa(:p_id_normativa, :p_codigo_normativa, :p_titulo_normativa, :p_descripcion, :p_entidad_emisora, :p_pais_origen, :p_ambito_aplicacion, :p_fecha_publicacion, :p_fecha_vigencia, :p_fecha_ultima_actualizacion, :p_version, :p_documento_oficial, :p_url_referencia, :p_obligatoria, :p_activa); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_normativas_aplicables.delete_normativa(:p_id_normativa); END;", 
                new OracleParameter("p_id_normativa", id));
            return true;
        }

        public async Task<List<NormativasAplicables>> ListarTodo() => await _context.Set<NormativasAplicables>().ToListAsync();

        public async Task<NormativasAplicables?> ObtenerPorId(int id) => await _context.Set<NormativasAplicables>().FindAsync(id);
    }
}
