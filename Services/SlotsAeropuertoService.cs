using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class SlotsAeropuertoService : ISlotsAeropuertoService
    {
        private readonly DBContext _context;
        public SlotsAeropuertoService(DBContext context) => _context = context;

        public async Task<List<SlotsAeropuerto>> ListarTodo()
        {
            try { return await _context.SlotsAeropuerto.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo SlotsAeropuerto: {ex.Message}"); return new List<SlotsAeropuerto>(); }
        }

        public async Task<SlotsAeropuerto?> ObtenerPorId(int id)
        {
            try { return await _context.SlotsAeropuerto.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId SlotsAeropuerto: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(SlotsAeropuerto m)
        {
            try
            {
                string sql = "BEGIN pkg_slots_aeropuerto.insert_slot(:p_id_aerolinea, :p_fecha_slot, :p_hora_slot, :p_tipo_operacion, :p_id_vuelo_asignado, :p_estado_slot, :p_fecha_asignacion, :p_asignado_por, :p_fecha_liberacion, :p_motivo_cancelacion); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_aerolinea", m.IdAerolinea),
                new OracleParameter("p_fecha_slot", m.FechaSlot),
                new OracleParameter("p_hora_slot", m.HoraSlot),
                new OracleParameter("p_tipo_operacion", (object?)m.TipoOperacion ?? DBNull.Value),
                new OracleParameter("p_id_vuelo_asignado", (object?)m.IdVueloAsignado ?? DBNull.Value),
                new OracleParameter("p_estado_slot", (object?)m.EstadoSlot ?? DBNull.Value),
                new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_asignado_por", (object?)m.AsignadoPor ?? DBNull.Value),
                new OracleParameter("p_fecha_liberacion", (object?)m.FechaLiberacion ?? DBNull.Value),
                new OracleParameter("p_motivo_cancelacion", (object?)m.MotivoCancelacion ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar SlotsAeropuerto: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, SlotsAeropuerto m)
        {
            try
            {
                string sql = "BEGIN pkg_slots_aeropuerto.update_slot(:p_id_slot, :p_id_aerolinea, :p_fecha_slot, :p_hora_slot, :p_tipo_operacion, :p_id_vuelo_asignado, :p_estado_slot, :p_fecha_asignacion, :p_asignado_por, :p_fecha_liberacion, :p_motivo_cancelacion); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_slot", id),
                new OracleParameter("p_id_aerolinea", m.IdAerolinea),
                new OracleParameter("p_fecha_slot", m.FechaSlot),
                new OracleParameter("p_hora_slot", m.HoraSlot),
                new OracleParameter("p_tipo_operacion", (object?)m.TipoOperacion ?? DBNull.Value),
                new OracleParameter("p_id_vuelo_asignado", (object?)m.IdVueloAsignado ?? DBNull.Value),
                new OracleParameter("p_estado_slot", (object?)m.EstadoSlot ?? DBNull.Value),
                new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_asignado_por", (object?)m.AsignadoPor ?? DBNull.Value),
                new OracleParameter("p_fecha_liberacion", (object?)m.FechaLiberacion ?? DBNull.Value),
                new OracleParameter("p_motivo_cancelacion", (object?)m.MotivoCancelacion ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar SlotsAeropuerto: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_slots_aeropuerto.delete_slot(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar SlotsAeropuerto: {ex.Message}"); return false; }
        }
    }
}
