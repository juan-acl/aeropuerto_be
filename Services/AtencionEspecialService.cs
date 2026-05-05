using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AtencionEspecialService : IAtencionEspecialService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AtencionEspecialService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AtencionEspecialModel>> ListarTodo()
        {
            try { return await _replica.AtencionEspecial.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AtencionEspecialModel: {ex.Message}"); return new List<AtencionEspecialModel>(); }
        }

        public async Task<AtencionEspecialModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.AtencionEspecial.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AtencionEspecialModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AtencionEspecialModel m)
        {
            try
            {
                string sql = "BEGIN pkg_atencion_especial.insert_atencion(:p_id_pasajero, :p_id_reserva, :p_tipo_atencion, :p_fecha_solicitud, :p_fecha_atencion, :p_asistente_asignado, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_reserva", (object?)m.IdReserva ?? DBNull.Value),
                    new OracleParameter("p_tipo_atencion", (object?)m.TipoAtencion ?? DBNull.Value),
                    new OracleParameter("p_fecha_solicitud", (object?)m.FechaSolicitud ?? DBNull.Value),
                    new OracleParameter("p_fecha_atencion", (object?)m.FechaAtencion ?? DBNull.Value),
                    new OracleParameter("p_asistente_asignado", (object?)m.AsistenteAsignado ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar AtencionEspecialModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, AtencionEspecialModel m)
        {
            try
            {
                string sql = "BEGIN pkg_atencion_especial.update_atencion(:p_id_atencion, :p_id_pasajero, :p_id_reserva, :p_tipo_atencion, :p_fecha_solicitud, :p_fecha_atencion, :p_asistente_asignado, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_atencion", id),
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_reserva", (object?)m.IdReserva ?? DBNull.Value),
                    new OracleParameter("p_tipo_atencion", (object?)m.TipoAtencion ?? DBNull.Value),
                    new OracleParameter("p_fecha_solicitud", (object?)m.FechaSolicitud ?? DBNull.Value),
                    new OracleParameter("p_fecha_atencion", (object?)m.FechaAtencion ?? DBNull.Value),
                    new OracleParameter("p_asistente_asignado", (object?)m.AsistenteAsignado ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar AtencionEspecialModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_atencion_especial.delete_atencion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar AtencionEspecialModel: {ex.Message}"); throw; }
        }
    }
}
