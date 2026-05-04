using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TarifasTransporteTerrestreService : ITarifasTransporteTerrestreService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TarifasTransporteTerrestreService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TarifasTransporteTerrestre>> ListarTodo()
        {
            try { return await _replica.TarifasTransporte.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TarifasTransporteTerrestre: {ex.Message}"); return new List<TarifasTransporteTerrestre>(); }
        }

        public async Task<TarifasTransporteTerrestre ?> ObtenerPorId(int id)
        {
            try { return await _replica.TarifasTransporte.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TarifasTransporteTerrestre: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TarifasTransporteTerrestre m)
        {
            try
            {
                string sql = "BEGIN pkg_tarifas_transporte.insert_tarifa(:p_id_ruta_transporte, :p_tipo_tarifa, :p_precio_por_persona, :p_precio_vehiculo_privado, :p_precio_maleta_extra, :p_moneda, :p_hora_inicio_aplicacion, :p_hora_fin_aplicacion, :p_dias_aplicacion, :p_fecha_inicio_vigencia, :p_fecha_fin_vigencia, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_ruta_transporte", m.IdRutaTransporte),
                    new OracleParameter("p_tipo_tarifa", (object?)m.TipoTarifa ?? DBNull.Value),
                    new OracleParameter("p_precio_por_persona", (object?)m.PrecioPorPersona ?? DBNull.Value),
                    new OracleParameter("p_precio_vehiculo_privado", (object?)m.PrecioVehiculoPrivado ?? DBNull.Value),
                    new OracleParameter("p_precio_maleta_extra", (object?)m.PrecioMaletaExtra ?? DBNull.Value),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_hora_inicio_aplicacion", (object?)m.HoraInicioAplicacion ?? DBNull.Value),
                    new OracleParameter("p_hora_fin_aplicacion", (object?)m.HoraFinAplicacion ?? DBNull.Value),
                    new OracleParameter("p_dias_aplicacion", (object?)m.DiasAplicacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio_vigencia", m.FechaInicioVigencia),
                    new OracleParameter("p_fecha_fin_vigencia", (object?)m.FechaFinVigencia ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar TarifasTransporteTerrestre: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, TarifasTransporteTerrestre m)
        {
            try
            {
                string sql = "BEGIN pkg_tarifas_transporte.update_tarifa(:p_id_tarifa_transporte, :p_id_ruta_transporte, :p_tipo_tarifa, :p_precio_por_persona, :p_precio_vehiculo_privado, :p_precio_maleta_extra, :p_moneda, :p_hora_inicio_aplicacion, :p_hora_fin_aplicacion, :p_dias_aplicacion, :p_fecha_inicio_vigencia, :p_fecha_fin_vigencia, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_tarifa_transporte", id),
                    new OracleParameter("p_id_ruta_transporte", m.IdRutaTransporte),
                    new OracleParameter("p_tipo_tarifa", (object?)m.TipoTarifa ?? DBNull.Value),
                    new OracleParameter("p_precio_por_persona", (object?)m.PrecioPorPersona ?? DBNull.Value),
                    new OracleParameter("p_precio_vehiculo_privado", (object?)m.PrecioVehiculoPrivado ?? DBNull.Value),
                    new OracleParameter("p_precio_maleta_extra", (object?)m.PrecioMaletaExtra ?? DBNull.Value),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_hora_inicio_aplicacion", (object?)m.HoraInicioAplicacion ?? DBNull.Value),
                    new OracleParameter("p_hora_fin_aplicacion", (object?)m.HoraFinAplicacion ?? DBNull.Value),
                    new OracleParameter("p_dias_aplicacion", (object?)m.DiasAplicacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio_vigencia", m.FechaInicioVigencia),
                    new OracleParameter("p_fecha_fin_vigencia", (object?)m.FechaFinVigencia ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar TarifasTransporteTerrestre: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_tarifas_transporte.delete_tarifa(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar TarifasTransporteTerrestre: {ex.Message}"); throw; }
        }
    }
}
