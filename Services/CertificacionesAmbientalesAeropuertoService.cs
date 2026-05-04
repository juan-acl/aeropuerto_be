using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CertificacionesAmbientalesAeropuertoService : ICertificacionesAmbientalesAeropuertoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CertificacionesAmbientalesAeropuertoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CertificacionesAmbientalesAeropuerto>> ListarTodo()
        {
            try { return await _replica.CertificacionesAmbientales.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CertificacionesAmbientalesAeropuerto: {ex.Message}"); return new List<CertificacionesAmbientalesAeropuerto>(); }
        }

        public async Task<CertificacionesAmbientalesAeropuerto ?> ObtenerPorId(int id)
        {
            try { return await _replica.CertificacionesAmbientales.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CertificacionesAmbientalesAeropuerto: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CertificacionesAmbientalesAeropuerto m)
        {
            try
            {
                string sql = "BEGIN pkg_certificaciones_ambientales.insert_certificacion(:p_codigo_certificacion, :p_nombre_certificacion, :p_entidad_certificadora, :p_fecha_obtencion, :p_fecha_vencimiento, :p_nivel_certificacion, :p_alcance, :p_documento_certificado, :p_activa, :p_responsable_seguimiento, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_certificacion", (object?)m.CodigoCertificacion ?? DBNull.Value),
                    new OracleParameter("p_nombre_certificacion", (object?)m.NombreCertificacion ?? DBNull.Value),
                    new OracleParameter("p_entidad_certificadora", (object?)m.EntidadCertificadora ?? DBNull.Value),
                    new OracleParameter("p_fecha_obtencion", m.FechaObtencion),
                    new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                    new OracleParameter("p_nivel_certificacion", (object?)m.NivelCertificacion ?? DBNull.Value),
                    new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                    new OracleParameter("p_documento_certificado", (object?)m.DocumentoCertificado ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                    new OracleParameter("p_responsable_seguimiento", (object?)m.ResponsableSeguimiento ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar CertificacionesAmbientalesAeropuerto: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, CertificacionesAmbientalesAeropuerto m)
        {
            try
            {
                string sql = "BEGIN pkg_certificaciones_ambientales.update_certificacion(:p_id_certificacion_ambiental, :p_codigo_certificacion, :p_nombre_certificacion, :p_entidad_certificadora, :p_fecha_obtencion, :p_fecha_vencimiento, :p_nivel_certificacion, :p_alcance, :p_documento_certificado, :p_activa, :p_responsable_seguimiento, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_certificacion_ambiental", id),
                    new OracleParameter("p_codigo_certificacion", (object?)m.CodigoCertificacion ?? DBNull.Value),
                    new OracleParameter("p_nombre_certificacion", (object?)m.NombreCertificacion ?? DBNull.Value),
                    new OracleParameter("p_entidad_certificadora", (object?)m.EntidadCertificadora ?? DBNull.Value),
                    new OracleParameter("p_fecha_obtencion", m.FechaObtencion),
                    new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                    new OracleParameter("p_nivel_certificacion", (object?)m.NivelCertificacion ?? DBNull.Value),
                    new OracleParameter("p_alcance", (object?)m.Alcance ?? DBNull.Value),
                    new OracleParameter("p_documento_certificado", (object?)m.DocumentoCertificado ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                    new OracleParameter("p_responsable_seguimiento", (object?)m.ResponsableSeguimiento ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar CertificacionesAmbientalesAeropuerto: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_certificaciones_ambientales.delete_certificacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar CertificacionesAmbientalesAeropuerto: {ex.Message}"); throw; }
        }
    }
}
