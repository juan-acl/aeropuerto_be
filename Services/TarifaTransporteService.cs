using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class TarifaTransporteService
    {
        private readonly DBContext _context;
        public TarifaTransporteService(DBContext context) => _context = context;

        public async Task<bool> Insertar(TarifasTransporteTerrestre m)
        {
            var p = new[] {
                new OracleParameter("p_id_ruta_transporte", (object?)m.IdRutaTransporte ?? DBNull.Value),
                new OracleParameter("p_tipo_tarifa", (object?)m.TipoTarifa ?? DBNull.Value),
                new OracleParameter("p_precio_por_persona", (object?)m.PrecioPorPersona ?? DBNull.Value),
                new OracleParameter("p_precio_vehiculo_privado", (object?)m.PrecioVehiculoPrivado ?? DBNull.Value),
                new OracleParameter("p_precio_maleta_extra", (object?)m.PrecioMaletaExtra ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_hora_inicio_aplicacion", (object?)m.HoraInicioAplicacion ?? DBNull.Value),
                new OracleParameter("p_hora_fin_aplicacion", (object?)m.HoraFinAplicacion ?? DBNull.Value),
                new OracleParameter("p_dias_aplicacion", (object?)m.DiasAplicacion ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_vigencia", (object?)m.FechaInicioVigencia ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_vigencia", (object?)m.FechaFinVigencia ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_tarifas_transporte.insert_tarifa(:p_id_ruta_transporte, :p_tipo_tarifa, :p_precio_por_persona, :p_precio_vehiculo_privado, :p_precio_maleta_extra, :p_moneda, :p_hora_inicio_aplicacion, :p_hora_fin_aplicacion, :p_dias_aplicacion, :p_fecha_inicio_vigencia, :p_fecha_fin_vigencia, :p_activa); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(TarifasTransporteTerrestre m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_tarifa_transporte", m.IdTarifaTransporte)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_ruta_transporte", (object?)m.IdRutaTransporte ?? DBNull.Value),
                new OracleParameter("p_tipo_tarifa", (object?)m.TipoTarifa ?? DBNull.Value),
                new OracleParameter("p_precio_por_persona", (object?)m.PrecioPorPersona ?? DBNull.Value),
                new OracleParameter("p_precio_vehiculo_privado", (object?)m.PrecioVehiculoPrivado ?? DBNull.Value),
                new OracleParameter("p_precio_maleta_extra", (object?)m.PrecioMaletaExtra ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_hora_inicio_aplicacion", (object?)m.HoraInicioAplicacion ?? DBNull.Value),
                new OracleParameter("p_hora_fin_aplicacion", (object?)m.HoraFinAplicacion ?? DBNull.Value),
                new OracleParameter("p_dias_aplicacion", (object?)m.DiasAplicacion ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio_vigencia", (object?)m.FechaInicioVigencia ?? DBNull.Value),
                new OracleParameter("p_fecha_fin_vigencia", (object?)m.FechaFinVigencia ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_tarifas_transporte.update_tarifa(:p_id_tarifa_transporte, :p_id_ruta_transporte, :p_tipo_tarifa, :p_precio_por_persona, :p_precio_vehiculo_privado, :p_precio_maleta_extra, :p_moneda, :p_hora_inicio_aplicacion, :p_hora_fin_aplicacion, :p_dias_aplicacion, :p_fecha_inicio_vigencia, :p_fecha_fin_vigencia, :p_activa); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_tarifas_transporte.delete_tarifa(:p_id_tarifa_transporte); END;", 
                new OracleParameter("p_id_tarifa_transporte", id));
            return true;
        }

        public async Task<List<TarifasTransporteTerrestre>> ListarTodo() => await _context.Set<TarifasTransporteTerrestre>().ToListAsync();

        public async Task<TarifasTransporteTerrestre?> ObtenerPorId(int id) => await _context.Set<TarifasTransporteTerrestre>().FindAsync(id);
    }
}
