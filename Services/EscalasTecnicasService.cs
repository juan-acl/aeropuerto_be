using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EscalasTecnicasService : IEscalasTecnicasService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public EscalasTecnicasService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<EscalasTecnicasModel>> ListarTodo()
        {
            try { return await _replica.EscalasTecnicas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EscalasTecnicasModel: {ex.Message}"); return new List<EscalasTecnicasModel>(); }
        }

        public async Task<EscalasTecnicasModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.EscalasTecnicas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EscalasTecnicasModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EscalasTecnicasModel m)
        {
            try
            {
                string sql = "BEGIN pkg_escalas_tecnicas.insert_escala(:p_id_vuelo, :p_aeropuerto_escala, :p_numero_orden, :p_hora_llegada, :p_hora_despegue, :p_tiempo_escala_minutos, :p_motivo_escala, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_aeropuerto_escala", (object?)m.AeropuertoEscala ?? DBNull.Value),
                    new OracleParameter("p_numero_orden", m.NumeroOrden),
                    new OracleParameter("p_hora_llegada", m.HoraLlegada),
                    new OracleParameter("p_hora_despegue", m.HoraDespegue),
                    new OracleParameter("p_tiempo_escala_minutos", m.TiempoEscalaMinutos),
                    new OracleParameter("p_motivo_escala", (object?)m.MotivoEscala ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar EscalasTecnicasModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, EscalasTecnicasModel m)
        {
            try
            {
                string sql = "BEGIN pkg_escalas_tecnicas.update_escala(:p_id_escala, :p_id_vuelo, :p_aeropuerto_escala, :p_numero_orden, :p_hora_llegada, :p_hora_despegue, :p_tiempo_escala_minutos, :p_motivo_escala, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_escala", id),
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_aeropuerto_escala", (object?)m.AeropuertoEscala ?? DBNull.Value),
                    new OracleParameter("p_numero_orden", m.NumeroOrden),
                    new OracleParameter("p_hora_llegada", m.HoraLlegada),
                    new OracleParameter("p_hora_despegue", m.HoraDespegue),
                    new OracleParameter("p_tiempo_escala_minutos", m.TiempoEscalaMinutos),
                    new OracleParameter("p_motivo_escala", (object?)m.MotivoEscala ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar EscalasTecnicasModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_escalas_tecnicas.delete_escala(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar EscalasTecnicasModel: {ex.Message}"); throw; }
        }
    }
}
