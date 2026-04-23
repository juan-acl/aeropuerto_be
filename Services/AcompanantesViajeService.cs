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
            var sql = "pkg_acompanantes_viaje.insert_acompanante";

            var parametros = new[] {
                new OracleParameter("p_id_pasajero_principal", m.IdPasajeroPrincipal),
                new OracleParameter("p_id_pasajero_acompanante", m.IdPasajeroAcompanante),
                new OracleParameter("p_frecuencia", m.Frecuencia),
                new OracleParameter("p_relacion", m.Relacion),
                new OracleParameter("p_ultimo_viaje_juntos", (object?)m.UltimoViajeJuntos ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_pasajero_principal, :p_id_pasajero_acompanante, :p_frecuencia, :p_relacion, :p_ultimo_viaje_juntos); END;", parametros);
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
            var sql = "pkg_acompanantes_viaje.update_acompanante";

            var parametros = new[] {
                new OracleParameter("p_id_acompanante", id),
                new OracleParameter("p_id_pasajero_acompanante", m.IdPasajeroAcompanante),
                new OracleParameter("p_frecuencia", m.Frecuencia),
                new OracleParameter("p_relacion", m.Relacion),
                new OracleParameter("p_ultimo_viaje_juntos", (object?)m.UltimoViajeJuntos ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_acompanante, :p_id_pasajero_acompanante, :p_frecuencia, :p_relacion, :p_ultimo_viaje_juntos); END;", parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "pkg_acompanantes_viaje.delete_acompanante";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_acompanante); END;", new OracleParameter("p_id_acompanante", id));
            return true;
        }
    }
}