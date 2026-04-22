using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class MantenimientoAvionService : IMantenimientoAvionService
    {
        private readonly DBContext _context;
        public MantenimientoAvionService(DBContext context) => _context = context;

        public async Task<List<MantenimientoAvionModel>> ListarTodo()
        {
            try { return await _context.MantenimientosAviones.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo MantenimientoAvionModel: {ex.Message}"); return new List<MantenimientoAvionModel>(); }
        }

        public async Task<MantenimientoAvionModel?> ObtenerPorId(int id)
        {
            try { return await _context.MantenimientosAviones.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId MantenimientoAvionModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(MantenimientoAvionModel m)
        {
            try
            {
                string sql = "BEGIN pkg_mantenimiento_aviones.insert_mantenimiento(:p_matricula_avion, :p_id_modelo, :p_fecha_mantenimiento, :p_tipo_mantenimiento, :p_descripcion, :p_horas_vuelo_actuales, :p_proximo_mantenimiento, :p_costo, :p_taller, :p_tecnico_responsable); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_matricula_avion", (object?)m.MatriculaAvion ?? DBNull.Value),
                new OracleParameter("p_id_modelo", (object?)m.IdModelo ?? DBNull.Value),
                new OracleParameter("p_fecha_mantenimiento", (object?)m.FechaMantenimiento ?? DBNull.Value),
                new OracleParameter("p_tipo_mantenimiento", (object?)m.TipoMantenimiento ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_horas_vuelo_actuales", (object?)m.HorasVueloActuales ?? DBNull.Value),
                new OracleParameter("p_proximo_mantenimiento", (object?)m.ProximoMantenimiento ?? DBNull.Value),
                new OracleParameter("p_costo", (object?)m.Costo ?? DBNull.Value),
                new OracleParameter("p_taller", (object?)m.Taller ?? DBNull.Value),
                new OracleParameter("p_tecnico_responsable", (object?)m.TecnicoResponsable ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar MantenimientoAvionModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, MantenimientoAvionModel m)
        {
            try
            {
                string sql = "BEGIN pkg_mantenimiento_aviones.update_mantenimiento(:p_id_mantenimiento, :p_matricula_avion, :p_id_modelo, :p_fecha_mantenimiento, :p_tipo_mantenimiento, :p_descripcion, :p_horas_vuelo_actuales, :p_proximo_mantenimiento, :p_costo, :p_taller, :p_tecnico_responsable); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_mantenimiento", id),
                new OracleParameter("p_matricula_avion", (object?)m.MatriculaAvion ?? DBNull.Value),
                new OracleParameter("p_id_modelo", (object?)m.IdModelo ?? DBNull.Value),
                new OracleParameter("p_fecha_mantenimiento", (object?)m.FechaMantenimiento ?? DBNull.Value),
                new OracleParameter("p_tipo_mantenimiento", (object?)m.TipoMantenimiento ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_horas_vuelo_actuales", (object?)m.HorasVueloActuales ?? DBNull.Value),
                new OracleParameter("p_proximo_mantenimiento", (object?)m.ProximoMantenimiento ?? DBNull.Value),
                new OracleParameter("p_costo", (object?)m.Costo ?? DBNull.Value),
                new OracleParameter("p_taller", (object?)m.Taller ?? DBNull.Value),
                new OracleParameter("p_tecnico_responsable", (object?)m.TecnicoResponsable ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar MantenimientoAvionModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_mantenimiento_aviones.delete_mantenimiento(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar MantenimientoAvionModel: {ex.Message}"); return false; }
        }
    }
}
