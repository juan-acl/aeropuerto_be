using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PuertasEmbarqueAsignacionService : IPuertasEmbarqueAsignacionService
    {
        private readonly DBContext _context;

        public PuertasEmbarqueAsignacionService(DBContext context) => _context = context;

        public async Task<bool> Insertar(PuertasEmbarqueAsignacionModel m)
        {
            var sql = @"INSERT INTO puertas_embarque_asignacion 
                        (id_puerta, id_vuelo, fecha_asignacion, hora_inicio, hora_fin, asignado_por) 
                        VALUES (:p_puerta, :p_vuelo, SYSTIMESTAMP, :p_inicio, :p_fin, :p_user)";

            var parametros = new[] {
                new OracleParameter("p_puerta", m.IdPuerta),
                new OracleParameter("p_vuelo", m.IdVuelo),
                new OracleParameter("p_inicio", m.HoraInicio),
                new OracleParameter("p_fin", m.HoraFin),
                new OracleParameter("p_user", m.AsignadoPor)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<PuertasEmbarqueAsignacionModel>> ListarPorVuelo(int idVuelo)
        {
            return await _context.PuertasEmbarqueAsignacion
                .Where(a => a.IdVuelo == idVuelo)
                .ToListAsync();
        }

        public async Task<List<PuertasEmbarqueAsignacionModel>> ListarOcupacionActual()
        {
            var ahora = DateTime.Now;
            return await _context.PuertasEmbarqueAsignacion
                .Where(a => ahora >= a.HoraInicio && ahora <= a.HoraFin)
                .ToListAsync();
        }

        public async Task<bool> Actualizar(int id, PuertasEmbarqueAsignacionModel m)
        {
            var sql = @"UPDATE puertas_embarque_asignacion 
                        SET id_puerta = :p_puerta, hora_inicio = :p_inicio, hora_fin = :p_fin 
                        WHERE id_asignacion_puerta = :p_id";

            var parametros = new[] {
                new OracleParameter("p_puerta", m.IdPuerta),
                new OracleParameter("p_inicio", m.HoraInicio),
                new OracleParameter("p_fin", m.HoraFin),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM puertas_embarque_asignacion WHERE id_asignacion_puerta = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}