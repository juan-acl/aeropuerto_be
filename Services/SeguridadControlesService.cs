using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class SeguridadControlesService : ISeguridadControlesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public SeguridadControlesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<SeguridadControlesModel>> ListarTodo()
        {
            try { return await _replica.SeguridadControles.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo SeguridadControlesModel: {ex.Message}"); return new List<SeguridadControlesModel>(); }
        }

        public async Task<SeguridadControlesModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.SeguridadControles.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId SeguridadControlesModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(SeguridadControlesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_seguridad_controles.insert_control(:p_codigo_aeropuerto, :p_fecha_control, :p_hora_control, :p_tipo_control, :p_numero_pasajeros, :p_numero_incidencias, :p_supervisor, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_fecha_control", (object?)m.FechaControl ?? DBNull.Value),
                    new OracleParameter("p_hora_control", (object?)m.HoraControl ?? DBNull.Value),
                    new OracleParameter("p_tipo_control", (object?)m.TipoControl ?? DBNull.Value),
                    new OracleParameter("p_numero_pasajeros", DBNull.Value),
                    new OracleParameter("p_numero_incidencias", m.NumeroIncidencias),
                    new OracleParameter("p_supervisor", (object?)m.Supervisor ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar SeguridadControlesModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, SeguridadControlesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_seguridad_controles.update_control(:p_id_control, :p_codigo_aeropuerto, :p_fecha_control, :p_hora_control, :p_tipo_control, :p_numero_pasajeros, :p_numero_incidencias, :p_supervisor, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_control", id),
                    new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_fecha_control", (object?)m.FechaControl ?? DBNull.Value),
                    new OracleParameter("p_hora_control", (object?)m.HoraControl ?? DBNull.Value),
                    new OracleParameter("p_tipo_control", (object?)m.TipoControl ?? DBNull.Value),
                    new OracleParameter("p_numero_pasajeros", DBNull.Value),
                    new OracleParameter("p_numero_incidencias", m.NumeroIncidencias),
                    new OracleParameter("p_supervisor", (object?)m.Supervisor ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar SeguridadControlesModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_seguridad_controles.delete_control(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar SeguridadControlesModel: {ex.Message}"); throw; }
        }
    }
}
