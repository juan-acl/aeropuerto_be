using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EmergenciasMedicasService : IEmergenciasMedicasService
    {
        private readonly DBContext _context;
        public EmergenciasMedicasService(DBContext context) => _context = context;

        public async Task<List<EmergenciasMedicasModel>> ListarTodo()
        {
            try { return await _context.EmergenciasMedicas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EmergenciasMedicasModel: {ex.Message}"); return new List<EmergenciasMedicasModel>(); }
        }

        public async Task<EmergenciasMedicasModel?> ObtenerPorId(int id)
        {
            try { return await _context.EmergenciasMedicas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EmergenciasMedicasModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EmergenciasMedicasModel m)
        {
            try
            {
                string sql = "BEGIN pkg_emergencias_medicas.insert_emergencia(:p_id_pasajero, :p_id_vuelo, :p_codigo_aeropuerto, :p_fecha_emergencia, :p_tipo_emergencia, :p_sintomas, :p_diagnostico_inicial, :p_personal_atendio, :p_tratamiento, :p_requiere_hospitalizacion, :p_hospital_destino, :p_fecha_alta); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_fecha_emergencia", (object?)m.FechaEmergencia ?? DBNull.Value),
                new OracleParameter("p_tipo_emergencia", (object?)m.TipoEmergencia ?? DBNull.Value),
                new OracleParameter("p_sintomas", (object?)m.Sintomas ?? DBNull.Value),
                new OracleParameter("p_diagnostico_inicial", (object?)m.DiagnosticoInicial ?? DBNull.Value),
                new OracleParameter("p_personal_atendio", (object?)m.PersonalAtendio ?? DBNull.Value),
                new OracleParameter("p_tratamiento", (object?)m.Tratamiento ?? DBNull.Value),
                new OracleParameter("p_requiere_hospitalizacion", m.RequiereHospitalizacion),
                new OracleParameter("p_hospital_destino", (object?)m.HospitalDestino ?? DBNull.Value),
                new OracleParameter("p_fecha_alta", (object?)m.FechaAlta ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar EmergenciasMedicasModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, EmergenciasMedicasModel m)
        {
            try
            {
                string sql = "BEGIN pkg_emergencias_medicas.update_emergencia(:p_id_emergencia, :p_id_pasajero, :p_id_vuelo, :p_codigo_aeropuerto, :p_fecha_emergencia, :p_tipo_emergencia, :p_sintomas, :p_diagnostico_inicial, :p_personal_atendio, :p_tratamiento, :p_requiere_hospitalizacion, :p_hospital_destino, :p_fecha_alta); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_emergencia", id),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_fecha_emergencia", (object?)m.FechaEmergencia ?? DBNull.Value),
                new OracleParameter("p_tipo_emergencia", (object?)m.TipoEmergencia ?? DBNull.Value),
                new OracleParameter("p_sintomas", (object?)m.Sintomas ?? DBNull.Value),
                new OracleParameter("p_diagnostico_inicial", (object?)m.DiagnosticoInicial ?? DBNull.Value),
                new OracleParameter("p_personal_atendio", (object?)m.PersonalAtendio ?? DBNull.Value),
                new OracleParameter("p_tratamiento", (object?)m.Tratamiento ?? DBNull.Value),
                new OracleParameter("p_requiere_hospitalizacion", m.RequiereHospitalizacion),
                new OracleParameter("p_hospital_destino", (object?)m.HospitalDestino ?? DBNull.Value),
                new OracleParameter("p_fecha_alta", (object?)m.FechaAlta ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar EmergenciasMedicasModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_emergencias_medicas.delete_emergencia(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar EmergenciasMedicasModel: {ex.Message}"); return false; }
        }
    }
}
