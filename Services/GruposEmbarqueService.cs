using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class GruposEmbarqueService : IGruposEmbarqueService
    {
        private readonly DBContext _context;

        public GruposEmbarqueService(DBContext context) => _context = context;

        public async Task<bool> Insertar(GruposEmbarqueModel m)
        {
            var sql = @"INSERT INTO grupos_embarque 
                        (id_vuelo, numero_grupo, descripcion, orden, tiempo_estimado) 
                        VALUES (:p_vuelo, :p_num, :p_desc, :p_orden, :p_tiempo)";

            var parametros = new[] {
                new OracleParameter("p_vuelo", m.IdVuelo),
                new OracleParameter("p_num", m.NumeroGrupo),
                new OracleParameter("p_desc", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_orden", m.Orden),
                new OracleParameter("p_tiempo", (object?)m.TiempoEstimado ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<GruposEmbarqueModel>> ListarPorVuelo(int idVuelo)
        {
            return await _context.GruposEmbarque
                .Where(g => g.IdVuelo == idVuelo)
                .OrderBy(g => g.Orden)
                .ToListAsync();
        }

        public async Task<bool> Actualizar(int id, GruposEmbarqueModel m)
        {
            var sql = @"UPDATE grupos_embarque 
                        SET numero_grupo = :p_num, descripcion = :p_desc, 
                            orden = :p_orden, tiempo_estimado = :p_tiempo 
                        WHERE id_grupo_embarque = :p_id";

            var parametros = new[] {
                new OracleParameter("p_num", m.NumeroGrupo),
                new OracleParameter("p_desc", m.Descripcion),
                new OracleParameter("p_orden", m.Orden),
                new OracleParameter("p_tiempo", m.TiempoEstimado),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM grupos_embarque WHERE id_grupo_embarque = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}