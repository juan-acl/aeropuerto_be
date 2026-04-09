using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ControlAbordajeService : IControlAbordajeService
    {
        private readonly DBContext _context;

        public ControlAbordajeService(DBContext context) => _context = context;

        public async Task<bool> RegistrarAbordaje(ControlAbordajeModel m)
        {
            var sql = @"INSERT INTO control_abordaje 
                        (id_vuelo, id_reserva, hora_abordaje, verificado_por, estado, observaciones) 
                        VALUES (:p_vuelo, :p_res, SYSTIMESTAMP, :p_emp, :p_estado, :p_obs)";

            var parametros = new[] {
                new OracleParameter("p_vuelo", m.IdVuelo),
                new OracleParameter("p_res", m.IdReserva),
                new OracleParameter("p_emp", m.VerificadoPor),
                new OracleParameter("p_estado", m.Estado),
                new OracleParameter("p_obs", (object?)m.Observaciones ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<ControlAbordajeModel>> ListarPorVuelo(int idVuelo)
        {
            return await _context.ControlAbordaje
                .Where(c => c.IdVuelo == idVuelo)
                .ToListAsync();
        }

        public async Task<int> ContarPasajerosAbordados(int idVuelo)
        {
            return await _context.ControlAbordaje
                .CountAsync(c => c.IdVuelo == idVuelo && c.Estado == "ABORDADO");
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM control_abordaje WHERE id_control_abordaje = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}