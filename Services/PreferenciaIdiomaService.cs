using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PreferenciaIdiomaService : IPreferenciaIdiomaService
    {
        private readonly DBContext _context;

        public PreferenciaIdiomaService(DBContext context) => _context = context;

        public async Task<bool> Insertar(PreferenciaIdiomaModel m)
        {
            var sql = @"INSERT INTO preferencias_idiomas (id_pasajero, idioma, nivel, preferido) 
                        VALUES (:p_id, :p_idioma, :p_nivel, :p_pref)";

            var parametros = new[] {
                new OracleParameter("p_id", m.IdPasajero),
                new OracleParameter("p_idioma", m.Idioma),
                new OracleParameter("p_nivel", m.Nivel),
                new OracleParameter("p_pref", m.Preferido)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<PreferenciaIdiomaModel>> ListarPorPasajero(int idPasajero)
        {
            return await _context.PreferenciasIdiomas
                .Where(i => i.IdPasajero == idPasajero)
                .ToListAsync();
        }

        public async Task<bool> Actualizar(int id, PreferenciaIdiomaModel m)
        {
            var sql = @"UPDATE preferencias_idiomas 
                        SET idioma = :p_idioma, nivel = :p_nivel, preferido = :p_pref 
                        WHERE id_preferencia_idioma = :p_id";

            var parametros = new[] {
                new OracleParameter("p_idioma", m.Idioma),
                new OracleParameter("p_nivel", m.Nivel),
                new OracleParameter("p_pref", m.Preferido),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM preferencias_idiomas WHERE id_preferencia_idioma = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}