using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class TarifaTransporteTerrestreService : ITarifaTransporteTerrestreService
    {
        private readonly DBContext _context;
        public TarifaTransporteTerrestreService(DBContext context) => _context = context;

        public async Task<bool> Insertar(TarifasTransporteTerrestre m)
        {
            var p = new[] {
                new OracleParameter("p_id_ruta_transporte",        m.IdRutaTransporte),
                new OracleParameter("p_tipo_tarifa",               (object?)m.TipoTarifa               ?? DBNull.Value),
                new OracleParameter("p_precio_por_persona",        (object?)m.PrecioPorPersona          ?? DBNull.Value),
                new OracleParameter("p_precio_vehiculo_privado",   (object?)m.PrecioVehiculoPrivado     ?? DBNull.Value),
                new OracleParameter("p_precio_maleta_extra",       (object?)m.PrecioMaletaExtra         ?? DBNull.Value),
                new OracleParameter("p_moneda",                    (object?)m.Moneda                    ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN pkg_tarifas_transporte.insert_tarifa(:p_id_ruta_transporte,:p_tipo_tarifa,:p_precio_por_persona,:p_precio_vehiculo_privado,:p_precio_maleta_extra,:p_moneda); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, TarifasTransporteTerrestre m)
        {
            var p = new[] {
                new OracleParameter("p_id_tarifa_transporte",      id),
                new OracleParameter("p_tipo_tarifa",               (object?)m.TipoTarifa               ?? DBNull.Value),
                new OracleParameter("p_precio_por_persona",        (object?)m.PrecioPorPersona          ?? DBNull.Value),
                new OracleParameter("p_precio_vehiculo_privado",   (object?)m.PrecioVehiculoPrivado     ?? DBNull.Value),
                new OracleParameter("p_precio_maleta_extra",       (object?)m.PrecioMaletaExtra         ?? DBNull.Value),
                new OracleParameter("p_moneda",                    (object?)m.Moneda                    ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN pkg_tarifas_transporte.update_tarifa(:p_id_tarifa_transporte,:p_tipo_tarifa,:p_precio_por_persona,:p_precio_vehiculo_privado,:p_precio_maleta_extra,:p_moneda); END;", p);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN pkg_tarifas_transporte.delete_tarifa(:p_id_tarifa_transporte); END;",
                new OracleParameter("p_id_tarifa_transporte", id));
            return true;
        }

        public async Task<List<TarifasTransporteTerrestre>> ListarTodo() =>
            await _context.Set<TarifasTransporteTerrestre>().ToListAsync();

        public async Task<TarifasTransporteTerrestre?> ObtenerPorId(int id) =>
            await _context.Set<TarifasTransporteTerrestre>().FindAsync(id);
    }
}
