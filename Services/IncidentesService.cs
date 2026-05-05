using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class IncidentesService : IIncidentesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public IncidentesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<IncidentesModel>> ListarTodo()
        {
            try { return await _replica.Incidentes.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo IncidentesModel: {ex.Message}"); return new List<IncidentesModel>(); }
        }

        public async Task<IncidentesModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.Incidentes.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId IncidentesModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(IncidentesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes.insert_incidente(:p_id_pasajero, :p_id_vuelo, :p_codigo_aeropuerto, :p_fecha_incidente, :p_hora_incidente, :p_tipo_incidente, :p_nivel_gravedad, :p_descripcion, :p_lugar_incidente, :p_autoridad_involucrada, :p_oficial_a_cargo, :p_resolucion, :p_fecha_resolucion, :p_estado, :p_requiere_seguimiento); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_fecha_incidente", (object?)m.FechaIncidente ?? DBNull.Value),
                    new OracleParameter("p_hora_incidente", (object?)m.HoraIncidente ?? DBNull.Value),
                    new OracleParameter("p_tipo_incidente", (object?)m.TipoIncidente ?? DBNull.Value),
                    new OracleParameter("p_nivel_gravedad", (object?)m.NivelGravedad ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_lugar_incidente", (object?)m.LugarIncidente ?? DBNull.Value),
                    new OracleParameter("p_autoridad_involucrada", (object?)m.AutoridadInvolucrada ?? DBNull.Value),
                    new OracleParameter("p_oficial_a_cargo", (object?)m.OficialACargo ?? DBNull.Value),
                    new OracleParameter("p_resolucion", (object?)m.Resolucion ?? DBNull.Value),
                    new OracleParameter("p_fecha_resolucion", (object?)m.FechaResolucion ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_requiere_seguimiento", m.RequiereSeguimiento)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar IncidentesModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, IncidentesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes.update_incidente(:p_id_incidente, :p_id_pasajero, :p_id_vuelo, :p_codigo_aeropuerto, :p_fecha_incidente, :p_hora_incidente, :p_tipo_incidente, :p_nivel_gravedad, :p_descripcion, :p_lugar_incidente, :p_autoridad_involucrada, :p_oficial_a_cargo, :p_resolucion, :p_fecha_resolucion, :p_estado, :p_requiere_seguimiento); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_incidente", id),
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_fecha_incidente", (object?)m.FechaIncidente ?? DBNull.Value),
                    new OracleParameter("p_hora_incidente", (object?)m.HoraIncidente ?? DBNull.Value),
                    new OracleParameter("p_tipo_incidente", (object?)m.TipoIncidente ?? DBNull.Value),
                    new OracleParameter("p_nivel_gravedad", (object?)m.NivelGravedad ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_lugar_incidente", (object?)m.LugarIncidente ?? DBNull.Value),
                    new OracleParameter("p_autoridad_involucrada", (object?)m.AutoridadInvolucrada ?? DBNull.Value),
                    new OracleParameter("p_oficial_a_cargo", (object?)m.OficialACargo ?? DBNull.Value),
                    new OracleParameter("p_resolucion", (object?)m.Resolucion ?? DBNull.Value),
                    new OracleParameter("p_fecha_resolucion", (object?)m.FechaResolucion ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_requiere_seguimiento", m.RequiereSeguimiento)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar IncidentesModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes.delete_incidente(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar IncidentesModel: {ex.Message}"); throw; }
        }
    }
}
