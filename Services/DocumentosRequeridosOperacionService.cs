using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class DocumentosRequeridosOperacionService : IDocumentosRequeridosOperacionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public DocumentosRequeridosOperacionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<DocumentosRequeridosOperacion>> ListarTodo()
        {
            try { return await _replica.DocumentosRequeridos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo DocumentosRequeridosOperacion: {ex.Message}"); return new List<DocumentosRequeridosOperacion>(); }
        }

        public async Task<DocumentosRequeridosOperacion ?> ObtenerPorId(int id)
        {
            try { return await _replica.DocumentosRequeridos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId DocumentosRequeridosOperacion: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(DocumentosRequeridosOperacion m)
        {
            try
            {
                string sql = "BEGIN pkg_documentos_requeridos.insert_documento(:p_tipo_operacion, :p_nombre_documento, :p_descripcion, :p_obligatorio, :p_formato_aceptado, :p_entidad_emisora_requerida, :p_periodo_validez_dias, :p_requiere_original, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_tipo_operacion", (object?)m.TipoOperacion ?? DBNull.Value),
                    new OracleParameter("p_nombre_documento", (object?)m.NombreDocumento ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_obligatorio", (object?)m.Obligatorio ?? DBNull.Value),
                    new OracleParameter("p_formato_aceptado", (object?)m.FormatoAceptado ?? DBNull.Value),
                    new OracleParameter("p_entidad_emisora_requerida", (object?)m.EntidadEmisoraRequerida ?? DBNull.Value),
                    new OracleParameter("p_periodo_validez_dias", (object?)m.PeriodoValidezDias ?? DBNull.Value),
                    new OracleParameter("p_requiere_original", (object?)m.RequiereOriginal ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar DocumentosRequeridosOperacion: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, DocumentosRequeridosOperacion m)
        {
            try
            {
                string sql = "BEGIN pkg_documentos_requeridos.update_documento(:p_id_documento_requerido, :p_tipo_operacion, :p_nombre_documento, :p_descripcion, :p_obligatorio, :p_formato_aceptado, :p_entidad_emisora_requerida, :p_periodo_validez_dias, :p_requiere_original, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_documento_requerido", id),
                    new OracleParameter("p_tipo_operacion", (object?)m.TipoOperacion ?? DBNull.Value),
                    new OracleParameter("p_nombre_documento", (object?)m.NombreDocumento ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_obligatorio", (object?)m.Obligatorio ?? DBNull.Value),
                    new OracleParameter("p_formato_aceptado", (object?)m.FormatoAceptado ?? DBNull.Value),
                    new OracleParameter("p_entidad_emisora_requerida", (object?)m.EntidadEmisoraRequerida ?? DBNull.Value),
                    new OracleParameter("p_periodo_validez_dias", (object?)m.PeriodoValidezDias ?? DBNull.Value),
                    new OracleParameter("p_requiere_original", (object?)m.RequiereOriginal ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar DocumentosRequeridosOperacion: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_documentos_requeridos.delete_documento(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar DocumentosRequeridosOperacion: {ex.Message}"); throw; }
        }
    }
}
