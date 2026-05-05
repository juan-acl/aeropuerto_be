using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PasajeroHistorialMedicoService : IPasajeroHistorialMedicoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PasajeroHistorialMedicoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PasajeroHistorialMedicoModel>> ListarTodo()
        {
            try { return await _replica.PasajerosHistorialMedico.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PasajeroHistorialMedicoModel: {ex.Message}"); return new List<PasajeroHistorialMedicoModel>(); }
        }

        public async Task<PasajeroHistorialMedicoModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.PasajerosHistorialMedico.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PasajeroHistorialMedicoModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PasajeroHistorialMedicoModel m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_historial_medico.insert_historial(:p_id_pasajero, :p_condicion_medica, :p_requiere_atencion_especial, :p_medicamentos_autorizados, :p_contacto_emergencia_nombre, :p_contacto_emergencia_telefono, :p_contacto_emergencia_relacion, :p_ultima_actualizacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pasajero", m.IdPasajero),
                    new OracleParameter("p_condicion_medica", (object?)m.CondicionMedica ?? DBNull.Value),
                    new OracleParameter("p_requiere_atencion_especial", m.RequiereAtencionEspecial),
                    new OracleParameter("p_medicamentos_autorizados", (object?)m.MedicamentosAutorizados ?? DBNull.Value),
                    new OracleParameter("p_contacto_emergencia_nombre", (object?)m.ContactoEmergenciaNombre ?? DBNull.Value),
                    new OracleParameter("p_contacto_emergencia_telefono", (object?)m.ContactoEmergenciaTelefono ?? DBNull.Value),
                    new OracleParameter("p_contacto_emergencia_relacion", (object?)m.ContactoEmergenciaRelacion ?? DBNull.Value),
                    new OracleParameter("p_ultima_actualizacion", (object?)m.UltimaActualizacion ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PasajeroHistorialMedicoModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, PasajeroHistorialMedicoModel m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_historial_medico.update_historial(:p_id_historial_medico, :p_id_pasajero, :p_condicion_medica, :p_requiere_atencion_especial, :p_medicamentos_autorizados, :p_contacto_emergencia_nombre, :p_contacto_emergencia_telefono, :p_contacto_emergencia_relacion, :p_ultima_actualizacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_historial_medico", id),
                    new OracleParameter("p_id_pasajero", m.IdPasajero),
                    new OracleParameter("p_condicion_medica", (object?)m.CondicionMedica ?? DBNull.Value),
                    new OracleParameter("p_requiere_atencion_especial", m.RequiereAtencionEspecial),
                    new OracleParameter("p_medicamentos_autorizados", (object?)m.MedicamentosAutorizados ?? DBNull.Value),
                    new OracleParameter("p_contacto_emergencia_nombre", (object?)m.ContactoEmergenciaNombre ?? DBNull.Value),
                    new OracleParameter("p_contacto_emergencia_telefono", (object?)m.ContactoEmergenciaTelefono ?? DBNull.Value),
                    new OracleParameter("p_contacto_emergencia_relacion", (object?)m.ContactoEmergenciaRelacion ?? DBNull.Value),
                    new OracleParameter("p_ultima_actualizacion", (object?)m.UltimaActualizacion ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PasajeroHistorialMedicoModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_historial_medico.delete_historial(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PasajeroHistorialMedicoModel: {ex.Message}"); throw; }
        }
    }
}
