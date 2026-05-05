using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class SeguimientoCargaService : ISeguimientoCargaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public SeguimientoCargaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<SeguimientoCarga>> ListarTodo()
        {
            try { return await _replica.SEGUIMIENTO_CARGA.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo SeguimientoCarga: {ex.Message}"); return new List<SeguimientoCarga>(); }
        }

        public async Task<SeguimientoCarga ?> ObtenerPorId(int id)
        {
            try { return await _replica.SEGUIMIENTO_CARGA.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId SeguimientoCarga: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(SeguimientoCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_seguimiento_carga.insert_seguimiento(:p_id_envio, :p_fecha_hora, :p_ubicacion, :p_estado, :p_responsable, :p_observaciones, :p_temperatura_registrada, :p_incidente); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_envio", m.IdEnvio),
                    new OracleParameter("p_fecha_hora", DBNull.Value),
                    new OracleParameter("p_ubicacion", DBNull.Value),
                    new OracleParameter("p_estado", DBNull.Value),
                    new OracleParameter("p_responsable", DBNull.Value),
                    new OracleParameter("p_observaciones", DBNull.Value),
                    new OracleParameter("p_temperatura_registrada", DBNull.Value),
                    new OracleParameter("p_incidente", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar SeguimientoCarga: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, SeguimientoCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_seguimiento_carga.update_seguimiento(:p_id_seguimiento, :p_id_envio, :p_fecha_hora, :p_ubicacion, :p_estado, :p_responsable, :p_observaciones, :p_temperatura_registrada, :p_incidente); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_seguimiento", id),
                    new OracleParameter("p_id_envio", m.IdEnvio),
                    new OracleParameter("p_fecha_hora", DBNull.Value),
                    new OracleParameter("p_ubicacion", DBNull.Value),
                    new OracleParameter("p_estado", DBNull.Value),
                    new OracleParameter("p_responsable", DBNull.Value),
                    new OracleParameter("p_observaciones", DBNull.Value),
                    new OracleParameter("p_temperatura_registrada", DBNull.Value),
                    new OracleParameter("p_incidente", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar SeguimientoCarga: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_seguimiento_carga.delete_seguimiento(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar SeguimientoCarga: {ex.Message}"); throw; }
        }
    }
}
