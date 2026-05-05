using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CertificacionesInternacionalesService : ICertificacionesInternacionalesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CertificacionesInternacionalesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CertificacionesInternacionales>> ListarTodo()
        {
            try { return await _replica.CertificacionesInternacionales.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CertificacionesInternacionales: {ex.Message}"); return new List<CertificacionesInternacionales>(); }
        }

        public async Task<CertificacionesInternacionales ?> ObtenerPorId(int id)
        {
            try { return await _replica.CertificacionesInternacionales.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CertificacionesInternacionales: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CertificacionesInternacionales m)
        {
            try
            {
                string sql = "BEGIN pkg_certificaciones_internacionales.insert_certificacion(:p_id_estandar, :p_nombre_certificacion, :p_organismo_certificador, :p_fecha_emision, :p_fecha_vencimiento, :p_alcance_certificacion, :p_numero_certificado, :p_documento_certificado, :p_activa, :p_responsable_seguimiento); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_estandar", (object?)m.IdEstandar ?? DBNull.Value),
                    new OracleParameter("p_nombre_certificacion", (object?)m.NombreCertificacion ?? DBNull.Value),
                    new OracleParameter("p_organismo_certificador", (object?)m.OrganismoCertificador ?? DBNull.Value),
                    new OracleParameter("p_fecha_emision", m.FechaEmision),
                    new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                    new OracleParameter("p_alcance_certificacion", (object?)m.AlcanceCertificacion ?? DBNull.Value),
                    new OracleParameter("p_numero_certificado", (object?)m.NumeroCertificado ?? DBNull.Value),
                    new OracleParameter("p_documento_certificado", (object?)m.DocumentoCertificado ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                    new OracleParameter("p_responsable_seguimiento", (object?)m.ResponsableSeguimiento ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar CertificacionesInternacionales: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, CertificacionesInternacionales m)
        {
            try
            {
                string sql = "BEGIN pkg_certificaciones_internacionales.update_certificacion(:p_id_certificacion_internacional, :p_id_estandar, :p_nombre_certificacion, :p_organismo_certificador, :p_fecha_emision, :p_fecha_vencimiento, :p_alcance_certificacion, :p_numero_certificado, :p_documento_certificado, :p_activa, :p_responsable_seguimiento); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_certificacion_internacional", id),
                    new OracleParameter("p_id_estandar", (object?)m.IdEstandar ?? DBNull.Value),
                    new OracleParameter("p_nombre_certificacion", (object?)m.NombreCertificacion ?? DBNull.Value),
                    new OracleParameter("p_organismo_certificador", (object?)m.OrganismoCertificador ?? DBNull.Value),
                    new OracleParameter("p_fecha_emision", m.FechaEmision),
                    new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                    new OracleParameter("p_alcance_certificacion", (object?)m.AlcanceCertificacion ?? DBNull.Value),
                    new OracleParameter("p_numero_certificado", (object?)m.NumeroCertificado ?? DBNull.Value),
                    new OracleParameter("p_documento_certificado", (object?)m.DocumentoCertificado ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                    new OracleParameter("p_responsable_seguimiento", (object?)m.ResponsableSeguimiento ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar CertificacionesInternacionales: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_certificaciones_internacionales.delete_certificacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar CertificacionesInternacionales: {ex.Message}"); throw; }
        }
    }
}
