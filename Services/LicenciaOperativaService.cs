using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class LicenciaOperativaService : ILicenciaOperativaAeropuertoService
    {
        private readonly DBContext _context;
        public LicenciaOperativaService(DBContext context) => _context = context;

        public async Task<bool> Insertar(LicenciasOperativasAeropuerto m)
        {
            var p = new[] {
                new OracleParameter("p_codigo_licencia", (object?)m.CodigoLicencia ?? DBNull.Value),
                new OracleParameter("p_nombre_licencia", (object?)m.NombreLicencia ?? DBNull.Value),
                new OracleParameter("p_tipo_licencia", (object?)m.TipoLicencia ?? DBNull.Value),
                new OracleParameter("p_entidad_otorgante", (object?)m.EntidadOtorgante ?? DBNull.Value),
                new OracleParameter("p_fecha_emision", (object?)m.FechaEmision ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_renovacion", (object?)m.FechaRenovacion ?? DBNull.Value),
                new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                new OracleParameter("p_restricciones", (object?)m.Restricciones ?? DBNull.Value),
                new OracleParameter("p_documento_licencia", (object?)m.DocumentoLicencia ?? DBNull.Value),
                new OracleParameter("p_responsable_seguimiento", (object?)m.ResponsableSeguimiento ?? DBNull.Value),
                new OracleParameter("p_renovacion_automatica", (object?)m.RenovacionAutomatica ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_licencias_operativas.insert_licencia(:p_codigo_licencia, :p_nombre_licencia, :p_tipo_licencia, :p_entidad_otorgante, :p_fecha_emision, :p_fecha_vencimiento, :p_fecha_renovacion, :p_alcance, :p_restricciones, :p_documento_licencia, :p_responsable_seguimiento, :p_renovacion_automatica, :p_activa, :p_observaciones); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, LicenciasOperativasAeropuerto m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_licencia_operativa", m.IdLicenciaOperativa)
            };
            p.AddRange(new[] {
                new OracleParameter("p_codigo_licencia", (object?)m.CodigoLicencia ?? DBNull.Value),
                new OracleParameter("p_nombre_licencia", (object?)m.NombreLicencia ?? DBNull.Value),
                new OracleParameter("p_tipo_licencia", (object?)m.TipoLicencia ?? DBNull.Value),
                new OracleParameter("p_entidad_otorgante", (object?)m.EntidadOtorgante ?? DBNull.Value),
                new OracleParameter("p_fecha_emision", (object?)m.FechaEmision ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_renovacion", (object?)m.FechaRenovacion ?? DBNull.Value),
                new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                new OracleParameter("p_restricciones", (object?)m.Restricciones ?? DBNull.Value),
                new OracleParameter("p_documento_licencia", (object?)m.DocumentoLicencia ?? DBNull.Value),
                new OracleParameter("p_responsable_seguimiento", (object?)m.ResponsableSeguimiento ?? DBNull.Value),
                new OracleParameter("p_renovacion_automatica", (object?)m.RenovacionAutomatica ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_licencias_operativas.update_licencia(:p_id_licencia_operativa, :p_codigo_licencia, :p_nombre_licencia, :p_tipo_licencia, :p_entidad_otorgante, :p_fecha_emision, :p_fecha_vencimiento, :p_fecha_renovacion, :p_alcance, :p_restricciones, :p_documento_licencia, :p_responsable_seguimiento, :p_renovacion_automatica, :p_activa, :p_observaciones); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_licencias_operativas.delete_licencia(:p_id_licencia_operativa); END;",
                new OracleParameter("p_id_licencia_operativa", id));
            return true;
        }

        public async Task<List<LicenciasOperativasAeropuerto>> ListarTodo() => await _context.Set<LicenciasOperativasAeropuerto>().ToListAsync();

        public async Task<LicenciasOperativasAeropuerto?> ObtenerPorId(int id) => await _context.Set<LicenciasOperativasAeropuerto>().FindAsync(id);
    }
}
