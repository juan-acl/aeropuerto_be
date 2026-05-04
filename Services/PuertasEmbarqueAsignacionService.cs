using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PuertasEmbarqueAsignacionService : IPuertasEmbarqueAsignacionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PuertasEmbarqueAsignacionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PuertasEmbarqueAsignacionModel>> ListarTodo()
        {
            try { return await _replica.PuertasEmbarqueAsignacion.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PuertasEmbarqueAsignacionModel: {ex.Message}"); return new List<PuertasEmbarqueAsignacionModel>(); }
        }

        public async Task<PuertasEmbarqueAsignacionModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.PuertasEmbarqueAsignacion.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PuertasEmbarqueAsignacionModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PuertasEmbarqueAsignacionModel m)
        {
            try
            {
                string sql = "BEGIN pkg_puertas_embarque_asignacion.insert_asignacion(:p_id_puerta, :p_id_vuelo, :p_fecha_asignacion, :p_hora_inicio, :p_hora_fin, :p_asignado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_puerta", m.IdPuerta),
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                    new OracleParameter("p_hora_inicio", m.HoraInicio),
                    new OracleParameter("p_hora_fin", m.HoraFin),
                    new OracleParameter("p_asignado_por", m.AsignadoPor)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PuertasEmbarqueAsignacionModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, PuertasEmbarqueAsignacionModel m)
        {
            try
            {
                string sql = "BEGIN pkg_puertas_embarque_asignacion.update_asignacion(:p_id_asignacion_puerta, :p_id_puerta, :p_id_vuelo, :p_fecha_asignacion, :p_hora_inicio, :p_hora_fin, :p_asignado_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_asignacion_puerta", id),
                    new OracleParameter("p_id_puerta", m.IdPuerta),
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                    new OracleParameter("p_hora_inicio", m.HoraInicio),
                    new OracleParameter("p_hora_fin", m.HoraFin),
                    new OracleParameter("p_asignado_por", m.AsignadoPor)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PuertasEmbarqueAsignacionModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_puertas_embarque_asignacion.delete_asignacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PuertasEmbarqueAsignacionModel: {ex.Message}"); throw; }
        }
    }
}
