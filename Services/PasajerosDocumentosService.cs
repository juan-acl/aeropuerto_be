using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PasajerosDocumentosService : IPasajerosDocumentosService
    {
        private readonly DBContext _context;
        public PasajerosDocumentosService(DBContext context) => _context = context;

        public async Task<List<PasajerosDocumentosModel>> ListarTodo()
        {
            try { return await _context.PasajerosDocumentos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PasajerosDocumentosModel: {ex.Message}"); return new List<PasajerosDocumentosModel>(); }
        }

        public async Task<PasajerosDocumentosModel?> ObtenerPorId(int id)
        {
            try { return await _context.PasajerosDocumentos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PasajerosDocumentosModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PasajerosDocumentosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_documentos.insert_documento(:p_id_pasajero, :p_tipo_documento, :p_numero_documento, :p_pais_emision, :p_fecha_emision, :p_fecha_expiracion, :p_imagen_documento, :p_verificado); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_numero_documento", (object?)m.NumeroDocumento ?? DBNull.Value),
                new OracleParameter("p_pais_emision", (object?)m.PaisEmision ?? DBNull.Value),
                new OracleParameter("p_fecha_emision", (object?)m.FechaEmision ?? DBNull.Value),
                new OracleParameter("p_fecha_expiracion", (object?)m.FechaExpiracion ?? DBNull.Value),
                new OracleParameter("p_imagen_documento", (object?)m.ImagenDocumento ?? DBNull.Value),
                new OracleParameter("p_verificado", m.Verificado)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PasajerosDocumentosModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, PasajerosDocumentosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_documentos.update_documento(:p_id_documento, :p_id_pasajero, :p_tipo_documento, :p_numero_documento, :p_pais_emision, :p_fecha_emision, :p_fecha_expiracion, :p_imagen_documento, :p_verificado); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_documento", id),
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_numero_documento", (object?)m.NumeroDocumento ?? DBNull.Value),
                new OracleParameter("p_pais_emision", (object?)m.PaisEmision ?? DBNull.Value),
                new OracleParameter("p_fecha_emision", (object?)m.FechaEmision ?? DBNull.Value),
                new OracleParameter("p_fecha_expiracion", (object?)m.FechaExpiracion ?? DBNull.Value),
                new OracleParameter("p_imagen_documento", (object?)m.ImagenDocumento ?? DBNull.Value),
                new OracleParameter("p_verificado", m.Verificado)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PasajerosDocumentosModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_documentos.delete_documento(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PasajerosDocumentosModel: {ex.Message}"); return false; }
        }
    }
}
