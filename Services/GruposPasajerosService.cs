using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class GruposPasajerosService : IGruposPasajerosService
    {
        private readonly DBContext _context;

        public GruposPasajerosService(DBContext context) => _context = context;

        public async Task<bool> AsignarPasajero(GruposPasajerosModel m)
        {
            var sql = "pkg_grupos_pasajeros.insert_grupo_pasajero";

            var parametros = new[] {
                new OracleParameter("p_id_grupo", m.IdGrupo),
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_rol_en_grupo", (object?)m.RolEnGrupo ?? "MIEMBRO")
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_grupo, :p_id_pasajero, :p_rol_en_grupo); END;", parametros);
            return true;
        }

        public async Task<List<GruposPasajerosModel>> ListarPasajerosPorGrupo(int idGrupo)
        {
            return await _context.GruposPasajeros
                .Where(gp => gp.IdGrupo == idGrupo)
                .ToListAsync();
        }

        public async Task<bool> EliminarRelacion(int idGrupo, int idPasajero)
        {
            var sql = "pkg_grupos_pasajeros.delete_grupo_pasajero";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_grupo, :p_id_pasajero); END;",
                new OracleParameter("p_id_grupo", idGrupo),
                new OracleParameter("p_id_pasajero", idPasajero));
            return true;
        }
    }
}