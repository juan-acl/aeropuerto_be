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
            var sql = @"INSERT INTO pasajeros_redes_sociales (id_pasajero, red_social, usuario, url_perfil, publico) 
                        VALUES (:p_id, :p_red, :p_user, :p_url, :p_pub)";

            var parametros = new[] {
                new OracleParameter("p_id", m.IdPasajero),
                new OracleParameter("p_red", m.RedSocial),
                new OracleParameter("p_user", (object?)m.Usuario ?? DBNull.Value),
                new OracleParameter("p_url", (object?)m.UrlPerfil ?? DBNull.Value),
                new OracleParameter("p_pub", m.Publico)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
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
            var sql = @"UPDATE pasajeros_redes_sociales 
                        SET red_social = :p_red, usuario = :p_user, url_perfil = :p_url, publico = :p_pub 
                        WHERE id_red_social = :p_id";

            var parametros = new[] {
                new OracleParameter("p_red", m.RedSocial),
                new OracleParameter("p_user", (object?)m.Usuario ?? DBNull.Value),
                new OracleParameter("p_url", (object?)m.UrlPerfil ?? DBNull.Value),
                new OracleParameter("p_pub", m.Publico),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM pasajeros_redes_sociales WHERE id_red_social = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}