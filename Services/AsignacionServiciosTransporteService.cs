using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AsignacionServiciosTransporteService : IAsignacionServiciosTransporteService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AsignacionServiciosTransporteService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AsignacionServiciosTransporte>> ListarTodo()
        {
            try { return await _replica.AsignacionesServiciosTransporte.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AsignacionServiciosTransporte: {ex.Message}"); return new List<AsignacionServiciosTransporte>(); }
        }

        public async Task<AsignacionServiciosTransporte ?> ObtenerPorId(int id)
        {
            try { return await _replica.AsignacionesServiciosTransporte.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AsignacionServiciosTransporte: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AsignacionServiciosTransporte m)
        {
            try
            {
                string sql = "BEGIN pkg_asignacion_servicios.insert_asignacion(:p_id_reserva_transporte, :p_id_vehiculo_transporte, :p_id_chofer_transporte, :p_fecha_asignacion, :p_asignado_por, :p_hora_llegada_vehiculo, :p_hora_inicio_servicio, :p_hora_fin_servicio, :p_kilometraje_inicio, :p_kilometraje_fin, :p_incidencias, :p_calificacion_pasajero, :p_comentarios_pasajero); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_reserva_transporte", m.IdReservaTransporte),
                    new OracleParameter("p_id_vehiculo_transporte", (object?)m.IdVehiculoTransporte ?? DBNull.Value),
                    new OracleParameter("p_id_chofer_transporte", (object?)m.IdChoferTransporte ?? DBNull.Value),
                    new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                    new OracleParameter("p_asignado_por", (object?)m.AsignadoPor ?? DBNull.Value),
                    new OracleParameter("p_hora_llegada_vehiculo", (object?)m.HoraLlegadaVehiculo ?? DBNull.Value),
                    new OracleParameter("p_hora_inicio_servicio", (object?)m.HoraInicioServicio ?? DBNull.Value),
                    new OracleParameter("p_hora_fin_servicio", (object?)m.HoraFinServicio ?? DBNull.Value),
                    new OracleParameter("p_kilometraje_inicio", (object?)m.KilometrajeInicio ?? DBNull.Value),
                    new OracleParameter("p_kilometraje_fin", (object?)m.KilometrajeFin ?? DBNull.Value),
                    new OracleParameter("p_incidencias", (object?)m.Incidencias ?? DBNull.Value),
                    new OracleParameter("p_calificacion_pasajero", (object?)m.CalificacionPasajero ?? DBNull.Value),
                    new OracleParameter("p_comentarios_pasajero", (object?)m.ComentariosPasajero ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar AsignacionServiciosTransporte: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, AsignacionServiciosTransporte m)
        {
            try
            {
                string sql = "BEGIN pkg_asignacion_servicios.update_asignacion(:p_id_asignacion_servicio, :p_id_reserva_transporte, :p_id_vehiculo_transporte, :p_id_chofer_transporte, :p_fecha_asignacion, :p_asignado_por, :p_hora_llegada_vehiculo, :p_hora_inicio_servicio, :p_hora_fin_servicio, :p_kilometraje_inicio, :p_kilometraje_fin, :p_incidencias, :p_calificacion_pasajero, :p_comentarios_pasajero); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_asignacion_servicio", id),
                    new OracleParameter("p_id_reserva_transporte", m.IdReservaTransporte),
                    new OracleParameter("p_id_vehiculo_transporte", (object?)m.IdVehiculoTransporte ?? DBNull.Value),
                    new OracleParameter("p_id_chofer_transporte", (object?)m.IdChoferTransporte ?? DBNull.Value),
                    new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                    new OracleParameter("p_asignado_por", (object?)m.AsignadoPor ?? DBNull.Value),
                    new OracleParameter("p_hora_llegada_vehiculo", (object?)m.HoraLlegadaVehiculo ?? DBNull.Value),
                    new OracleParameter("p_hora_inicio_servicio", (object?)m.HoraInicioServicio ?? DBNull.Value),
                    new OracleParameter("p_hora_fin_servicio", (object?)m.HoraFinServicio ?? DBNull.Value),
                    new OracleParameter("p_kilometraje_inicio", (object?)m.KilometrajeInicio ?? DBNull.Value),
                    new OracleParameter("p_kilometraje_fin", (object?)m.KilometrajeFin ?? DBNull.Value),
                    new OracleParameter("p_incidencias", (object?)m.Incidencias ?? DBNull.Value),
                    new OracleParameter("p_calificacion_pasajero", (object?)m.CalificacionPasajero ?? DBNull.Value),
                    new OracleParameter("p_comentarios_pasajero", (object?)m.ComentariosPasajero ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar AsignacionServiciosTransporte: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_asignacion_servicios.delete_asignacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar AsignacionServiciosTransporte: {ex.Message}"); throw; }
        }
    }
}
