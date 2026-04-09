using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PasajerosDocumentosService : IPasajerosDocumentosService
    {
        private readonly DBContext _context;

        public PasajerosDocumentosService(DBContext context) => _context = context;

        public async Task<bool> Insertar(PasajerosDocumentosModel m)
        {
            var sql = @"BEGIN pkg_pasajeros.insert_documento(
                :p_id_pasajero, :p_tipo, :p_num, :p_pais, :p_f_emision, 
                :p_f_expira, :p_imagen); END;";

            var parametros = new[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_tipo", m.TipoDocumento),
                new OracleParameter("p_num", m.NumeroDocumento),
                new OracleParameter("p_pais", (object?)m.PaisEmision ?? DBNull.Value),
                new OracleParameter("p_f_emision", (object?)m.FechaEmision ?? DBNull.Value),
                new OracleParameter("p_f_expira", (object?)m.FechaExpiracion ?? DBNull.Value),
                new OracleParameter("p_imagen", (object?)m.ImagenDocumento ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<PasajerosDocumentosModel>> ListarPorPasajero(int idPasajero)
        {
            return await _context.PasajerosDocumentos
                .Where(d => d.IdPasajero == idPasajero)
                .ToListAsync();
        }

        public async Task<bool> VerificarDocumento(int idDocumento, int estado)
        {
            var sql = "UPDATE pasajeros_documentos SET verificado = :p_estado WHERE id_documento = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_estado", estado),
                new OracleParameter("p_id", idDocumento));
            return true;
        }

        public async Task<bool> Eliminar(int idDocumento)
        {
            var sql = "DELETE FROM pasajeros_documentos WHERE id_documento = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", idDocumento));
            return true;
        }
    }
}