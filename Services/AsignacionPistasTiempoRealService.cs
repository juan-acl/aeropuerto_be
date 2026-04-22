using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AsignacionPistasTiempoRealService : IAsignacionPistasTiempoRealService
    {
        private readonly DBContext _context;
        public AsignacionPistasTiempoRealService(DBContext context) => _context = context;

        public async Task<List<AsignacionPistasTiempoReal>> ListarTodo()
        {
            try { return await _context.AsignacionesPistas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AsignacionPistasTiempoReal: {ex.Message}"); return new List<AsignacionPistasTiempoReal>(); }
        }

        public async Task<AsignacionPistasTiempoReal?> ObtenerPorId(int id)
        {
            try { return await _context.AsignacionesPistas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AsignacionPistasTiempoReal: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AsignacionPistasTiempoReal m)
        {
            try
            {
                string sql = "BEGIN pkg_asignacion_pistas.insert_asignacion(:p_id_pista, :p_id_vuelo, :p_tipo_operacion, :p_fecha_hora_asignacion, :p_hora_inicio_estimada, :p_hora_fin_estimada, :p_hora_inicio_real, :p_hora_fin_real, :p_estado_asignacion, :p_asignado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_pista", m.IdPista),
                new OracleParameter("p_id_vuelo", m.IdVuelo),
                new OracleParameter("p_tipo_operacion", (object?)m.TipoOperacion ?? DBNull.Value),
                new OracleParameter("p_fecha_hora_asignacion", (object?)m.FechaHoraAsignacion ?? DBNull.Value),
                new OracleParameter("p_hora_inicio_estimada", m.HoraInicioEstimada),
                new OracleParameter("p_hora_fin_estimada", m.HoraFinEstimada),
                new OracleParameter("p_hora_inicio_real", (object?)m.HoraInicioReal ?? DBNull.Value),
                new OracleParameter("p_hora_fin_real", (object?)m.HoraFinReal ?? DBNull.Value),
                new OracleParameter("p_estado_asignacion", (object?)m.EstadoAsignacion ?? DBNull.Value),
                new OracleParameter("p_asignado_por", (object?)m.AsignadoPor ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar AsignacionPistasTiempoReal: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, AsignacionPistasTiempoReal m)
        {
            try
            {
                string sql = "BEGIN pkg_asignacion_pistas.update_asignacion(:p_id_asignacion_pista, :p_id_pista, :p_id_vuelo, :p_tipo_operacion, :p_fecha_hora_asignacion, :p_hora_inicio_estimada, :p_hora_fin_estimada, :p_hora_inicio_real, :p_hora_fin_real, :p_estado_asignacion, :p_asignado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_asignacion_pista", id),
                new OracleParameter("p_id_pista", m.IdPista),
                new OracleParameter("p_id_vuelo", m.IdVuelo),
                new OracleParameter("p_tipo_operacion", (object?)m.TipoOperacion ?? DBNull.Value),
                new OracleParameter("p_fecha_hora_asignacion", (object?)m.FechaHoraAsignacion ?? DBNull.Value),
                new OracleParameter("p_hora_inicio_estimada", m.HoraInicioEstimada),
                new OracleParameter("p_hora_fin_estimada", m.HoraFinEstimada),
                new OracleParameter("p_hora_inicio_real", (object?)m.HoraInicioReal ?? DBNull.Value),
                new OracleParameter("p_hora_fin_real", (object?)m.HoraFinReal ?? DBNull.Value),
                new OracleParameter("p_estado_asignacion", (object?)m.EstadoAsignacion ?? DBNull.Value),
                new OracleParameter("p_asignado_por", (object?)m.AsignadoPor ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar AsignacionPistasTiempoReal: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_asignacion_pistas.delete_asignacion(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar AsignacionPistasTiempoReal: {ex.Message}"); return false; }
        }
    }
}
