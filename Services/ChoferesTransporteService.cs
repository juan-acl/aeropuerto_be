using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ChoferesTransporteService : IChoferesTransporteService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ChoferesTransporteService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ChoferesTransporte>> ListarTodo()
        {
            try { return await _replica.ChoferesTransporte.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ChoferesTransporte: {ex.Message}"); return new List<ChoferesTransporte>(); }
        }

        public async Task<ChoferesTransporte ?> ObtenerPorId(int id)
        {
            try { return await _replica.ChoferesTransporte.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ChoferesTransporte: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ChoferesTransporte m)
        {
            try
            {
                string sql = "BEGIN pkg_choferes_transporte.insert_chofer(:p_nombres, :p_apellidos, :p_tipo_documento, :p_numero_documento, :p_licencia_conducir, :p_categoria_licencia, :p_fecha_vencimiento_licencia, :p_telefono, :p_email, :p_fecha_contratacion, :p_empresa_contratante, :p_certificaciones, :p_idiomas, :p_disponible, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nombres", (object?)m.Nombres ?? DBNull.Value),
                    new OracleParameter("p_apellidos", (object?)m.Apellidos ?? DBNull.Value),
                    new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                    new OracleParameter("p_numero_documento", (object?)m.NumeroDocumento ?? DBNull.Value),
                    new OracleParameter("p_licencia_conducir", (object?)m.LicenciaConducir ?? DBNull.Value),
                    new OracleParameter("p_categoria_licencia", (object?)m.CategoriaLicencia ?? DBNull.Value),
                    new OracleParameter("p_fecha_vencimiento_licencia", m.FechaVencimientoLicencia),
                    new OracleParameter("p_telefono", (object?)m.Telefono ?? DBNull.Value),
                    new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                    new OracleParameter("p_fecha_contratacion", (object?)m.FechaContratacion ?? DBNull.Value),
                    new OracleParameter("p_empresa_contratante", (object?)m.EmpresaContratante ?? DBNull.Value),
                    new OracleParameter("p_certificaciones", (object?)m.Certificaciones ?? DBNull.Value),
                    new OracleParameter("p_idiomas", (object?)m.Idiomas ?? DBNull.Value),
                    new OracleParameter("p_disponible", (object?)m.Disponible ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ChoferesTransporte: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ChoferesTransporte m)
        {
            try
            {
                string sql = "BEGIN pkg_choferes_transporte.update_chofer(:p_id_chofer_transporte, :p_nombres, :p_apellidos, :p_tipo_documento, :p_numero_documento, :p_licencia_conducir, :p_categoria_licencia, :p_fecha_vencimiento_licencia, :p_telefono, :p_email, :p_fecha_contratacion, :p_empresa_contratante, :p_certificaciones, :p_idiomas, :p_disponible, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_chofer_transporte", id),
                    new OracleParameter("p_nombres", (object?)m.Nombres ?? DBNull.Value),
                    new OracleParameter("p_apellidos", (object?)m.Apellidos ?? DBNull.Value),
                    new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                    new OracleParameter("p_numero_documento", (object?)m.NumeroDocumento ?? DBNull.Value),
                    new OracleParameter("p_licencia_conducir", (object?)m.LicenciaConducir ?? DBNull.Value),
                    new OracleParameter("p_categoria_licencia", (object?)m.CategoriaLicencia ?? DBNull.Value),
                    new OracleParameter("p_fecha_vencimiento_licencia", m.FechaVencimientoLicencia),
                    new OracleParameter("p_telefono", (object?)m.Telefono ?? DBNull.Value),
                    new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                    new OracleParameter("p_fecha_contratacion", (object?)m.FechaContratacion ?? DBNull.Value),
                    new OracleParameter("p_empresa_contratante", (object?)m.EmpresaContratante ?? DBNull.Value),
                    new OracleParameter("p_certificaciones", (object?)m.Certificaciones ?? DBNull.Value),
                    new OracleParameter("p_idiomas", (object?)m.Idiomas ?? DBNull.Value),
                    new OracleParameter("p_disponible", (object?)m.Disponible ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ChoferesTransporte: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_choferes_transporte.delete_chofer(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ChoferesTransporte: {ex.Message}"); throw; }
        }
    }
}
