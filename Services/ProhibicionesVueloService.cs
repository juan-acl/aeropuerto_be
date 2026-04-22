using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ProhibicionesVueloService : IProhibicionesVueloService
    {
        private readonly DBContext _context;
        public ProhibicionesVueloService(DBContext context) => _context = context;

        public async Task<List<ProhibicionesVueloModel>> ListarTodo()
        {
            try { return await _context.ProhibicionesVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ProhibicionesVueloModel: {ex.Message}"); return new List<ProhibicionesVueloModel>(); }
        }

        public async Task<ProhibicionesVueloModel?> ObtenerPorId(int id)
        {
            try { return await _context.ProhibicionesVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ProhibicionesVueloModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ProhibicionesVueloModel m)
        {
            try
            {
                string sql = "BEGIN pkg_prohibiciones_vuelo.insert_prohibicion(:p_id_pasajero, :p_fecha_prohibicion, :p_fecha_inicio, :p_fecha_fin, :p_motivo, :p_id_incidente, :p_autoridad_emite, :p_activa); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_fecha_prohibicion", (object?)m.FechaProhibicion ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", m.FechaInicio),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_motivo", (object?)m.Motivo ?? DBNull.Value),
                new OracleParameter("p_id_incidente", (object?)m.IdIncidente ?? DBNull.Value),
                new OracleParameter("p_autoridad_emite", (object?)m.AutoridadEmite ?? DBNull.Value),
                new OracleParameter("p_activa", m.Activa)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ProhibicionesVueloModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, ProhibicionesVueloModel m)
        {
            try
            {
                string sql = "BEGIN pkg_prohibiciones_vuelo.update_prohibicion(:p_id_prohibicion, :p_id_pasajero, :p_fecha_prohibicion, :p_fecha_inicio, :p_fecha_fin, :p_motivo, :p_id_incidente, :p_autoridad_emite, :p_activa); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_prohibicion", id),
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_fecha_prohibicion", (object?)m.FechaProhibicion ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", m.FechaInicio),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_motivo", (object?)m.Motivo ?? DBNull.Value),
                new OracleParameter("p_id_incidente", (object?)m.IdIncidente ?? DBNull.Value),
                new OracleParameter("p_autoridad_emite", (object?)m.AutoridadEmite ?? DBNull.Value),
                new OracleParameter("p_activa", m.Activa)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ProhibicionesVueloModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_prohibiciones_vuelo.delete_prohibicion(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ProhibicionesVueloModel: {ex.Message}"); return false; }
        }
    }
}
