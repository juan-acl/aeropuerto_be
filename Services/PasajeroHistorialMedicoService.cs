using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PasajeroHistorialMedicoService : IPasajeroHistorialMedicoService
    {
        private readonly DBContext _context;

        public PasajeroHistorialMedicoService(DBContext context) => _context = context;

        public async Task<bool> Insertar(PasajeroHistorialMedicoModel m)
        {
            var sql = @"BEGIN pkg_pasajeros.insert_historial_medico(
                :p_id_pasajero, :p_condicion, :p_atencion, :p_meds, 
                :p_c_nombre, :p_c_tel, :p_c_rel); END;";

            var parametros = new[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_condicion", (object?)m.CondicionMedica ?? DBNull.Value),
                new OracleParameter("p_atencion", m.RequiereAtencionEspecial),
                new OracleParameter("p_meds", (object?)m.MedicamentosAutorizados ?? DBNull.Value),
                new OracleParameter("p_c_nombre", (object?)m.ContactoEmergenciaNombre ?? DBNull.Value),
                new OracleParameter("p_c_tel", (object?)m.ContactoEmergenciaTelefono ?? DBNull.Value),
                new OracleParameter("p_c_rel", (object?)m.ContactoEmergenciaRelacion ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<PasajeroHistorialMedicoModel?> ObtenerPorPasajero(int idPasajero)
        {
            return await _context.PasajerosHistorialMedico
                .FirstOrDefaultAsync(h => h.IdPasajero == idPasajero);
        }

        public async Task<bool> EliminarFisico(int idHistorial)
        {
            var sql = "DELETE FROM pasajeros_historial_medico WHERE id_historial_medico = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", idHistorial));
            return true;
        }

        public async Task<bool> ActualizarContactoEmergencia(int id, string nombre, string telefono)
        {
            var sql = "UPDATE pasajeros_historial_medico SET contacto_emergencia_nombre = :p_nom, contacto_emergencia_telefono = :p_tel, ultima_actualizacion = SYSDATE WHERE id_historial_medico = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_nom", nombre),
                new OracleParameter("p_tel", telefono),
                new OracleParameter("p_id", id));
            return true;
        }
    }
}