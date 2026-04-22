using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class LicenciaOperativaService : ILicenciaOperativaService
    {
        private readonly DBContext _context;
        public LicenciaOperativaService(DBContext context) => _context = context;

        public async Task<List<LicenciasOperativasAeropuerto>> ListarTodo()
        {
            try { return await _context.LicenciasOperativas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo LicenciasOperativasAeropuerto: {ex.Message}"); return new List<LicenciasOperativasAeropuerto>(); }
        }

        public async Task<LicenciasOperativasAeropuerto?> ObtenerPorId(int id)
        {
            try { return await _context.LicenciasOperativas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId LicenciasOperativasAeropuerto: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(LicenciasOperativasAeropuerto m)
        {
            try
            {
                string sql = "BEGIN pkg_licencias_operativas.insert_licencia(:p_codigo_licencia, :p_nombre_licencia, :p_tipo_licencia, :p_entidad_otorgante, :p_fecha_emision, :p_fecha_vencimiento, :p_fecha_renovacion, :p_alcance, :p_restricciones, :p_documento_licencia, :p_responsable_seguimiento, :p_renovacion_automatica, :p_activa, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_codigo_licencia", (object?)m.CodigoLicencia ?? DBNull.Value),
                new OracleParameter("p_nombre_licencia", (object?)m.NombreLicencia ?? DBNull.Value),
                new OracleParameter("p_tipo_licencia", (object?)m.TipoLicencia ?? DBNull.Value),
                new OracleParameter("p_entidad_otorgante", (object?)m.EntidadOtorgante ?? DBNull.Value),
                new OracleParameter("p_fecha_emision", m.FechaEmision),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_renovacion", (object?)m.FechaRenovacion ?? DBNull.Value),
                new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                new OracleParameter("p_restricciones", (object?)m.Restricciones ?? DBNull.Value),
                new OracleParameter("p_documento_licencia", OracleDbType.Blob) { Value = (object?)m.DocumentoLicencia ?? DBNull.Value },
                new OracleParameter("p_responsable_seguimiento", (object?)m.ResponsableSeguimiento ?? DBNull.Value),
                new OracleParameter("p_renovacion_automatica", (object?)m.RenovacionAutomatica ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar LicenciasOperativasAeropuerto: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, LicenciasOperativasAeropuerto m)
        {
            try
            {
                string sql = "BEGIN pkg_licencias_operativas.update_licencia(:p_id_licencia_operativa, :p_codigo_licencia, :p_nombre_licencia, :p_tipo_licencia, :p_entidad_otorgante, :p_fecha_emision, :p_fecha_vencimiento, :p_fecha_renovacion, :p_alcance, :p_restricciones, :p_documento_licencia, :p_responsable_seguimiento, :p_renovacion_automatica, :p_activa, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_licencia_operativa", id),
                new OracleParameter("p_codigo_licencia", (object?)m.CodigoLicencia ?? DBNull.Value),
                new OracleParameter("p_nombre_licencia", (object?)m.NombreLicencia ?? DBNull.Value),
                new OracleParameter("p_tipo_licencia", (object?)m.TipoLicencia ?? DBNull.Value),
                new OracleParameter("p_entidad_otorgante", (object?)m.EntidadOtorgante ?? DBNull.Value),
                new OracleParameter("p_fecha_emision", m.FechaEmision),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_renovacion", (object?)m.FechaRenovacion ?? DBNull.Value),
                new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                new OracleParameter("p_restricciones", (object?)m.Restricciones ?? DBNull.Value),
                new OracleParameter("p_documento_licencia", OracleDbType.Blob) { Value = (object?)m.DocumentoLicencia ?? DBNull.Value },
                new OracleParameter("p_responsable_seguimiento", (object?)m.ResponsableSeguimiento ?? DBNull.Value),
                new OracleParameter("p_renovacion_automatica", (object?)m.RenovacionAutomatica ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar LicenciasOperativasAeropuerto: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_licencias_operativas.delete_licencia(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar LicenciasOperativasAeropuerto: {ex.Message}"); return false; }
        }
    }
}
