using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class DocumentoRequeridoService : IDocumentoRequeridoOperacionService
    {
        private readonly DBContext _context;
        public DocumentoRequeridoService(DBContext context) => _context = context;

        public async Task<bool> Insertar(DocumentosRequeridosOperacion m)
        {
            var p = new[] {
                new OracleParameter("p_tipo_operacion", (object?)m.TipoOperacion ?? DBNull.Value),
                new OracleParameter("p_nombre_documento", (object?)m.NombreDocumento ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_obligatorio", (object?)m.Obligatorio ?? DBNull.Value),
                new OracleParameter("p_formato_aceptado", (object?)m.FormatoAceptado ?? DBNull.Value),
                new OracleParameter("p_entidad_emisora_requerida", (object?)m.EntidadEmisoraRequerida ?? DBNull.Value),
                new OracleParameter("p_periodo_validez_dias", (object?)m.PeriodoValidezDias ?? DBNull.Value),
                new OracleParameter("p_requiere_original", (object?)m.RequiereOriginal ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_documentos_requeridos.insert_documento(:p_tipo_operacion, :p_nombre_documento, :p_descripcion, :p_obligatorio, :p_formato_aceptado, :p_entidad_emisora_requerida, :p_periodo_validez_dias, :p_requiere_original, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, DocumentosRequeridosOperacion m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_documento_requerido", m.IdDocumentoRequerido)
            };
            p.AddRange(new[] {
                new OracleParameter("p_tipo_operacion", (object?)m.TipoOperacion ?? DBNull.Value),
                new OracleParameter("p_nombre_documento", (object?)m.NombreDocumento ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_obligatorio", (object?)m.Obligatorio ?? DBNull.Value),
                new OracleParameter("p_formato_aceptado", (object?)m.FormatoAceptado ?? DBNull.Value),
                new OracleParameter("p_entidad_emisora_requerida", (object?)m.EntidadEmisoraRequerida ?? DBNull.Value),
                new OracleParameter("p_periodo_validez_dias", (object?)m.PeriodoValidezDias ?? DBNull.Value),
                new OracleParameter("p_requiere_original", (object?)m.RequiereOriginal ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_documentos_requeridos.update_documento(:p_id_documento_requerido, :p_tipo_operacion, :p_nombre_documento, :p_descripcion, :p_obligatorio, :p_formato_aceptado, :p_entidad_emisora_requerida, :p_periodo_validez_dias, :p_requiere_original, :p_activo); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_documentos_requeridos.delete_documento(:p_id_documento_requerido); END;",
                new OracleParameter("p_id_documento_requerido", id));
            return true;
        }

        public async Task<List<DocumentosRequeridosOperacion>> ListarTodo() => await _context.Set<DocumentosRequeridosOperacion>().ToListAsync();

        public async Task<DocumentosRequeridosOperacion?> ObtenerPorId(int id) => await _context.Set<DocumentosRequeridosOperacion>().FindAsync(id);
    }
}
