using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ControlAbordajeService : IControlAbordajeService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ControlAbordajeService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ControlAbordajeModel>> ListarTodo()
        {
            try { return await _replica.ControlAbordaje.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ControlAbordajeModel: {ex.Message}"); return new List<ControlAbordajeModel>(); }
        }

        public async Task<ControlAbordajeModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.ControlAbordaje.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ControlAbordajeModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ControlAbordajeModel m)
        {
            try
            {
                string sql = "BEGIN pkg_control_abordaje.insert_control(:p_id_vuelo, :p_id_reserva, :p_hora_abordaje, :p_verificado_por, :p_estado, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_id_reserva", m.IdReserva),
                    new OracleParameter("p_hora_abordaje", (object?)m.HoraAbordaje ?? DBNull.Value),
                    new OracleParameter("p_verificado_por", m.VerificadoPor),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ControlAbordajeModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ControlAbordajeModel m)
        {
            try
            {
                string sql = "BEGIN pkg_control_abordaje.update_control(:p_id_control_abordaje, :p_id_vuelo, :p_id_reserva, :p_hora_abordaje, :p_verificado_por, :p_estado, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_control_abordaje", id),
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_id_reserva", m.IdReserva),
                    new OracleParameter("p_hora_abordaje", (object?)m.HoraAbordaje ?? DBNull.Value),
                    new OracleParameter("p_verificado_por", m.VerificadoPor),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ControlAbordajeModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_control_abordaje.delete_control(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ControlAbordajeModel: {ex.Message}"); throw; }
        }
    }
}
