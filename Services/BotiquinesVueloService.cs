using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class BotiquinesVueloService : IBotiquinesVueloService
    {
        private readonly DBContext _context;

        public BotiquinesVueloService(DBContext context) => _context = context;

        public async Task<bool> RegistrarVerificacion(BotiquinesVueloModel m)
        {
            var sql = @"INSERT INTO botiquines_vuelo 
                        (id_vuelo, fecha_verificacion, contenido_completo, medicamentos_caducados, observaciones, verificado_por) 
                        VALUES (:p_vuelo, SYSDATE, :p_comp, :p_cad, :p_obs, :p_verif)";

            var parametros = new[] {
                new OracleParameter("p_vuelo", m.IdVuelo),
                new OracleParameter("p_comp", m.ContenidoCompleto),
                new OracleParameter("p_cad", m.MedicamentosCaducados),
                new OracleParameter("p_obs", (object?)m.Observaciones ?? DBNull.Value),
                new OracleParameter("p_verif", (object?)m.VerificadoPor ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<BotiquinesVueloModel>> ListarPorVuelo(int idVuelo)
        {
            return await _context.BotiquinesVuelo
                .Where(b => b.IdVuelo == idVuelo)
                .OrderByDescending(b => b.FechaVerificacion)
                .ToListAsync();
        }

        public async Task<BotiquinesVueloModel?> ObtenerUltimaVerificacion(int idVuelo)
        {
            return await _context.BotiquinesVuelo
                .Where(b => b.IdVuelo == idVuelo)
                .OrderByDescending(b => b.FechaVerificacion)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Actualizar(int id, BotiquinesVueloModel m)
        {
            var sql = @"UPDATE botiquines_vuelo 
                        SET contenido_completo = :p_comp, medicamentos_caducados = :p_cad, 
                            observaciones = :p_obs, verificado_por = :p_verif 
                        WHERE id_botiquin = :p_id";

            var parametros = new[] {
                new OracleParameter("p_comp", m.ContenidoCompleto),
                new OracleParameter("p_cad", m.MedicamentosCaducados),
                new OracleParameter("p_obs", m.Observaciones),
                new OracleParameter("p_verif", m.VerificadoPor),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM botiquines_vuelo WHERE id_botiquin = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}