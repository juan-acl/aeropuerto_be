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
            var sql = "pkg_historial_reservas.insert_historial";

            var parametros = new[] {
                new OracleParameter("p_id_reserva", m.IdReserva),
                new OracleParameter("p_campo_modificado", (object?)m.CampoModificado ?? DBNull.Value),
                new OracleParameter("p_valor_anterior", (object?)m.ValorAnterior ?? DBNull.Value),
                new OracleParameter("p_valor_nuevo", (object?)m.ValorNuevo ?? DBNull.Value),
                new OracleParameter("p_usuario_modificacion", (object?)m.UsuarioModificacion ?? "SISTEMA"),
                new OracleParameter("p_motivo_cambio", (object?)m.MotivoCambio ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_reserva, :p_campo_modificado, :p_valor_anterior, :p_valor_nuevo, :p_usuario_modificacion, :p_motivo_cambio); END;", parametros);
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
            var sql = "pkg_historial_reservas.update_historial";

            var parametros = new[] {
                new OracleParameter("p_id_historial_reserva", id),
                new OracleParameter("p_campo_modificado", m.CampoModificado),
                new OracleParameter("p_valor_anterior", m.ValorAnterior),
                new OracleParameter("p_valor_nuevo", m.ValorNuevo),
                new OracleParameter("p_usuario_modificacion", m.UsuarioModificacion),
                new OracleParameter("p_motivo_cambio", m.MotivoCambio)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_historial_reserva, :p_campo_modificado, :p_valor_anterior, :p_valor_nuevo, :p_usuario_modificacion, :p_motivo_cambio); END;", parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "pkg_historial_reservas.delete_historial";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_historial_reserva); END;", new OracleParameter("p_id_historial_reserva", id));
            return true;
        }
    }
}