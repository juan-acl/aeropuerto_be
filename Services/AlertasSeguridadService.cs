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
            // Primero, si es una nueva alerta, deberíamos desactivar las anteriores del mismo aeropuerto
            if (!string.IsNullOrEmpty(m.CodigoAeropuerto))
            {
                var sqlDesactivar = @"UPDATE alertas_seguridad 
                                      SET activa = 0, fecha_fin = SYSTIMESTAMP 
                                      WHERE codigo_aeropuerto = :p_aero AND activa = 1";
                await _context.Database.ExecuteSqlRawAsync(sqlDesactivar, new OracleParameter("p_aero", m.CodigoAeropuerto));
            }

            var sql = @"INSERT INTO alertas_seguridad 
                        (codigo_aeropuerto, nivel_alerta, fecha_inicio, motivo, medidas_adicionales, activa, emitida_por) 
                        VALUES (:p_aero, :p_nivel, SYSTIMESTAMP, :p_mot, :p_medidas, 1, :p_emite)";

            var parametros = new[] {
                new OracleParameter("p_aero", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_nivel", m.NivelAlerta),
                new OracleParameter("p_mot", (object?)m.Motivo ?? DBNull.Value),
                new OracleParameter("p_medidas", (object?)m.MedidasAdicionales ?? DBNull.Value),
                new OracleParameter("p_emite", (object?)m.EmitidaPor ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
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
            // Al desactivar, marcamos la fecha de fin automáticamente
            var sql = @"UPDATE alertas_seguridad 
                        SET activa = 0, fecha_fin = SYSTIMESTAMP 
                        WHERE id_alerta = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM alertas_seguridad WHERE id_alerta = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}