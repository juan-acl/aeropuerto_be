using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class GestionResiduosService : IGestionResiduosService
    {
        private readonly DBContext _context;

        public GestionResiduosService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(GestionResiduos m)
        {
            var parametros = new[] {
                new OracleParameter("p_fecha_recoleccion", (object?)m.FechaRecoleccion ?? DBNull.Value),
                new OracleParameter("p_tipo_residuo", (object?)m.TipoResiduo ?? DBNull.Value),
                new OracleParameter("p_cantidad_kg", (object?)m.CantidadKg ?? DBNull.Value),
                new OracleParameter("p_origen", (object?)m.Origen ?? DBNull.Value),
                new OracleParameter("p_empresa_recolectora", (object?)m.EmpresaRecolectora ?? DBNull.Value),
                new OracleParameter("p_tratamiento", (object?)m.Tratamiento ?? DBNull.Value),
                new OracleParameter("p_certificado_tratamiento", (object?)m.CertificadoTratamiento ?? DBNull.Value),
                new OracleParameter("p_costo_tratamiento", (object?)m.CostoTratamiento ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_gestion_residuos.insert_residuo(:p_fecha_recoleccion, :p_tipo_residuo, :p_cantidad_kg, :p_origen, :p_empresa_recolectora, :p_tratamiento, :p_certificado_tratamiento, :p_costo_tratamiento, :p_observaciones); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, GestionResiduos m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_residuo", id),
                new OracleParameter("p_fecha_recoleccion", (object?)m.FechaRecoleccion ?? DBNull.Value),
                new OracleParameter("p_tipo_residuo", (object?)m.TipoResiduo ?? DBNull.Value),
                new OracleParameter("p_cantidad_kg", (object?)m.CantidadKg ?? DBNull.Value),
                new OracleParameter("p_origen", (object?)m.Origen ?? DBNull.Value),
                new OracleParameter("p_empresa_recolectora", (object?)m.EmpresaRecolectora ?? DBNull.Value),
                new OracleParameter("p_tratamiento", (object?)m.Tratamiento ?? DBNull.Value),
                new OracleParameter("p_certificado_tratamiento", (object?)m.CertificadoTratamiento ?? DBNull.Value),
                new OracleParameter("p_costo_tratamiento", (object?)m.CostoTratamiento ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_gestion_residuos.update_residuo(:p_id_residuo, :p_fecha_recoleccion, :p_tipo_residuo, :p_cantidad_kg, :p_origen, :p_empresa_recolectora, :p_tratamiento, :p_certificado_tratamiento, :p_costo_tratamiento, :p_observaciones); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_gestion_residuos.delete_residuo(:p_id_residuo); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_residuo", id));
            return true;
        }

        public async Task<List<GestionResiduos>> ListarTodo()
        {
            return await _context.Set<GestionResiduos>().ToListAsync();
        }

        public async Task<GestionResiduos?> ObtenerPorId(int id) => await _context.Set<GestionResiduos>().FindAsync(id);
    }
}
