using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class RutaTransporteService : IRutaTransporteTerrestreService
    {
        private readonly DBContext _context;
        public RutaTransporteService(DBContext context) => _context = context;

        public async Task<bool> Insertar(RutasTransporteTerrestre m)
        {
            var p = new[] {
                new OracleParameter("p_codigo_ruta", (object?)m.CodigoRuta ?? DBNull.Value),
                new OracleParameter("p_nombre_ruta", (object?)m.NombreRuta ?? DBNull.Value),
                new OracleParameter("p_origen", (object?)m.Origen ?? DBNull.Value),
                new OracleParameter("p_destino", (object?)m.Destino ?? DBNull.Value),
                new OracleParameter("p_distancia_km", (object?)m.DistanciaKm ?? DBNull.Value),
                new OracleParameter("p_duracion_estimada", (object?)m.DuracionEstimadaMinutos ?? DBNull.Value),
                new OracleParameter("p_tipo_ruta", (object?)m.TipoRuta ?? DBNull.Value),
                new OracleParameter("p_frecuencia_servicio", (object?)m.FrecuenciaServicio ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_rutas_transporte.insert_ruta(:p_codigo_ruta, :p_nombre_ruta, :p_origen, :p_destino, :p_distancia_km, :p_duracion_estimada, :p_tipo_ruta, :p_frecuencia_servicio, :p_activa); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, RutasTransporteTerrestre m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_ruta_transporte", m.IdRutaTransporte)
            };
            p.AddRange(new[] {
                new OracleParameter("p_codigo_ruta", (object?)m.CodigoRuta ?? DBNull.Value),
                new OracleParameter("p_nombre_ruta", (object?)m.NombreRuta ?? DBNull.Value),
                new OracleParameter("p_origen", (object?)m.Origen ?? DBNull.Value),
                new OracleParameter("p_destino", (object?)m.Destino ?? DBNull.Value),
                new OracleParameter("p_distancia_km", (object?)m.DistanciaKm ?? DBNull.Value),
                new OracleParameter("p_duracion_estimada", (object?)m.DuracionEstimadaMinutos ?? DBNull.Value),
                new OracleParameter("p_tipo_ruta", (object?)m.TipoRuta ?? DBNull.Value),
                new OracleParameter("p_frecuencia_servicio", (object?)m.FrecuenciaServicio ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_rutas_transporte.update_ruta(:p_id_ruta_transporte, :p_codigo_ruta, :p_nombre_ruta, :p_origen, :p_destino, :p_distancia_km, :p_duracion_estimada, :p_tipo_ruta, :p_frecuencia_servicio, :p_activa); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_rutas_transporte.delete_ruta(:p_id_ruta_transporte); END;", 
                new OracleParameter("p_id_ruta_transporte", id));
            return true;
        }

        public async Task<List<RutasTransporteTerrestre>> ListarTodo() => await _context.Set<RutasTransporteTerrestre>().ToListAsync();

        public async Task<RutasTransporteTerrestre?> ObtenerPorId(int id) => await _context.Set<RutasTransporteTerrestre>().FindAsync(id);
    }
}
