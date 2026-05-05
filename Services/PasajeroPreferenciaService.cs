using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PasajeroPreferenciaService : IPasajeroPreferenciaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PasajeroPreferenciaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PasajeroPreferenciaModel>> ListarTodo()
        {
            try { return await _replica.PasajerosPreferencias.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PasajeroPreferenciaModel: {ex.Message}"); return new List<PasajeroPreferenciaModel>(); }
        }

        public async Task<PasajeroPreferenciaModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.PasajerosPreferencias.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PasajeroPreferenciaModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PasajeroPreferenciaModel m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_preferencias.insert_preferencia(:p_id_pasajero, :p_tipo_preferencia, :p_descripcion, :p_activo, :p_fecha_actualizacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pasajero", m.IdPasajero),
                    new OracleParameter("p_tipo_preferencia", (object?)m.TipoPreferencia ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo),
                    new OracleParameter("p_fecha_actualizacion", (object?)m.FechaActualizacion ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PasajeroPreferenciaModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, PasajeroPreferenciaModel m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_preferencias.update_preferencia(:p_id_preferencia, :p_id_pasajero, :p_tipo_preferencia, :p_descripcion, :p_activo, :p_fecha_actualizacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_preferencia", id),
                    new OracleParameter("p_id_pasajero", m.IdPasajero),
                    new OracleParameter("p_tipo_preferencia", (object?)m.TipoPreferencia ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo),
                    new OracleParameter("p_fecha_actualizacion", (object?)m.FechaActualizacion ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PasajeroPreferenciaModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_preferencias.delete_preferencia(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PasajeroPreferenciaModel: {ex.Message}"); throw; }
        }
    }
}
