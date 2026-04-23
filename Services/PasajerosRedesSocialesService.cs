using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PasajerosRedesSocialesService : IPasajerosRedesSocialesService
    {
        private readonly DBContext _context;

        public PasajerosRedesSocialesService(DBContext context) => _context = context;

        public async Task<bool> Insertar(PasajerosRedesSocialesModel m)
        {
            var sql = "pkg_pasajeros_redes_sociales.insert_red_social";

            var parametros = new[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_red_social", m.RedSocial),
                new OracleParameter("p_usuario", (object?)m.Usuario ?? DBNull.Value),
                new OracleParameter("p_url_perfil", (object?)m.UrlPerfil ?? DBNull.Value),
                new OracleParameter("p_publico", m.Publico)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_pasajero, :p_red_social, :p_usuario, :p_url_perfil, :p_publico); END;", parametros);
            return true;
        }

        public async Task<List<PasajerosRedesSocialesModel>> ListarPorPasajero(int idPasajero)
        {
            return await _context.PasajerosRedesSociales
                .Where(r => r.IdPasajero == idPasajero)
                .ToListAsync();
        }

        public async Task<bool> Actualizar(int id, PasajerosRedesSocialesModel m)
        {
            var sql = "pkg_pasajeros_redes_sociales.update_red_social";

            var parametros = new[] {
                new OracleParameter("p_id_red_social", id),
                new OracleParameter("p_red_social", m.RedSocial),
                new OracleParameter("p_usuario", (object?)m.Usuario ?? DBNull.Value),
                new OracleParameter("p_url_perfil", (object?)m.UrlPerfil ?? DBNull.Value),
                new OracleParameter("p_publico", m.Publico)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_red_social, :p_red_social, :p_usuario, :p_url_perfil, :p_publico); END;", parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "pkg_pasajeros_redes_sociales.delete_red_social";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_red_social); END;", new OracleParameter("p_id_red_social", id));
            return true;
        }
    }
}