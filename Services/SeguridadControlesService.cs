using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class SeguridadControlesService : ISeguridadControlesService
    {
        private readonly DBContext _context;

        public SeguridadControlesService(DBContext context) => _context = context;

        public async Task<bool> RegistrarControl(SeguridadControlesModel m)
        {
            var sql = @"INSERT INTO seguridad_controles 
                        (codigo_aeropuerto, fecha_control, hora_control, tipo_control, 
                         numero_pasajeros_revisados, numero_incidencias, supervisor, observaciones) 
                        VALUES (:p_aero, SYSDATE, SYSTIMESTAMP, :p_tipo, :p_pas, :p_inc, :p_super, :p_obs)";

            var parametros = new[] {
                new OracleParameter("p_aero", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_tipo", m.TipoControl),
                new OracleParameter("p_pas", m.NumeroPasajerosRevisados),
                new OracleParameter("p_inc", m.NumeroIncidencias),
                new OracleParameter("p_super", (object?)m.Supervisor ?? DBNull.Value),
                new OracleParameter("p_obs", (object?)m.Observaciones ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<SeguridadControlesModel>> ListarPorAeropuerto(string codigo)
        {
            return await _context.SeguridadControles
                .Where(s => s.CodigoAeropuerto == codigo)
                .OrderByDescending(s => s.HoraControl)
                .ToListAsync();
        }

        public async Task<object> ObtenerResumenEstadistico(string codigo, DateTime fecha)
        {
            var controles = await _context.SeguridadControles
                .Where(s => s.CodigoAeropuerto == codigo && s.FechaControl.Value.Date == fecha.Date)
                .ToListAsync();

            return new
            {
                TotalPasajeros = controles.Sum(c => c.NumeroPasajerosRevisados),
                TotalIncidencias = controles.Sum(c => c.NumeroIncidencias),
                PorTipo = controles.GroupBy(c => c.TipoControl)
                                   .Select(g => new { Tipo = g.Key, Cantidad = g.Count() })
            };
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM seguridad_controles WHERE id_control = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}