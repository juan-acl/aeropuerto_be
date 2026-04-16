using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class TiposIncidentesService : ITiposIncidentesService
    {
        private readonly DBContext _context;

        public TiposIncidentesService(DBContext context) => _context = context;

        public async Task<bool> Insertar(TiposIncidentesModel m)
        {
            var sql = @"INSERT INTO tipos_incidentes 
                        (nombre_tipo, descripcion, protocolo_accion, tiempo_respuesta_estimado, activo) 
                        VALUES (:p_nom, :p_desc, :p_prot, :p_tiempo, :p_act)";

            var parametros = new[] {
                new OracleParameter("p_nom", (object?)m.NombreTipo ?? DBNull.Value),
                new OracleParameter("p_desc", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_prot", (object?)m.ProtocoloAccion ?? DBNull.Value),
                new OracleParameter("p_tiempo", (object?)m.TiempoRespuestaEstimado ?? DBNull.Value),
                new OracleParameter("p_act", m.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<TiposIncidentesModel>> ListarActivos()
        {
            return await _context.TiposIncidentes
                .Where(t => t.Activo == 1)
                .ToListAsync();
        }

        public async Task<TiposIncidentesModel?> ObtenerPorId(int id)
        {
            return await _context.TiposIncidentes.FindAsync(id);
        }

        public async Task<bool> Actualizar(int id, TiposIncidentesModel m)
        {
            var sql = @"UPDATE tipos_incidentes 
                        SET nombre_tipo = :p_nom, descripcion = :p_desc, 
                            protocolo_accion = :p_prot, tiempo_respuesta_estimado = :p_tiempo, 
                            activo = :p_act 
                        WHERE id_tipo_incidente = :p_id";

            var parametros = new[] {
                new OracleParameter("p_nom", m.NombreTipo),
                new OracleParameter("p_desc", m.Descripcion),
                new OracleParameter("p_prot", m.ProtocoloAccion),
                new OracleParameter("p_tiempo", m.TiempoRespuestaEstimado),
                new OracleParameter("p_act", m.Activo),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarLogico(int id)
        {
            var sql = "UPDATE tipos_incidentes SET activo = 0 WHERE id_tipo_incidente = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}