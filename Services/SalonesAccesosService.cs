using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class SalonesAccesosService : ISalonesAccesosService
    {
        private readonly DBContext _context;

        public SalonesAccesosService(DBContext context) => _context = context;

        public async Task<int> RegistrarEntrada(SalonesAccesosModel m)
        {
            // Usamos TRUNC(SYSDATE) para la fecha y SYSTIMESTAMP para la hora exacta
            var sql = @"INSERT INTO salones_accesos 
                        (id_salon, id_pasajero, id_vuelo, fecha_acceso, hora_entrada, 
                         tipo_acceso, costo, autorizado_por) 
                        VALUES (:p_salon, :p_pas, :p_vuelo, TRUNC(SYSDATE), SYSTIMESTAMP, 
                                :p_tipo, :p_costo, :p_aut)
                        RETURNING id_acceso INTO :p_id_out";

            var idOutParam = new OracleParameter("p_id_out", OracleDbType.Int32, ParameterDirection.Output);

            var parametros = new[] {
                new OracleParameter("p_salon", (object?)m.IdSalon ?? DBNull.Value),
                new OracleParameter("p_pas", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_tipo", m.TipoAcceso),
                new OracleParameter("p_costo", (object?)m.Costo ?? DBNull.Value),
                new OracleParameter("p_aut", (object?)m.AutorizadoPor ?? DBNull.Value),
                idOutParam
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);

            // Retornamos el ID por si el frontend necesita generar un ticket o código QR de salida
            return Convert.ToInt32(idOutParam.Value.ToString());
        }

        public async Task<bool> RegistrarSalida(int idAcceso)
        {
            // Actualiza la hora de salida a la hora actual del servidor de base de datos
            var sql = @"UPDATE salones_accesos 
                        SET hora_salida = SYSTIMESTAMP 
                        WHERE id_acceso = :p_id AND hora_salida IS NULL";

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", idAcceso));

            // Si rowsAffected es 0, significa que el acceso no existe o ya tenía hora de salida
            return rowsAffected > 0;
        }

        public async Task<List<SalonesAccesosModel>> ListarAccesosActivos(int idSalon)
        {
            // Retorna los pasajeros que actualmente están dentro del salón (no tienen hora de salida)
            return await _context.SalonesAccesos
                .Where(a => a.IdSalon == idSalon && a.HoraSalida == null)
                .OrderByDescending(a => a.HoraEntrada)
                .ToListAsync();
        }

        public async Task<List<SalonesAccesosModel>> ListarHistorialPorSalon(int idSalon, DateTime fecha)
        {
            return await _context.SalonesAccesos
                .Where(a => a.IdSalon == idSalon && a.FechaAcceso == fecha.Date)
                .OrderBy(a => a.HoraEntrada)
                .ToListAsync();
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM salones_accesos WHERE id_acceso = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}