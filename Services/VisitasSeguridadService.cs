using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class VisitasSeguridadService : IVisitasSeguridadService
    {
        private readonly DBContext _context;

        public VisitasSeguridadService(DBContext context) => _context = context;

        public async Task<bool> RegistrarIngreso(VisitasSeguridadModel m)
        {
            var sql = @"INSERT INTO visitas_seguridad 
                        (codigo_aeropuerto, fecha_visita, hora_entrada, nombre_visitante, 
                         tipo_documento, numero_documento, empresa, motivo_visita, 
                         persona_autoriza, area_visitada, escort_requerido, escort_asignado) 
                        VALUES (:p_aero, SYSDATE, SYSTIMESTAMP, :p_nom, :p_tdoc, :p_ndoc, 
                                :p_emp, :p_mot, :p_aut, :p_area, :p_req, :p_asig)";

            var parametros = new[] {
                new OracleParameter("p_aero", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_nom", (object?)m.NombreVisitante ?? DBNull.Value),
                new OracleParameter("p_tdoc", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_ndoc", (object?)m.NumeroDocumento ?? DBNull.Value),
                new OracleParameter("p_emp", (object?)m.Empresa ?? DBNull.Value),
                new OracleParameter("p_mot", (object?)m.MotivoVisita ?? DBNull.Value),
                new OracleParameter("p_aut", (object?)m.PersonaAutoriza ?? DBNull.Value),
                new OracleParameter("p_area", (object?)m.AreaVisitada ?? DBNull.Value),
                new OracleParameter("p_req", m.EscortRequerido),
                new OracleParameter("p_asig", (object?)m.EscortAsignado ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<VisitasSeguridadModel>> ListarPorAeropuerto(string codigo)
        {
            return await _context.VisitasSeguridad
                .Where(v => v.CodigoAeropuerto == codigo)
                .OrderByDescending(v => v.HoraEntrada)
                .ToListAsync();
        }

        public async Task<List<VisitasSeguridadModel>> ListarVisitantesActivos(string codigo)
        {
            // Visitantes que han entrado pero no han registrado su salida
            return await _context.VisitasSeguridad
                .Where(v => v.CodigoAeropuerto == codigo && v.HoraSalida == null)
                .OrderBy(v => v.HoraEntrada)
                .ToListAsync();
        }

        public async Task<bool> RegistrarSalida(int id)
        {
            var sql = "UPDATE visitas_seguridad SET hora_salida = SYSTIMESTAMP WHERE id_visita = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM visitas_seguridad WHERE id_visita = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}