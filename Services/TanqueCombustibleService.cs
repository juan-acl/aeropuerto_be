using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TanqueCombustibleService : ITanqueCombustible
    {
        private readonly DBContext _context;

        public TanqueCombustibleService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(TanquesCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_codigo_tanque", (object?)m.CodigoTanque ?? DBNull.Value),
                new OracleParameter("p_nombre_tanque", (object?)m.NombreTanque ?? DBNull.Value),
                new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                new OracleParameter("p_capacidad_litros", (object?)m.CapacidadLitros ?? DBNull.Value),
                new OracleParameter("p_nivel_actual_litros", (object?)m.NivelActualLitros ?? DBNull.Value),
                new OracleParameter("p_porcentaje_llenado", (object?)m.PorcentajeLlenado ?? DBNull.Value),
                new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                new OracleParameter("p_fecha_ultima_inspeccion", (object?)m.FechaUltimaInspeccion ?? DBNull.Value),
                new OracleParameter("p_fecha_ultima_calibracion", (object?)m.FechaUltimaCalibracion ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_tanques_combustible.insert_tanquecombustible(:p_codigo_tanque, :p_nombre_tanque, :p_tipo_combustible, :p_capacidad_litros, :p_nivel_actual_litros, :p_porcentaje_llenado, :p_ubicacion, :p_fecha_ultima_inspeccion, :p_fecha_ultima_calibracion, :p_activo); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, TanquesCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_tanquecombustible", (object?)m.IdTanque ?? DBNull.Value),
                new OracleParameter("p_codigo_tanque", (object?)m.CodigoTanque ?? DBNull.Value),
                new OracleParameter("p_nombre_tanque", (object?)m.NombreTanque ?? DBNull.Value),
                new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                new OracleParameter("p_capacidad_litros", (object?)m.CapacidadLitros ?? DBNull.Value),
                new OracleParameter("p_nivel_actual_litros", (object?)m.NivelActualLitros ?? DBNull.Value),
                new OracleParameter("p_porcentaje_llenado", (object?)m.PorcentajeLlenado ?? DBNull.Value),
                new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                new OracleParameter("p_fecha_ultima_inspeccion", (object?)m.FechaUltimaInspeccion ?? DBNull.Value),
                new OracleParameter("p_fecha_ultima_calibracion", (object?)m.FechaUltimaCalibracion ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_tanques_combustible.update_tanquecombustible(:p_id_tanquecombustible, :p_codigo_tanque, :p_nombre_tanque, :p_tipo_combustible, :p_capacidad_litros, :p_nivel_actual_litros, :p_porcentaje_llenado, :p_ubicacion, :p_fecha_ultima_inspeccion, :p_fecha_ultima_calibracion, :p_activo); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_tanques_combustible.delete_tanquecombustible(:p_id_tanquecombustible); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_tanquecombustible", id));
            return true;
        }

        public async Task<List<TanquesCombustible>> ListarTodo()
        {
            return await _context.Set<TanquesCombustible>().ToListAsync();
        }

        public async Task<TanquesCombustible?> ObtenerPorId(int id) => await _context.Set<TanquesCombustible>().FindAsync(id);
    }
}
