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
            var sql = "pkg_historial_comunicaciones.insert_comunicacion";

            var parametros = new[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_tipo_comunicacion", m.TipoComunicacion),
                new OracleParameter("p_asunto", (object?)m.Asunto ?? DBNull.Value),
                new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                new OracleParameter("p_estado", m.Estado ?? "ENVIADO"),
                new OracleParameter("p_respuesta_recibida", m.RespuestaRecibida)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_pasajero, :p_tipo_comunicacion, :p_asunto, :p_contenido, :p_estado, :p_respuesta_recibida); END;", parametros);
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
            var sql = "pkg_historial_comunicaciones.update_comunicacion";

            var parametros = new[] {
                new OracleParameter("p_id_comunicacion", id),
                new OracleParameter("p_tipo_comunicacion", m.TipoComunicacion),
                new OracleParameter("p_asunto", (object?)m.Asunto ?? DBNull.Value),
                new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                new OracleParameter("p_estado", m.Estado),
                new OracleParameter("p_respuesta_recibida", m.RespuestaRecibida)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_comunicacion, :p_tipo_comunicacion, :p_asunto, :p_contenido, :p_estado, :p_respuesta_recibida); END;", parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "pkg_historial_comunicaciones.delete_comunicacion";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_comunicacion); END;", new OracleParameter("p_id_comunicacion", id));
            return true;
        }
    }
}