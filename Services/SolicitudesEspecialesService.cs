using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class SolicitudesEspecialesService : ISolicitudesEspecialesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public SolicitudesEspecialesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<SolicitudesEspecialesModel>> ListarTodo()
        {
            try { return await _replica.SolicitudesEspeciales.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo SolicitudesEspecialesModel: {ex.Message}"); return new List<SolicitudesEspecialesModel>(); }
        }

        public async Task<SolicitudesEspecialesModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.SolicitudesEspeciales.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId SolicitudesEspecialesModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(SolicitudesEspecialesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_solicitudes_especiales.insert_solicitud(:p_id_reserva, :p_tipo_solicitud, :p_descripcion, :p_fecha_solicitud, :p_estado_solicitud, :p_fecha_resolucion, :p_resolucion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_reserva", m.IdReserva),
                    new OracleParameter("p_tipo_solicitud", (object?)m.TipoSolicitud ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_fecha_solicitud", (object?)m.FechaSolicitud ?? DBNull.Value),
                    new OracleParameter("p_estado_solicitud", (object?)m.EstadoSolicitud ?? DBNull.Value),
                    new OracleParameter("p_fecha_resolucion", (object?)m.FechaResolucion ?? DBNull.Value),
                    new OracleParameter("p_resolucion", (object?)m.Resolucion ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar SolicitudesEspecialesModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, SolicitudesEspecialesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_solicitudes_especiales.update_solicitud(:p_id_solicitud, :p_id_reserva, :p_tipo_solicitud, :p_descripcion, :p_fecha_solicitud, :p_estado_solicitud, :p_fecha_resolucion, :p_resolucion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_solicitud", id),
                    new OracleParameter("p_id_reserva", m.IdReserva),
                    new OracleParameter("p_tipo_solicitud", (object?)m.TipoSolicitud ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_fecha_solicitud", (object?)m.FechaSolicitud ?? DBNull.Value),
                    new OracleParameter("p_estado_solicitud", (object?)m.EstadoSolicitud ?? DBNull.Value),
                    new OracleParameter("p_fecha_resolucion", (object?)m.FechaResolucion ?? DBNull.Value),
                    new OracleParameter("p_resolucion", (object?)m.Resolucion ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar SolicitudesEspecialesModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_solicitudes_especiales.delete_solicitud(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar SolicitudesEspecialesModel: {ex.Message}"); throw; }
        }
    }
}
