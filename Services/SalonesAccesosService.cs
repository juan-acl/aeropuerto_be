using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class SalonesAccesosService : ISalonesAccesosService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public SalonesAccesosService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<SalonesAccesosModel>> ListarTodo()
        {
            try { return await _replica.SalonesAccesos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo SalonesAccesosModel: {ex.Message}"); return new List<SalonesAccesosModel>(); }
        }

        public async Task<SalonesAccesosModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.SalonesAccesos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId SalonesAccesosModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(SalonesAccesosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_salones_accesos.insert_acceso(:p_id_salon, :p_id_pasajero, :p_id_vuelo, :p_fecha_acceso, :p_hora_entrada, :p_hora_salida, :p_tipo_acceso, :p_costo, :p_autorizado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_salon", (object?)m.IdSalon ?? DBNull.Value),
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_fecha_acceso", (object?)m.FechaAcceso ?? DBNull.Value),
                    new OracleParameter("p_hora_entrada", (object?)m.HoraEntrada ?? DBNull.Value),
                    new OracleParameter("p_hora_salida", (object?)m.HoraSalida ?? DBNull.Value),
                    new OracleParameter("p_tipo_acceso", (object?)m.TipoAcceso ?? DBNull.Value),
                    new OracleParameter("p_costo", (object?)m.Costo ?? DBNull.Value),
                    new OracleParameter("p_autorizado_por", (object?)m.AutorizadoPor ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar SalonesAccesosModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, SalonesAccesosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_salones_accesos.update_acceso(:p_id_acceso, :p_id_salon, :p_id_pasajero, :p_id_vuelo, :p_fecha_acceso, :p_hora_entrada, :p_hora_salida, :p_tipo_acceso, :p_costo, :p_autorizado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_acceso", id),
                    new OracleParameter("p_id_salon", (object?)m.IdSalon ?? DBNull.Value),
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_fecha_acceso", (object?)m.FechaAcceso ?? DBNull.Value),
                    new OracleParameter("p_hora_entrada", (object?)m.HoraEntrada ?? DBNull.Value),
                    new OracleParameter("p_hora_salida", (object?)m.HoraSalida ?? DBNull.Value),
                    new OracleParameter("p_tipo_acceso", (object?)m.TipoAcceso ?? DBNull.Value),
                    new OracleParameter("p_costo", (object?)m.Costo ?? DBNull.Value),
                    new OracleParameter("p_autorizado_por", (object?)m.AutorizadoPor ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar SalonesAccesosModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_salones_accesos.delete_acceso(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar SalonesAccesosModel: {ex.Message}"); throw; }
        }
    }
}
