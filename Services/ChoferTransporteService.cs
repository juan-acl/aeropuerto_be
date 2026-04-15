using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ChoferTransporteService : IChoferTransporteService
    {
        private readonly DBContext _context;
        public ChoferTransporteService(DBContext context) => _context = context;

        public async Task<bool> Insertar(ChoferesTransporte m)
        {
            var p = new[] {
                new OracleParameter("p_nombres", (object?)m.Nombres ?? DBNull.Value),
                new OracleParameter("p_apellidos", (object?)m.Apellidos ?? DBNull.Value),
                new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_numero_documento", (object?)m.NumeroDocumento ?? DBNull.Value),
                new OracleParameter("p_licencia_conducir", (object?)m.LicenciaConducir ?? DBNull.Value),
                new OracleParameter("p_categoria_licencia", (object?)m.CategoriaLicencia ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento_licencia", (object?)m.FechaVencimientoLicencia ?? DBNull.Value),
                new OracleParameter("p_telefono", (object?)m.Telefono ?? DBNull.Value),
                new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                new OracleParameter("p_fecha_contratacion", (object?)m.FechaContratacion ?? DBNull.Value),
                new OracleParameter("p_empresa_contratante", (object?)m.EmpresaContratante ?? DBNull.Value),
                new OracleParameter("p_certificaciones", (object?)m.Certificaciones ?? DBNull.Value),
                new OracleParameter("p_idiomas", (object?)m.Idiomas ?? DBNull.Value),
                new OracleParameter("p_disponible", (object?)m.Disponible ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_choferes_transporte.insert_chofer(:p_nombres, :p_apellidos, :p_tipo_documento, :p_numero_documento, :p_licencia_conducir, :p_categoria_licencia, :p_fecha_vencimiento_licencia, :p_telefono, :p_email, :p_fecha_contratacion, :p_empresa_contratante, :p_certificaciones, :p_idiomas, :p_disponible, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, ChoferesTransporte m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_chofer_transporte", m.IdChoferTransporte)
            };
            p.AddRange(new[] {
                new OracleParameter("p_nombres", (object?)m.Nombres ?? DBNull.Value),
                new OracleParameter("p_apellidos", (object?)m.Apellidos ?? DBNull.Value),
                new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_numero_documento", (object?)m.NumeroDocumento ?? DBNull.Value),
                new OracleParameter("p_licencia_conducir", (object?)m.LicenciaConducir ?? DBNull.Value),
                new OracleParameter("p_categoria_licencia", (object?)m.CategoriaLicencia ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento_licencia", (object?)m.FechaVencimientoLicencia ?? DBNull.Value),
                new OracleParameter("p_telefono", (object?)m.Telefono ?? DBNull.Value),
                new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                new OracleParameter("p_fecha_contratacion", (object?)m.FechaContratacion ?? DBNull.Value),
                new OracleParameter("p_empresa_contratante", (object?)m.EmpresaContratante ?? DBNull.Value),
                new OracleParameter("p_certificaciones", (object?)m.Certificaciones ?? DBNull.Value),
                new OracleParameter("p_idiomas", (object?)m.Idiomas ?? DBNull.Value),
                new OracleParameter("p_disponible", (object?)m.Disponible ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_choferes_transporte.update_chofer(:p_id_chofer_transporte, :p_nombres, :p_apellidos, :p_tipo_documento, :p_numero_documento, :p_licencia_conducir, :p_categoria_licencia, :p_fecha_vencimiento_licencia, :p_telefono, :p_email, :p_fecha_contratacion, :p_empresa_contratante, :p_certificaciones, :p_idiomas, :p_disponible, :p_activo); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_choferes_transporte.delete_chofer(:p_id_chofer_transporte); END;", 
                new OracleParameter("p_id_chofer_transporte", id));
            return true;
        }

        public async Task<List<ChoferesTransporte>> ListarTodo() => await _context.Set<ChoferesTransporte>().ToListAsync();

        public async Task<ChoferesTransporte?> ObtenerPorId(int id) => await _context.Set<ChoferesTransporte>().FindAsync(id);
    }
}
