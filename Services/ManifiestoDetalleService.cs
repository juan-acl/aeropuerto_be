using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ManifiestoDetalleService : IManifiestoDetalleService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ManifiestoDetalleService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ManifiestoDetalle>> ListarTodo()
        {
            try { return await _replica.MANIFIESTOS_DETALLE.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ManifiestoDetalle: {ex.Message}"); return new List<ManifiestoDetalle>(); }
        }

        public async Task<ManifiestoDetalle ?> ObtenerPorId(int id)
        {
            try { return await _replica.MANIFIESTOS_DETALLE.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ManifiestoDetalle: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ManifiestoDetalle m)
        {
            try
            {
                string sql = "BEGIN pkg_manifiestos_detalle.insert_detalle(:p_id_manifiesto, :p_id_envio, :p_numero_orden, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_manifiesto", m.IdManifiesto),
                    new OracleParameter("p_id_envio", m.IdEnvio),
                    new OracleParameter("p_numero_orden", DBNull.Value),
                    new OracleParameter("p_observaciones", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ManifiestoDetalle: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ManifiestoDetalle m)
        {
            try
            {
                string sql = "BEGIN pkg_manifiestos_detalle.update_detalle(:p_id_detalle, :p_id_manifiesto, :p_id_envio, :p_numero_orden, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_detalle", id),
                    new OracleParameter("p_id_manifiesto", m.IdManifiesto),
                    new OracleParameter("p_id_envio", m.IdEnvio),
                    new OracleParameter("p_numero_orden", DBNull.Value),
                    new OracleParameter("p_observaciones", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ManifiestoDetalle: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_manifiestos_detalle.delete_detalle(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ManifiestoDetalle: {ex.Message}"); throw; }
        }
    }
}
