using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class TransporteTerrestreService : ITransporteTerrestreService
    {
        private readonly DBContext _context;

        public TransporteTerrestreService(DBContext context) => _context = context;

        public async Task<bool> RegistrarTransporte(TransporteTerrestreModel m)
        {
            var sql = @"INSERT INTO transporte_terrestre 
                        (codigo_aeropuerto, tipo_transporte, empresa, telefono_contacto, 
                         tarifa_estimada, horario_operacion, activo) 
                        VALUES (:p_aero, :p_tipo, :p_empresa, :p_tel, 
                                :p_tarifa, :p_horario, 1)";

            var parametros = new[] {
                new OracleParameter("p_aero", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_tipo", m.TipoTransporte),
                new OracleParameter("p_empresa", (object?)m.Empresa ?? DBNull.Value),
                new OracleParameter("p_tel", (object?)m.TelefonoContacto ?? DBNull.Value),
                new OracleParameter("p_tarifa", (object?)m.TarifaEstimada ?? DBNull.Value),
                new OracleParameter("p_horario", (object?)m.HorarioOperacion ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<TransporteTerrestreModel>> ListarPorAeropuerto(string codigoAeropuerto)
        {
            return await _context.TransporteTerrestre
                .Where(t => t.CodigoAeropuerto == codigoAeropuerto)
                .OrderBy(t => t.TipoTransporte).ThenBy(t => t.Empresa)
                .ToListAsync();
        }

        public async Task<List<TransporteTerrestreModel>> ListarActivos(string codigoAeropuerto, string? tipoTransporte = null)
        {
            var query = _context.TransporteTerrestre
                .Where(t => t.CodigoAeropuerto == codigoAeropuerto && t.Activo == 1);

            // Filtro dinámico si se especifica el tipo de transporte
            if (!string.IsNullOrEmpty(tipoTransporte))
            {
                var tipoUpper = tipoTransporte.ToUpper();
                query = query.Where(t => t.TipoTransporte == tipoUpper);
            }

            return await query
                .OrderBy(t => t.Empresa)
                .ToListAsync();
        }

        public async Task<bool> DesactivarTransporte(int id)
        {
            var sql = "UPDATE transporte_terrestre SET activo = 0 WHERE id_transporte = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM transporte_terrestre WHERE id_transporte = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}