using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class AcompanantesViajeService : IAcompanantesViajeService
    {
        private readonly DBContext _context;

        public AcompanantesViajeService(DBContext context) => _context = context;

        public async Task<bool> Insertar(AcompanantesViajeModel m)
        {
            var sql = @"INSERT INTO acompanantes_viaje 
                        (id_pasajero_principal, id_pasajero_acompanante, frecuencia, relacion, ultimo_viaje_juntos) 
                        VALUES (:p_principal, :p_acompanante, :p_frec, :p_rel, :p_fecha)";

            var parametros = new[] {
                new OracleParameter("p_principal", m.IdPasajeroPrincipal),
                new OracleParameter("p_acompanante", m.IdPasajeroAcompanante),
                new OracleParameter("p_frec", m.Frecuencia),
                new OracleParameter("p_rel", m.Relacion),
                new OracleParameter("p_fecha", (object?)m.UltimoViajeJuntos ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<AcompanantesViajeModel>> ListarPorPasajeroPrincipal(int idPasajeroPrincipal)
        {
            return await _context.AcompanantesViaje
                .Where(a => a.IdPasajeroPrincipal == idPasajeroPrincipal)
                .ToListAsync();
        }

        public async Task<bool> Actualizar(int id, AcompanantesViajeModel m)
        {
            var sql = @"UPDATE acompanantes_viaje 
                        SET id_pasajero_acompanante = :p_acompanante, 
                            frecuencia = :p_frec, 
                            relacion = :p_rel, 
                            ultimo_viaje_juntos = :p_fecha 
                        WHERE id_acompanante = :p_id";

            var parametros = new[] {
                new OracleParameter("p_acompanante", m.IdPasajeroAcompanante),
                new OracleParameter("p_frec", m.Frecuencia),
                new OracleParameter("p_rel", m.Relacion),
                new OracleParameter("p_fecha", (object?)m.UltimoViajeJuntos ?? DBNull.Value),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM acompanantes_viaje WHERE id_acompanante = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}