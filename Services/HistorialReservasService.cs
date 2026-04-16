using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class HistorialReservasService : IHistorialReservasService
    {
        private readonly DBContext _context;

        public HistorialReservasService(DBContext context) => _context = context;

        public async Task<bool> Insertar(HistorialReservasModel m)
        {
            var sql = @"INSERT INTO historial_reservas 
                        (id_reserva, fecha_cambio, campo_modificado, valor_anterior, valor_nuevo, usuario_modificacion, motivo_cambio) 
                        VALUES (:p_id_res, SYSTIMESTAMP, :p_campo, :p_v_ant, :p_v_nue, :p_user, :p_motivo)";

            var parametros = new[] {
                new OracleParameter("p_id_res", m.IdReserva),
                new OracleParameter("p_campo", (object?)m.CampoModificado ?? DBNull.Value),
                new OracleParameter("p_v_ant", (object?)m.ValorAnterior ?? DBNull.Value),
                new OracleParameter("p_v_nue", (object?)m.ValorNuevo ?? DBNull.Value),
                new OracleParameter("p_user", (object?)m.UsuarioModificacion ?? "SISTEMA"),
                new OracleParameter("p_motivo", (object?)m.MotivoCambio ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<HistorialReservasModel>> ListarPorReserva(int idReserva)
        {
            return await _context.HistorialReservas
                .Where(h => h.IdReserva == idReserva)
                .OrderByDescending(h => h.FechaCambio)
                .ToListAsync();
        }

        public async Task<bool> Actualizar(int id, HistorialReservasModel m)
        {
            var sql = @"UPDATE historial_reservas 
                        SET campo_modificado = :p_campo, valor_anterior = :p_v_ant, 
                            valor_nuevo = :p_v_nue, usuario_modificacion = :p_user, 
                            motivo_cambio = :p_motivo 
                        WHERE id_historial_reserva = :p_id";

            var parametros = new[] {
                new OracleParameter("p_campo", m.CampoModificado),
                new OracleParameter("p_v_ant", m.ValorAnterior),
                new OracleParameter("p_v_nue", m.ValorNuevo),
                new OracleParameter("p_user", m.UsuarioModificacion),
                new OracleParameter("p_motivo", m.MotivoCambio),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM historial_reservas WHERE id_historial_reserva = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}