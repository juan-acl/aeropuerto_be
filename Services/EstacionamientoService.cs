using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EstacionamientoService : IEstacionamientoService
    {
        private readonly DBContext _context;

        public EstacionamientoService(DBContext context) => _context = context;

        public async Task<bool> RegistrarEspacio(EstacionamientoModel m)
        {
            var sql = @"INSERT INTO estacionamiento 
                        (codigo_aeropuerto, numero_espacio, tipo_espacio, terminal_cercana, 
                         tarifa_por_hora, tarifa_diaria, disponible, observaciones) 
                        VALUES (:p_aero, :p_num, :p_tipo, :p_term, 
                                :p_hora, :p_dia, :p_disp, :p_obs)";

            var parametros = new[] {
                new OracleParameter("p_aero", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_num", (object?)m.NumeroEspacio ?? DBNull.Value),
                new OracleParameter("p_tipo", m.TipoEspacio),
                new OracleParameter("p_term", (object?)m.TerminalCercana ?? DBNull.Value),
                new OracleParameter("p_hora", (object?)m.TarifaPorHora ?? DBNull.Value),
                new OracleParameter("p_dia", (object?)m.TarifaDiaria ?? DBNull.Value),
                new OracleParameter("p_disp", m.Disponible),
                new OracleParameter("p_obs", (object?)m.Observaciones ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<EstacionamientoModel>> ListarPorAeropuerto(string codigoAeropuerto)
        {
            return await _context.Estacionamiento
                .Where(e => e.CodigoAeropuerto == codigoAeropuerto)
                .OrderBy(e => e.TerminalCercana).ThenBy(e => e.NumeroEspacio)
                .ToListAsync();
        }

        public async Task<List<EstacionamientoModel>> ListarDisponiblesPorTipo(string codigoAeropuerto, string tipoEspacio)
        {
            // Ideal para paneles luminosos a la entrada del parqueo o apps móviles
            return await _context.Estacionamiento
                .Where(e => e.CodigoAeropuerto == codigoAeropuerto
                         && e.Disponible == 1
                         && e.TipoEspacio == tipoEspacio)
                .OrderBy(e => e.TerminalCercana).ThenBy(e => e.NumeroEspacio)
                .ToListAsync();
        }

        public async Task<bool> CambiarDisponibilidad(int idEstacionamiento, int disponible)
        {
            var sql = @"UPDATE estacionamiento 
                        SET disponible = :p_disp 
                        WHERE id_estacionamiento = :p_id";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_disp", disponible),
                new OracleParameter("p_id", idEstacionamiento));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM estacionamiento WHERE id_estacionamiento = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}