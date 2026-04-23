using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class AlertasSeguridadService : IAlertasSeguridadService
    {
        private readonly DBContext _context;

        public AlertasSeguridadService(DBContext context) => _context = context;

        public async Task<bool> EmitirAlerta(AlertasSeguridadModel m)
        {
            if (!string.IsNullOrEmpty(m.CodigoAeropuerto))
            {
                var sqlDesactivar = "pkg_alertas_seguridad.desactivar_alertas_aeropuerto";
                await _context.Database.ExecuteSqlRawAsync($"BEGIN {sqlDesactivar}(:p_codigo_aeropuerto); END;", new OracleParameter("p_codigo_aeropuerto", m.CodigoAeropuerto));
            }

            var sql = "pkg_alertas_seguridad.insert_alerta";

            var parametros = new[] {
                new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_nivel_alerta", m.NivelAlerta),
                new OracleParameter("p_motivo", (object?)m.Motivo ?? DBNull.Value),
                new OracleParameter("p_medidas_adicionales", (object?)m.MedidasAdicionales ?? DBNull.Value),
                new OracleParameter("p_emitida_por", (object?)m.EmitidaPor ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_codigo_aeropuerto, :p_nivel_alerta, :p_motivo, :p_medidas_adicionales, :p_emitida_por); END;", parametros);
            return true;
        }

        public async Task<List<AlertasSeguridadModel>> ListarHistorial(string codigo)
        {
            return await _context.AlertasSeguridad
                .Where(a => a.CodigoAeropuerto == codigo)
                .OrderByDescending(a => a.FechaInicio)
                .ToListAsync();
        }

        public async Task<AlertasSeguridadModel?> ObtenerAlertaActiva(string codigo)
        {
            return await _context.AlertasSeguridad
                .FirstOrDefaultAsync(a => a.CodigoAeropuerto == codigo && a.Activa == 1);
        }

        public async Task<bool> DesactivarAlerta(int id)
        {
            var sql = "pkg_alertas_seguridad.desactivar_alerta";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_alerta); END;", new OracleParameter("p_id_alerta", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "pkg_alertas_seguridad.delete_alerta";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_alerta); END;", new OracleParameter("p_id_alerta", id));
            return true;
        }
    }
}