using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class HistorialComunicacionService : IHistorialComunicacionService
    {
        private readonly DBContext _context;

        public HistorialComunicacionService(DBContext context) => _context = context;

        public async Task<bool> Insertar(HistorialComunicacionModel m)
        {
            var sql = @"INSERT INTO historial_comunicaciones 
                (id_pasajero, tipo_comunicacion, fecha_envio, asunto, contenido, estado, respuesta_recibida) 
                VALUES (:p_id, :p_tipo, SYSTIMESTAMP, :p_asunto, :p_cont, :p_est, :p_resp)";

            var parametros = new[] {
        new OracleParameter("p_id", m.IdPasajero),
        new OracleParameter("p_tipo", m.TipoComunicacion),
        new OracleParameter("p_asunto", (object?)m.Asunto ?? DBNull.Value),
        new OracleParameter("p_cont", (object?)m.Contenido ?? DBNull.Value),
        new OracleParameter("p_est", m.Estado ?? "ENVIADO"),
        new OracleParameter("p_resp", m.RespuestaRecibida)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<HistorialComunicacionModel>> ListarPorPasajero(int idPasajero)
        {
            return await _context.HistorialComunicacion
                .Where(c => c.IdPasajero == idPasajero)
                .OrderByDescending(c => c.FechaEnvio)
                .ToListAsync();
        }

        public async Task<bool> Actualizar(int id, HistorialComunicacionModel m)
        {
         
            var sql = @"UPDATE historial_comunicaciones 
                SET tipo_comunicacion = :p_tipo, 
                    asunto = :p_asunto, 
                    contenido = :p_cont, 
                    estado = :p_est, 
                    respuesta_recibida = :p_resp 
                WHERE id_comunicacion = :p_id";

            var parametros = new[] {
        new OracleParameter("p_tipo", m.TipoComunicacion),
        new OracleParameter("p_asunto", (object?)m.Asunto ?? DBNull.Value),
        new OracleParameter("p_cont", (object?)m.Contenido ?? DBNull.Value),
        new OracleParameter("p_est", m.Estado),
        new OracleParameter("p_resp", m.RespuestaRecibida),
        new OracleParameter("p_id", id)
    };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM historial_comunicaciones WHERE id_comunicacion = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}