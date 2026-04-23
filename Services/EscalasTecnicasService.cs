using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EscalasTecnicasService : IEscalasTecnicasService
    {
        private readonly DBContext _context;

        public EscalasTecnicasService(DBContext context)
        {
            _context = context;
        }

        public async Task<List<EscalasTecnicasModel>> ListarPorVuelo(int idVuelo)
        {
            return await _context.EscalasTecnicas
                .Where(e => e.IdVuelo == idVuelo)
                .OrderBy(e => e.NumeroOrden)
                .ToListAsync();
        }

        public async Task<EscalasTecnicasModel?> ObtenerPorId(int idEscala)
        {
            return await _context.EscalasTecnicas
                .FirstOrDefaultAsync(e => e.IdEscala == idEscala);
        }

        public async Task<bool> Insertar(EscalasTecnicasModel m)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"BEGIN pkg_escalas_tecnicas.insert_escala(
                    :p_id_vuelo, :p_aeropuerto_escala, :p_numero_orden,
                    :p_hora_llegada, :p_hora_despegue, :p_tiempo_escala_minutos,
                    :p_motivo_escala, :p_observaciones
                ); END;",
                new OracleParameter("p_id_vuelo",               m.IdVuelo),
                new OracleParameter("p_aeropuerto_escala",      m.AeropuertoEscala),
                new OracleParameter("p_numero_orden",           m.NumeroOrden),
                new OracleParameter("p_hora_llegada",           m.HoraLlegada),
                new OracleParameter("p_hora_despegue",          m.HoraDespegue),
                new OracleParameter("p_tiempo_escala_minutos",  m.TiempoEscalaMinutos),
                new OracleParameter("p_motivo_escala",          (object?)m.MotivoEscala ?? DBNull.Value),
                new OracleParameter("p_observaciones",          (object?)m.Observaciones ?? DBNull.Value)
            );
            return true;
        }

        public async Task<bool> Actualizar(EscalasTecnicasModel m)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"BEGIN pkg_escalas_tecnicas.update_escala(
                    :p_id_escala, :p_id_vuelo, :p_aeropuerto_escala, :p_numero_orden,
                    :p_hora_llegada, :p_hora_despegue, :p_tiempo_escala_minutos,
                    :p_motivo_escala, :p_observaciones
                ); END;",
                new OracleParameter("p_id_escala",              m.IdEscala),
                new OracleParameter("p_id_vuelo",               m.IdVuelo),
                new OracleParameter("p_aeropuerto_escala",      m.AeropuertoEscala),
                new OracleParameter("p_numero_orden",           m.NumeroOrden),
                new OracleParameter("p_hora_llegada",           m.HoraLlegada),
                new OracleParameter("p_hora_despegue",          m.HoraDespegue),
                new OracleParameter("p_tiempo_escala_minutos",  m.TiempoEscalaMinutos),
                new OracleParameter("p_motivo_escala",          (object?)m.MotivoEscala ?? DBNull.Value),
                new OracleParameter("p_observaciones",          (object?)m.Observaciones ?? DBNull.Value)
            );
            return true;
        }

        public async Task<bool> Eliminar(int idEscala)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN pkg_escalas_tecnicas.delete_escala(:p_id_escala); END;",
                new OracleParameter("p_id_escala", idEscala)
            );
            return true;
        }
    }
}
