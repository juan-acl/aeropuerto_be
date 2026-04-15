using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class SurtidorCombustibleService : ISurtidorCombustibleService
    {
        private readonly DBContext _context;

        public SurtidorCombustibleService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(SurtidoresCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_codigo_surtidor", (object?)m.CodigoSurtidor ?? DBNull.Value),
                new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                new OracleParameter("p_velocidad_carga_litros_hora", (object?)m.VelocidadCargaLitrosHora ?? DBNull.Value),
                new OracleParameter("p_disponible", (object?)m.Disponible ?? DBNull.Value),
                new OracleParameter("p_fecha_ultimo_mantenimiento", (object?)m.FechaUltimoMantenimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_proximo_mantenimiento", (object?)m.FechaProximoMantenimiento ?? DBNull.Value),
                new OracleParameter("p_operativo", (object?)m.Operativo ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_surtidores_combustible.insert_surtidorcombustible(:p_codigo_surtidor, :p_ubicacion, :p_tipo_combustible, :p_velocidad_carga_litros_hora, :p_disponible, :p_fecha_ultimo_mantenimiento, :p_fecha_proximo_mantenimiento, :p_operativo, :p_observaciones); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, SurtidoresCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_surtidorcombustible", (object?)m.IdSurtidor ?? DBNull.Value),
                new OracleParameter("p_codigo_surtidor", (object?)m.CodigoSurtidor ?? DBNull.Value),
                new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                new OracleParameter("p_tipo_combustible", (object?)m.TipoCombustible ?? DBNull.Value),
                new OracleParameter("p_velocidad_carga_litros_hora", (object?)m.VelocidadCargaLitrosHora ?? DBNull.Value),
                new OracleParameter("p_disponible", (object?)m.Disponible ?? DBNull.Value),
                new OracleParameter("p_fecha_ultimo_mantenimiento", (object?)m.FechaUltimoMantenimiento ?? DBNull.Value),
                new OracleParameter("p_fecha_proximo_mantenimiento", (object?)m.FechaProximoMantenimiento ?? DBNull.Value),
                new OracleParameter("p_operativo", (object?)m.Operativo ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_surtidores_combustible.update_surtidorcombustible(:p_id_surtidorcombustible, :p_codigo_surtidor, :p_ubicacion, :p_tipo_combustible, :p_velocidad_carga_litros_hora, :p_disponible, :p_fecha_ultimo_mantenimiento, :p_fecha_proximo_mantenimiento, :p_operativo, :p_observaciones); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_surtidores_combustible.delete_surtidorcombustible(:p_id_surtidorcombustible); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_surtidorcombustible", id));
            return true;
        }

        public async Task<List<SurtidoresCombustible>> ListarTodo()
        {
            return await _context.Set<SurtidoresCombustible>().ToListAsync();
        }

        public async Task<SurtidoresCombustible?> ObtenerPorId(int id) => await _context.Set<SurtidoresCombustible>().FindAsync(id);
    }
}
