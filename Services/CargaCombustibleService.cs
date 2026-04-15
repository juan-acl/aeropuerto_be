using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CargaCombustibleService : ICargaCombustibleService
    {
        private readonly DBContext _context;

        public CargaCombustibleService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(CargasCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_pedido_combustible", (object?)m.IdPedidoCombustible ?? DBNull.Value),
                new OracleParameter("p_id_surtidor", (object?)m.IdSurtidor ?? DBNull.Value),
                new OracleParameter("p_cantidad_real_litros", (object?)m.CantidadRealLitros ?? DBNull.Value),
                new OracleParameter("p_temperatura_combustible", (object?)m.TemperaturaCombustible ?? DBNull.Value),
                new OracleParameter("p_densidad_combustible", (object?)m.DensidadCombustible ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_carga", (object?)m.FechaInicioCarga ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_carga", (object?)m.FechaFinCarga ?? DBNull.Value),
                new OracleParameter("p_duracion_minutos", (object?)m.DuracionMinutos ?? DBNull.Value),
                new OracleParameter("p_operador_carga", (object?)m.OperadorCarga ?? DBNull.Value),
                new OracleParameter("p_verificador", (object?)m.Verificador ?? DBNull.Value),
                new OracleParameter("p_lectura_inicial_contador", (object?)m.LecturaInicialContador ?? DBNull.Value),
                new OracleParameter("p_lectura_final_contador", (object?)m.LecturaFinalContador ?? DBNull.Value),
                new OracleParameter("p_incidencia_tecnica", (object?)m.IncidenciaTecnica ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_cargas_combustible.insert_cargacombustible(:p_id_pedido_combustible, :p_id_surtidor, :p_cantidad_real_litros, :p_temperatura_combustible, :p_densidad_combustible, :p_fecha_inicio_carga, :p_fecha_fin_carga, :p_duracion_minutos, :p_operador_carga, :p_verificador, :p_lectura_inicial_contador, :p_lectura_final_contador, :p_incidencia_tecnica, :p_observaciones); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, CargasCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_cargacombustible", (object?)m.IdCargaCombustible ?? DBNull.Value),
                new OracleParameter("p_id_pedido_combustible", (object?)m.IdPedidoCombustible ?? DBNull.Value),
                new OracleParameter("p_id_surtidor", (object?)m.IdSurtidor ?? DBNull.Value),
                new OracleParameter("p_cantidad_real_litros", (object?)m.CantidadRealLitros ?? DBNull.Value),
                new OracleParameter("p_temperatura_combustible", (object?)m.TemperaturaCombustible ?? DBNull.Value),
                new OracleParameter("p_densidad_combustible", (object?)m.DensidadCombustible ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_carga", (object?)m.FechaInicioCarga ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_carga", (object?)m.FechaFinCarga ?? DBNull.Value),
                new OracleParameter("p_duracion_minutos", (object?)m.DuracionMinutos ?? DBNull.Value),
                new OracleParameter("p_operador_carga", (object?)m.OperadorCarga ?? DBNull.Value),
                new OracleParameter("p_verificador", (object?)m.Verificador ?? DBNull.Value),
                new OracleParameter("p_lectura_inicial_contador", (object?)m.LecturaInicialContador ?? DBNull.Value),
                new OracleParameter("p_lectura_final_contador", (object?)m.LecturaFinalContador ?? DBNull.Value),
                new OracleParameter("p_incidencia_tecnica", (object?)m.IncidenciaTecnica ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_cargas_combustible.update_cargacombustible(:p_id_cargacombustible, :p_id_pedido_combustible, :p_id_surtidor, :p_cantidad_real_litros, :p_temperatura_combustible, :p_densidad_combustible, :p_fecha_inicio_carga, :p_fecha_fin_carga, :p_duracion_minutos, :p_operador_carga, :p_verificador, :p_lectura_inicial_contador, :p_lectura_final_contador, :p_incidencia_tecnica, :p_observaciones); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_cargas_combustible.delete_cargacombustible(:p_id_cargacombustible); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_cargacombustible", id));
            return true;
        }

        public async Task<List<CargasCombustible>> ListarTodo()
        {
            return await _context.Set<CargasCombustible>().ToListAsync();
        }

        public async Task<CargasCombustible?> ObtenerPorId(int id)
        {
            return await _context.Set<CargasCombustible>().FirstOrDefaultAsync(x => x.IdCargaCombustible == id);
        }
    }
}
