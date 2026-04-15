using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ModeloAvionService : IModeloAvionService
    {
        private readonly DBContext _context;

        public ModeloAvionService(DBContext context)
        {
            _context = context;
        }

        // 1. INSERTAR
        public async Task<bool> Insertar(ModeloAvionModel m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_modelo", m.IdModelo),
                new OracleParameter("p_nombre_modelo", m.NombreModelo),
                new OracleParameter("p_fabricante", (object?)m.Fabricante ?? DBNull.Value),
                new OracleParameter("p_capacidad_pasajeros", (object?)m.CapacidadPasajeros ?? DBNull.Value),
                new OracleParameter("p_capacidad_carga_kg", (object?)m.CapacidadCargaKg ?? DBNull.Value),
                new OracleParameter("p_autonomia_km", (object?)m.AutonomiaKm ?? DBNull.Value),
                new OracleParameter("p_velocidad_crucero_kmh", (object?)m.VelocidadCruceroKmh ?? DBNull.Value),
                new OracleParameter("p_longitud_metros", (object?)m.LongitudMetros ?? DBNull.Value),
                new OracleParameter("p_envergadura_metros", (object?)m.EnvergaduraMetros ?? DBNull.Value),
                new OracleParameter("p_altura_metros", (object?)m.AlturaMetros ?? DBNull.Value),
                new OracleParameter("p_tripulacion_minima", (object?)m.TripulacionMinima ?? DBNull.Value),
                new OracleParameter("p_anio_fabricacion", (object?)m.AnioFabricacion ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
            };

            string sql = "BEGIN pkg_modelos_aviones.insert_modelo(:p_id_modelo, :p_nombre_modelo, :p_fabricante, :p_capacidad_pasajeros, :p_capacidad_carga_kg, :p_autonomia_km, :p_velocidad_crucero_kmh, :p_longitud_metros, :p_envergadura_metros, :p_altura_metros, :p_tripulacion_minima, :p_anio_fabricacion, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        // 2. ACTUALIZAR
        public async Task<bool> Actualizar(int id, int pasajeros, decimal carga, decimal autonomia, int activo)
        {
            // Recuperamos el modelo completo para no perder las dimensiones y datos técnicos
            var actual = await ObtenerPorId(id);
            if (actual == null) return false;

            var sql = "BEGIN pkg_modelos_aviones.update_modelo(:p_id_modelo, :p_nombre_modelo, :p_fabricante, :p_capacidad_pasajeros, :p_capacidad_carga_kg, :p_autonomia_km, :p_velocidad_crucero_kmh, :p_longitud_metros, :p_envergadura_metros, :p_altura_metros, :p_tripulacion_minima, :p_anio_fabricacion, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_id_modelo", id),
                new OracleParameter("p_nombre_modelo", actual.NombreModelo),
                new OracleParameter("p_fabricante", (object?)actual.Fabricante ?? DBNull.Value),
                new OracleParameter("p_capacidad_pasajeros", pasajeros),
                new OracleParameter("p_capacidad_carga_kg", carga),
                new OracleParameter("p_autonomia_km", autonomia),
                new OracleParameter("p_velocidad_crucero_kmh", (object?)actual.VelocidadCruceroKmh ?? DBNull.Value),
                new OracleParameter("p_longitud_metros", (object?)actual.LongitudMetros ?? DBNull.Value),
                new OracleParameter("p_envergadura_metros", (object?)actual.EnvergaduraMetros ?? DBNull.Value),
                new OracleParameter("p_altura_metros", (object?)actual.AlturaMetros ?? DBNull.Value),
                new OracleParameter("p_tripulacion_minima", (object?)actual.TripulacionMinima ?? DBNull.Value),
                new OracleParameter("p_anio_fabricacion", (object?)actual.AnioFabricacion ?? DBNull.Value),
                new OracleParameter("p_activo", activo));

            return true;
        }

        // 3. ELIMINAR
        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_modelos_aviones.delete_modelo(:p_id_modelo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_modelo", id));
            return true;
        }

        // 4. LISTAR
        public async Task<List<ModeloAvionModel>> ListarTodo()
        {
            return await _context.ModelosAviones.ToListAsync();
        }

        // 5. OBTENER POR ID
        public async Task<ModeloAvionModel?> ObtenerPorId(int id)
        {
            return await _context.ModelosAviones.FirstOrDefaultAsync(x => x.IdModelo == id);
        }
    }
}

