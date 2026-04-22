using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ProgramaCompensacionService : IProgramaCompensacionService
    {
        private readonly DBContext _context;
        public ProgramaCompensacionService(DBContext context) => _context = context;

        public async Task<List<ProgramasCompensacionAmbiental>> ListarTodo()
        {
            try { return await _context.ProgramasCompensacionAmbiental.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ProgramasCompensacionAmbiental: {ex.Message}"); return new List<ProgramasCompensacionAmbiental>(); }
        }

        public async Task<ProgramasCompensacionAmbiental?> ObtenerPorId(int id)
        {
            try { return await _context.ProgramasCompensacionAmbiental.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ProgramasCompensacionAmbiental: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ProgramasCompensacionAmbiental m)
        {
            try
            {
                string sql = "BEGIN pkg_programas_compensacion.insert_programa(:p_nombre_programa, :p_descripcion, :p_tipo_programa, :p_fecha_inicio, :p_fecha_fin, :p_inversion_total, :p_moneda, :p_co2_compensado_estimado_kg, :p_entidad_ejecutora, :p_activo, :p_contacto_responsable); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_nombre_programa", (object?)m.NombrePrograma ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_tipo_programa", (object?)m.TipoPrograma ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_inversion_total", (object?)m.InversionTotal ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_co2_compensado_estimado_kg", (object?)m.Co2CompensadoEstimadoKg ?? DBNull.Value),
                new OracleParameter("p_entidad_ejecutora", (object?)m.EntidadEjecutora ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
                new OracleParameter("p_contacto_responsable", (object?)m.ContactoResponsable ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ProgramasCompensacionAmbiental: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, ProgramasCompensacionAmbiental m)
        {
            try
            {
                string sql = "BEGIN pkg_programas_compensacion.update_programa(:p_id_programa_compensacion, :p_nombre_programa, :p_descripcion, :p_tipo_programa, :p_fecha_inicio, :p_fecha_fin, :p_inversion_total, :p_moneda, :p_co2_compensado_estimado_kg, :p_entidad_ejecutora, :p_activo, :p_contacto_responsable); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_programa_compensacion", id),
                new OracleParameter("p_nombre_programa", (object?)m.NombrePrograma ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_tipo_programa", (object?)m.TipoPrograma ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_inversion_total", (object?)m.InversionTotal ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_co2_compensado_estimado_kg", (object?)m.Co2CompensadoEstimadoKg ?? DBNull.Value),
                new OracleParameter("p_entidad_ejecutora", (object?)m.EntidadEjecutora ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
                new OracleParameter("p_contacto_responsable", (object?)m.ContactoResponsable ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ProgramasCompensacionAmbiental: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_programas_compensacion.delete_programa(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ProgramasCompensacionAmbiental: {ex.Message}"); return false; }
        }
    }
}
