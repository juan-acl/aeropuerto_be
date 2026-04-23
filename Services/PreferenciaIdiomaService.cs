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
            var sql = "pkg_preferencias_idiomas.insert_idioma";

            var parametros = new[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_idioma", m.Idioma),
                new OracleParameter("p_nivel", m.Nivel),
                new OracleParameter("p_preferido", m.Preferido)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_pasajero, :p_idioma, :p_nivel, :p_preferido); END;", parametros);
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
            var sql = "pkg_preferencias_idiomas.update_idioma";

            var parametros = new[] {
                new OracleParameter("p_id_preferencia_idioma", id),
                new OracleParameter("p_idioma", m.Idioma),
                new OracleParameter("p_nivel", m.Nivel),
                new OracleParameter("p_preferido", m.Preferido)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_preferencia_idioma, :p_idioma, :p_nivel, :p_preferido); END;", parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "pkg_preferencias_idiomas.delete_idioma";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_preferencia_idioma); END;", new OracleParameter("p_id_preferencia_idioma", id));
            return true;
        }
    }
}