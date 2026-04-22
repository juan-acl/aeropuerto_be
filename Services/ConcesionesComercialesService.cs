using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ConcesionesComercialesService : IConcesionesComercialesService
    {
        private readonly DBContext _context;
        public ConcesionesComercialesService(DBContext context) => _context = context;

        public async Task<List<ConcesionesComercialesModel>> ListarTodo()
        {
            try { return await _context.ConcesionesComerciales.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ConcesionesComercialesModel: {ex.Message}"); return new List<ConcesionesComercialesModel>(); }
        }

        public async Task<ConcesionesComercialesModel?> ObtenerPorId(int id)
        {
            try { return await _context.ConcesionesComerciales.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ConcesionesComercialesModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ConcesionesComercialesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_concesiones_comerciales.insert_concesion(:p_codigo_aeropuerto, :p_nombre_comercial, :p_tipo_negocio, :p_empresa, :p_ruc, :p_representante, :p_telefono_contacto, :p_email_contacto, :p_fecha_inicio_concesion, :p_fecha_fin_concesion, :p_canon_mensual, :p_ubicacion_terminal, :p_local_numero, :p_area_m2, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_nombre_comercial", (object?)m.NombreComercial ?? DBNull.Value),
                new OracleParameter("p_tipo_negocio", (object?)m.TipoNegocio ?? DBNull.Value),
                new OracleParameter("p_empresa", (object?)m.Empresa ?? DBNull.Value),
                new OracleParameter("p_ruc", (object?)m.Ruc ?? DBNull.Value),
                new OracleParameter("p_representante", (object?)m.Representante ?? DBNull.Value),
                new OracleParameter("p_telefono_contacto", (object?)m.TelefonoContacto ?? DBNull.Value),
                new OracleParameter("p_email_contacto", (object?)m.EmailContacto ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_concesion", (object?)m.FechaInicioConcesion ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_concesion", (object?)m.FechaFinConcesion ?? DBNull.Value),
                new OracleParameter("p_canon_mensual", (object?)m.CanonMensual ?? DBNull.Value),
                new OracleParameter("p_ubicacion_terminal", (object?)m.UbicacionTerminal ?? DBNull.Value),
                new OracleParameter("p_local_numero", (object?)m.LocalNumero ?? DBNull.Value),
                new OracleParameter("p_area_m2", (object?)m.AreaM2 ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ConcesionesComercialesModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, ConcesionesComercialesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_concesiones_comerciales.update_concesion(:p_id_concesion, :p_codigo_aeropuerto, :p_nombre_comercial, :p_tipo_negocio, :p_empresa, :p_ruc, :p_representante, :p_telefono_contacto, :p_email_contacto, :p_fecha_inicio_concesion, :p_fecha_fin_concesion, :p_canon_mensual, :p_ubicacion_terminal, :p_local_numero, :p_area_m2, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_concesion", id),
                new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_nombre_comercial", (object?)m.NombreComercial ?? DBNull.Value),
                new OracleParameter("p_tipo_negocio", (object?)m.TipoNegocio ?? DBNull.Value),
                new OracleParameter("p_empresa", (object?)m.Empresa ?? DBNull.Value),
                new OracleParameter("p_ruc", (object?)m.Ruc ?? DBNull.Value),
                new OracleParameter("p_representante", (object?)m.Representante ?? DBNull.Value),
                new OracleParameter("p_telefono_contacto", (object?)m.TelefonoContacto ?? DBNull.Value),
                new OracleParameter("p_email_contacto", (object?)m.EmailContacto ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_concesion", (object?)m.FechaInicioConcesion ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_concesion", (object?)m.FechaFinConcesion ?? DBNull.Value),
                new OracleParameter("p_canon_mensual", (object?)m.CanonMensual ?? DBNull.Value),
                new OracleParameter("p_ubicacion_terminal", (object?)m.UbicacionTerminal ?? DBNull.Value),
                new OracleParameter("p_local_numero", (object?)m.LocalNumero ?? DBNull.Value),
                new OracleParameter("p_area_m2", (object?)m.AreaM2 ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ConcesionesComercialesModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_concesiones_comerciales.delete_concesion(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ConcesionesComercialesModel: {ex.Message}"); return false; }
        }
    }
}
