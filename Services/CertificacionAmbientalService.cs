using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CertificacionAmbientalService : ICertificacionesAmbientalesAeropuertoService
    {
        private readonly DBContext _context;

        public CertificacionAmbientalService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(CertificacionesAmbientalesAeropuerto m)
        {
            var parametros = new[] {
                new OracleParameter("p_codigo_certificacion", (object?)m.CodigoCertificacion ?? DBNull.Value),
                new OracleParameter("p_nombre_certificacion", (object?)m.NombreCertificacion ?? DBNull.Value),
                new OracleParameter("p_entidad_certificadora", (object?)m.EntidadCertificadora ?? DBNull.Value),
                new OracleParameter("p_fecha_obtencion", (object?)m.FechaObtencion ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_nivel_certificacion", (object?)m.NivelCertificacion ?? DBNull.Value),
                new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                new OracleParameter("p_documento_certificado", (object?)m.DocumentoCertificado ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                new OracleParameter("p_responsable_seguimiento", (object?)m.ResponsableSeguimiento ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_certificaciones_ambientales.insert_certificacion(:p_codigo_certificacion, :p_nombre_certificacion, :p_entidad_certificadora, :p_fecha_obtencion, :p_fecha_vencimiento, :p_nivel_certificacion, :p_alcance, :p_documento_certificado, :p_activa, :p_responsable_seguimiento, :p_observaciones); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, CertificacionesAmbientalesAeropuerto m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_certificacion_ambiental", id),
                new OracleParameter("p_codigo_certificacion", (object?)m.CodigoCertificacion ?? DBNull.Value),
                new OracleParameter("p_nombre_certificacion", (object?)m.NombreCertificacion ?? DBNull.Value),
                new OracleParameter("p_entidad_certificadora", (object?)m.EntidadCertificadora ?? DBNull.Value),
                new OracleParameter("p_fecha_obtencion", (object?)m.FechaObtencion ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                new OracleParameter("p_nivel_certificacion", (object?)m.NivelCertificacion ?? DBNull.Value),
                new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                new OracleParameter("p_documento_certificado", (object?)m.DocumentoCertificado ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                new OracleParameter("p_responsable_seguimiento", (object?)m.ResponsableSeguimiento ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_certificaciones_ambientales.update_certificacion(:p_id_certificacion_ambiental, :p_codigo_certificacion, :p_nombre_certificacion, :p_entidad_certificadora, :p_fecha_obtencion, :p_fecha_vencimiento, :p_nivel_certificacion, :p_alcance, :p_documento_certificado, :p_activa, :p_responsable_seguimiento, :p_observaciones); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_certificaciones_ambientales.delete_certificacion(:p_id_certificacion_ambiental); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_certificacion_ambiental", id));
            return true;
        }

        public async Task<List<CertificacionesAmbientalesAeropuerto>> ListarTodo()
        {
            return await _context.Set<CertificacionesAmbientalesAeropuerto>().ToListAsync();
        }

        public async Task<CertificacionesAmbientalesAeropuerto?> ObtenerPorId(int id) => await _context.Set<CertificacionesAmbientalesAeropuerto>().FindAsync(id);
    }
}
