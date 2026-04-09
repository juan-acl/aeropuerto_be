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
            var sql = @"INSERT INTO grupos_pasajeros (id_grupo, id_pasajero, fecha_asignacion, rol_en_grupo) 
                        VALUES (:p_grupo, :p_pas, SYSDATE, :p_rol)";

            var parametros = new[] {
                new OracleParameter("p_grupo", m.IdGrupo),
                new OracleParameter("p_pas", m.IdPasajero),
                new OracleParameter("p_rol", (object?)m.RolEnGrupo ?? "MIEMBRO")
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
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
            var sql = "DELETE FROM grupos_pasajeros WHERE id_grupo = :p_grupo AND id_pasajero = :p_pas";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_grupo", idGrupo),
                new OracleParameter("p_pas", idPasajero));
            return true;
        }
    }
}