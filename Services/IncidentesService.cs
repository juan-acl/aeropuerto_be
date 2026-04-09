using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class IncidentesService : IIncidentesService
    {
        private readonly DBContext _context;

        public IncidentesService(DBContext context) => _context = context;

        public async Task<bool> Insertar(IncidentesModel m)
        {
            var sql = @"INSERT INTO incidentes 
                        (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_incidente, hora_incidente, 
                         tipo_incidente, nivel_gravedad, descripcion, lugar_incidente, 
                         autoridad_involucrada, oficial_a_cargo, estado, requiere_seguimiento) 
                        VALUES (:p_pas, :p_vuelo, :p_aero, SYSDATE, SYSTIMESTAMP, 
                                :p_tipo, :p_grav, :p_desc, :p_lugar, :p_aut, :p_ofic, :p_est, :p_seg)";

            var parametros = new[] {
                new OracleParameter("p_pas", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_aero", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_tipo", m.TipoIncidente),
                new OracleParameter("p_grav", m.NivelGravedad),
                new OracleParameter("p_desc", m.Descripcion),
                new OracleParameter("p_lugar", (object?)m.LugarIncidente ?? DBNull.Value),
                new OracleParameter("p_aut", (object?)m.AutoridadInvolucrada ?? DBNull.Value),
                new OracleParameter("p_ofic", (object?)m.OficialACargo ?? DBNull.Value),
                new OracleParameter("p_est", m.Estado),
                new OracleParameter("p_seg", m.RequiereSeguimiento)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<IncidentesModel>> ListarPorFiltro(string? gravedad, string? estado)
        {
            var query = _context.Incidentes.AsQueryable();

            if (!string.IsNullOrEmpty(gravedad)) query = query.Where(i => i.NivelGravedad == gravedad);
            if (!string.IsNullOrEmpty(estado)) query = query.Where(i => i.Estado == estado);

            return await query.OrderByDescending(i => i.FechaIncidente).ToListAsync();
        }

        public async Task<IncidentesModel?> ObtenerPorId(int id)
        {
            return await _context.Incidentes.FindAsync(id);
        }

        public async Task<bool> ResolverIncidente(int id, string resolucion)
        {
            var sql = @"UPDATE incidentes 
                        SET resolucion = :p_res, estado = 'RESUELTO', fecha_resolucion = SYSDATE 
                        WHERE id_incidente = :p_id";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_res", resolucion),
                new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM incidentes WHERE id_incidente = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}