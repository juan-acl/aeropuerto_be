using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EmergenciasMedicasService : IEmergenciasMedicasService
    {
        private readonly DBContext _context;

        public EmergenciasMedicasService(DBContext context) => _context = context;

        public async Task<bool> Insertar(EmergenciasMedicasModel m)
        {
            var sql = @"INSERT INTO emergencias_medicas 
                        (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_emergencia, tipo_emergencia, 
                         sintomas, diagnostico_inicial, personal_atendio, tratamiento, 
                         requiere_hospitalizacion, hospital_destino) 
                        VALUES (:p_pas, :p_vuelo, :p_aero, SYSTIMESTAMP, :p_tipo, 
                                :p_sint, :p_diag, :p_pers, :p_trat, :p_hosp_req, :p_hosp_dest)";

            var parametros = new[] {
                new OracleParameter("p_pas", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_aero", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_tipo", (object?)m.TipoEmergencia ?? DBNull.Value),
                new OracleParameter("p_sint", (object?)m.Sintomas ?? DBNull.Value),
                new OracleParameter("p_diag", (object?)m.DiagnosticoInicial ?? DBNull.Value),
                new OracleParameter("p_pers", (object?)m.PersonalAtendio ?? DBNull.Value),
                new OracleParameter("p_trat", (object?)m.Tratamiento ?? DBNull.Value),
                new OracleParameter("p_hosp_req", m.RequiereHospitalizacion),
                new OracleParameter("p_hosp_dest", (object?)m.HospitalDestino ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<EmergenciasMedicasModel>> ListarPorPasajero(int idPasajero)
        {
            return await _context.EmergenciasMedicas
                .Where(e => e.IdPasajero == idPasajero)
                .OrderByDescending(e => e.FechaEmergencia)
                .ToListAsync();
        }

        public async Task<List<EmergenciasMedicasModel>> ListarPorVuelo(int idVuelo)
        {
            return await _context.EmergenciasMedicas
                .Where(e => e.IdVuelo == idVuelo)
                .ToListAsync();
        }

        public async Task<bool> ActualizarAlta(int id, DateTime fechaAlta)
        {
            var sql = "UPDATE emergencias_medicas SET fecha_alta = :p_alta WHERE id_emergencia = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_alta", fechaAlta),
                new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM emergencias_medicas WHERE id_emergencia = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}