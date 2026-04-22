using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class DocumentoImportanteService : IDocumentoImportanteService
    {
        private readonly DBContext _context;
        public DocumentoImportanteService(DBContext context) => _context = context;

        public async Task<List<DocumentosImportantes>> ListarTodo()
        {
            try { return await _context.DocumentosImportantes.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo DocumentosImportantes: {ex.Message}"); return new List<DocumentosImportantes>(); }
        }

        public async Task<DocumentosImportantes?> ObtenerPorId(int id)
        {
            try { return await _context.DocumentosImportantes.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId DocumentosImportantes: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(DocumentosImportantes m)
        {
            try
            {
                string sql = "BEGIN pkg_documentos_importantes.insert_documento(:p_codigo_documento, :p_titulo, :p_tipo_documento, :p_fecha_creacion, :p_fecha_revision, :p_version, :p_autor, :p_area_responsable, :p_palabras_clave, :p_resumen, :p_archivo_digital, :p_ubicacion_fisica, :p_confidencial, :p_niveles_acceso, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_codigo_documento", (object?)m.CodigoDocumento ?? DBNull.Value),
                new OracleParameter("p_titulo", (object?)m.Titulo ?? DBNull.Value),
                new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_fecha_creacion", (object?)m.FechaCreacion ?? DBNull.Value),
                new OracleParameter("p_fecha_revision", (object?)m.FechaRevision ?? DBNull.Value),
                new OracleParameter("p_version", (object?)m.Version ?? DBNull.Value),
                new OracleParameter("p_autor", (object?)m.Autor ?? DBNull.Value),
                new OracleParameter("p_area_responsable", (object?)m.AreaResponsable ?? DBNull.Value),
                new OracleParameter("p_palabras_clave", (object?)m.PalabrasClave ?? DBNull.Value),
                new OracleParameter("p_resumen", (object?)m.Resumen ?? DBNull.Value),
                new OracleParameter("p_archivo_digital", OracleDbType.Blob) { Value = (object?)m.ArchivoDigital ?? DBNull.Value },
                new OracleParameter("p_ubicacion_fisica", (object?)m.UbicacionFisica ?? DBNull.Value),
                new OracleParameter("p_confidencial", (object?)m.Confidencial ?? DBNull.Value),
                new OracleParameter("p_niveles_acceso", (object?)m.NivelesAcceso ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar DocumentosImportantes: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, DocumentosImportantes m)
        {
            try
            {
                string sql = "BEGIN pkg_documentos_importantes.update_documento(:p_id_documento_importante, :p_codigo_documento, :p_titulo, :p_tipo_documento, :p_fecha_creacion, :p_fecha_revision, :p_version, :p_autor, :p_area_responsable, :p_palabras_clave, :p_resumen, :p_archivo_digital, :p_ubicacion_fisica, :p_confidencial, :p_niveles_acceso, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_documento_importante", id),
                new OracleParameter("p_codigo_documento", (object?)m.CodigoDocumento ?? DBNull.Value),
                new OracleParameter("p_titulo", (object?)m.Titulo ?? DBNull.Value),
                new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_fecha_creacion", (object?)m.FechaCreacion ?? DBNull.Value),
                new OracleParameter("p_fecha_revision", (object?)m.FechaRevision ?? DBNull.Value),
                new OracleParameter("p_version", (object?)m.Version ?? DBNull.Value),
                new OracleParameter("p_autor", (object?)m.Autor ?? DBNull.Value),
                new OracleParameter("p_area_responsable", (object?)m.AreaResponsable ?? DBNull.Value),
                new OracleParameter("p_palabras_clave", (object?)m.PalabrasClave ?? DBNull.Value),
                new OracleParameter("p_resumen", (object?)m.Resumen ?? DBNull.Value),
                new OracleParameter("p_archivo_digital", OracleDbType.Blob) { Value = (object?)m.ArchivoDigital ?? DBNull.Value },
                new OracleParameter("p_ubicacion_fisica", (object?)m.UbicacionFisica ?? DBNull.Value),
                new OracleParameter("p_confidencial", (object?)m.Confidencial ?? DBNull.Value),
                new OracleParameter("p_niveles_acceso", (object?)m.NivelesAcceso ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar DocumentosImportantes: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_documentos_importantes.delete_documento(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar DocumentosImportantes: {ex.Message}"); return false; }
        }
    }
}
