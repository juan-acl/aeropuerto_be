using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class GruposEmbarqueService : IGruposEmbarqueService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public GruposEmbarqueService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<GruposEmbarqueModel>> ListarTodo()
        {
            try { return await _replica.GruposEmbarque.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo GruposEmbarqueModel: {ex.Message}"); return new List<GruposEmbarqueModel>(); }
        }

        public async Task<GruposEmbarqueModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.GruposEmbarque.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId GruposEmbarqueModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(GruposEmbarqueModel m)
        {
            try
            {
                string sql = "BEGIN pkg_grupos_embarque.insert_grupo(:p_id_vuelo, :p_numero_grupo, :p_descripcion, :p_orden, :p_tiempo_estimado); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_numero_grupo", m.NumeroGrupo),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_orden", m.Orden),
                    new OracleParameter("p_tiempo_estimado", (object?)m.TiempoEstimado ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar GruposEmbarqueModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, GruposEmbarqueModel m)
        {
            try
            {
                string sql = "BEGIN pkg_grupos_embarque.update_grupo(:p_id_grupo_embarque, :p_id_vuelo, :p_numero_grupo, :p_descripcion, :p_orden, :p_tiempo_estimado); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_grupo_embarque", id),
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_numero_grupo", m.NumeroGrupo),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_orden", m.Orden),
                    new OracleParameter("p_tiempo_estimado", (object?)m.TiempoEstimado ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar GruposEmbarqueModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_grupos_embarque.delete_grupo(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar GruposEmbarqueModel: {ex.Message}"); throw; }
        }
    }
}
