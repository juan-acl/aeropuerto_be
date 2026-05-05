using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CheckinDigitalService : ICheckinDigitalService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CheckinDigitalService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CheckinDigitalModel>> ListarTodo()
        {
            try { return await _replica.CheckinDigital.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CheckinDigitalModel: {ex.Message}"); return new List<CheckinDigitalModel>(); }
        }

        public async Task<CheckinDigitalModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.CheckinDigital.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CheckinDigitalModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CheckinDigitalModel m)
        {
            try
            {
                string sql = "BEGIN pkg_checkin_digital.insert_checkin(:p_id_reserva, :p_fecha_checkin, :p_ip_origen, :p_dispositivo, :p_pase_abordaje_generado, :p_codigo_qr, :p_enviado_email, :p_enviado_sms); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_reserva", m.IdReserva),
                    new OracleParameter("p_fecha_checkin", (object?)m.FechaCheckin ?? DBNull.Value),
                    new OracleParameter("p_ip_origen", (object?)m.IpOrigen ?? DBNull.Value),
                    new OracleParameter("p_dispositivo", (object?)m.Dispositivo ?? DBNull.Value),
                    new OracleParameter("p_pase_abordaje_generado", m.PaseAbordajeGenerado),
                    new OracleParameter("p_codigo_qr", (object?)m.CodigoQr ?? DBNull.Value),
                    new OracleParameter("p_enviado_email", m.EnviadoEmail),
                    new OracleParameter("p_enviado_sms", m.EnviadoSms)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar CheckinDigitalModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, CheckinDigitalModel m)
        {
            try
            {
                string sql = "BEGIN pkg_checkin_digital.update_checkin(:p_id_checkin, :p_id_reserva, :p_fecha_checkin, :p_ip_origen, :p_dispositivo, :p_pase_abordaje_generado, :p_codigo_qr, :p_enviado_email, :p_enviado_sms); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_checkin", id),
                    new OracleParameter("p_id_reserva", m.IdReserva),
                    new OracleParameter("p_fecha_checkin", (object?)m.FechaCheckin ?? DBNull.Value),
                    new OracleParameter("p_ip_origen", (object?)m.IpOrigen ?? DBNull.Value),
                    new OracleParameter("p_dispositivo", (object?)m.Dispositivo ?? DBNull.Value),
                    new OracleParameter("p_pase_abordaje_generado", m.PaseAbordajeGenerado),
                    new OracleParameter("p_codigo_qr", (object?)m.CodigoQr ?? DBNull.Value),
                    new OracleParameter("p_enviado_email", m.EnviadoEmail),
                    new OracleParameter("p_enviado_sms", m.EnviadoSms)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar CheckinDigitalModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_checkin_digital.delete_checkin(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar CheckinDigitalModel: {ex.Message}"); throw; }
        }
    }
}
