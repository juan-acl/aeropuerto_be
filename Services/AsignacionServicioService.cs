using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class AsignacionServicioService : IAsignacionServicioTransporteService
    {
        private readonly DBContext _context;
        public AsignacionServicioService(DBContext context) => _context = context;

        public async Task<bool> Insertar(AsignacionServiciosTransporte m)
        {
            var p = new[] {
                new OracleParameter("p_id_reserva_transporte", (object?)m.IdReservaTransporte ?? DBNull.Value),
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
                new OracleParameter("p_comentarios_pasajero", (object?)m.ComentariosPasajero ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_asignacion_servicios.insert_asignacion(:p_id_reserva_transporte, :p_id_vehiculo_transporte, :p_id_chofer_transporte, :p_fecha_asignacion, :p_asignado_por, :p_hora_llegada_vehiculo, :p_hora_inicio_servicio, :p_hora_fin_servicio, :p_kilometraje_inicio, :p_kilometraje_fin, :p_incidencias, :p_calificacion_pasajero, :p_comentarios_pasajero); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id,AsignacionServiciosTransporte m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_asignacion_servicio", m.IdAsignacionServicio)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_reserva_transporte", (object?)m.IdReservaTransporte ?? DBNull.Value),
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
                new OracleParameter("p_comentarios_pasajero", (object?)m.ComentariosPasajero ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_asignacion_servicios.update_asignacion(:p_id_asignacion_servicio, :p_id_reserva_transporte, :p_id_vehiculo_transporte, :p_id_chofer_transporte, :p_fecha_asignacion, :p_asignado_por, :p_hora_llegada_vehiculo, :p_hora_inicio_servicio, :p_hora_fin_servicio, :p_kilometraje_inicio, :p_kilometraje_fin, :p_incidencias, :p_calificacion_pasajero, :p_comentarios_pasajero); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_asignacion_servicios.delete_asignacion(:p_id_asignacion_servicio); END;", 
                new OracleParameter("p_id_asignacion_servicio", id));
            return true;
        }

        public async Task<List<AsignacionServiciosTransporte>> ListarTodo() => await _context.Set<AsignacionServiciosTransporte>().ToListAsync();

        public async Task<AsignacionServiciosTransporte?> ObtenerPorId(int id) => await _context.Set<AsignacionServiciosTransporte>().FindAsync(id);
    }
}
