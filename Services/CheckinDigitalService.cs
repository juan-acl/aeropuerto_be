using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class CheckinDigitalService : ICheckinDigitalService
    {
        private readonly DBContext _context;

        public CheckinDigitalService(DBContext context) => _context = context;

        public async Task<bool> RegistrarCheckin(CheckinDigitalModel m)
        {
            var sql = @"INSERT INTO checkin_digital 
                        (id_reserva, fecha_checkin, ip_origen, dispositivo, pase_abordaje_generado, codigo_qr, enviado_email, enviado_sms) 
                        VALUES (:p_res, SYSTIMESTAMP, :p_ip, :p_disp, :p_pase, :p_qr, :p_mail, :p_sms)";

            var parametros = new[] {
                new OracleParameter("p_res", m.IdReserva),
                new OracleParameter("p_ip", (object?)m.IpOrigen ?? DBNull.Value),
                new OracleParameter("p_disp", (object?)m.Dispositivo ?? DBNull.Value),
                new OracleParameter("p_pase", m.PaseAbordajeGenerado),
                new OracleParameter("p_qr", (object?)m.CodigoQr ?? DBNull.Value),
                new OracleParameter("p_mail", m.EnviadoEmail),
                new OracleParameter("p_sms", m.EnviadoSms)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<CheckinDigitalModel?> ObtenerPorReserva(int idReserva)
        {
            return await _context.CheckinDigital
                .FirstOrDefaultAsync(c => c.IdReserva == idReserva);
        }

        public async Task<bool> ActualizarNotificaciones(int id, bool email, bool sms)
        {
            var sql = "UPDATE checkin_digital SET enviado_email = :p_mail, enviado_sms = :p_sms WHERE id_checkin = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_mail", email ? 1 : 0),
                new OracleParameter("p_sms", sms ? 1 : 0),
                new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM checkin_digital WHERE id_checkin = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}