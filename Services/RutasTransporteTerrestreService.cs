using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class RutasTransporteTerrestreService : IRutasTransporteTerrestreService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public RutasTransporteTerrestreService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<RutasTransporteTerrestre>> ListarTodo()
        {
            try { return await _replica.RutasTransporte.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo RutasTransporteTerrestre: {ex.Message}"); return new List<RutasTransporteTerrestre>(); }
        }

        public async Task<RutasTransporteTerrestre ?> ObtenerPorId(int id)
        {
            try { return await _replica.RutasTransporte.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId RutasTransporteTerrestre: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(RutasTransporteTerrestre m)
        {
            try
            {
                string sql = "BEGIN pkg_rutas_transporte.insert_ruta(:p_codigo_ruta, :p_nombre_ruta, :p_origen, :p_destino, :p_distancia_km, :p_duracion_estimada, :p_tipo_ruta, :p_frecuencia_servicio, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_ruta", (object?)m.CodigoRuta ?? DBNull.Value),
                    new OracleParameter("p_nombre_ruta", (object?)m.NombreRuta ?? DBNull.Value),
                    new OracleParameter("p_origen", (object?)m.Origen ?? DBNull.Value),
                    new OracleParameter("p_destino", (object?)m.Destino ?? DBNull.Value),
                    new OracleParameter("p_distancia_km", (object?)m.DistanciaKm ?? DBNull.Value),
                    new OracleParameter("p_duracion_estimada", DBNull.Value),
                    new OracleParameter("p_tipo_ruta", (object?)m.TipoRuta ?? DBNull.Value),
                    new OracleParameter("p_frecuencia_servicio", (object?)m.FrecuenciaServicio ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar RutasTransporteTerrestre: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, RutasTransporteTerrestre m)
        {
            try
            {
                string sql = "BEGIN pkg_rutas_transporte.update_ruta(:p_id_ruta_transporte, :p_codigo_ruta, :p_nombre_ruta, :p_origen, :p_destino, :p_distancia_km, :p_duracion_estimada, :p_tipo_ruta, :p_frecuencia_servicio, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_ruta_transporte", id),
                    new OracleParameter("p_codigo_ruta", (object?)m.CodigoRuta ?? DBNull.Value),
                    new OracleParameter("p_nombre_ruta", (object?)m.NombreRuta ?? DBNull.Value),
                    new OracleParameter("p_origen", (object?)m.Origen ?? DBNull.Value),
                    new OracleParameter("p_destino", (object?)m.Destino ?? DBNull.Value),
                    new OracleParameter("p_distancia_km", (object?)m.DistanciaKm ?? DBNull.Value),
                    new OracleParameter("p_duracion_estimada", DBNull.Value),
                    new OracleParameter("p_tipo_ruta", (object?)m.TipoRuta ?? DBNull.Value),
                    new OracleParameter("p_frecuencia_servicio", (object?)m.FrecuenciaServicio ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar RutasTransporteTerrestre: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_rutas_transporte.delete_ruta(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar RutasTransporteTerrestre: {ex.Message}"); throw; }
        }
    }
}
