using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PuntoEncuentroService : IPuntoEncuentroService
    {
        private readonly DBContext _context;
        public PuntoEncuentroService(DBContext context) => _context = context;

        public async Task<List<PuntosEncuentro>> ListarTodo()
        {
            try { return await _context.PuntosEncuentro.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PuntosEncuentro: {ex.Message}"); return new List<PuntosEncuentro>(); }
        }

        public async Task<PuntosEncuentro?> ObtenerPorId(int id)
        {
            try { return await _context.PuntosEncuentro.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PuntosEncuentro: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PuntosEncuentro m)
        {
            try
            {
                string sql = "BEGIN pkg_puntos_encuentro.insert_punto(:p_codigo_punto, :p_nombre, :p_ubicacion, :p_coordenada_latitud, :p_coordenada_longitud, :p_capacidad_personas, :p_senalizacion_visible, :p_iluminacion, :p_recursos_disponibles, :p_responsable_asignado, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_codigo_punto", (object?)m.CodigoPunto ?? DBNull.Value),
                new OracleParameter("p_nombre", (object?)m.Nombre ?? DBNull.Value),
                new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                new OracleParameter("p_coordenada_latitud", (object?)m.CoordenadaLatitud ?? DBNull.Value),
                new OracleParameter("p_coordenada_longitud", (object?)m.CoordenadaLongitud ?? DBNull.Value),
                new OracleParameter("p_capacidad_personas", (object?)m.CapacidadPersonas ?? DBNull.Value),
                new OracleParameter("p_senalizacion_visible", (object?)m.SenalizacionVisible ?? DBNull.Value),
                new OracleParameter("p_iluminacion", (object?)m.Iluminacion ?? DBNull.Value),
                new OracleParameter("p_recursos_disponibles", (object?)m.RecursosDisponibles ?? DBNull.Value),
                new OracleParameter("p_responsable_asignado", (object?)m.ResponsableAsignado ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PuntosEncuentro: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, PuntosEncuentro m)
        {
            try
            {
                string sql = "BEGIN pkg_puntos_encuentro.update_punto(:p_id_punto_encuentro, :p_codigo_punto, :p_nombre, :p_ubicacion, :p_coordenada_latitud, :p_coordenada_longitud, :p_capacidad_personas, :p_senalizacion_visible, :p_iluminacion, :p_recursos_disponibles, :p_responsable_asignado, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_punto_encuentro", id),
                new OracleParameter("p_codigo_punto", (object?)m.CodigoPunto ?? DBNull.Value),
                new OracleParameter("p_nombre", (object?)m.Nombre ?? DBNull.Value),
                new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                new OracleParameter("p_coordenada_latitud", (object?)m.CoordenadaLatitud ?? DBNull.Value),
                new OracleParameter("p_coordenada_longitud", (object?)m.CoordenadaLongitud ?? DBNull.Value),
                new OracleParameter("p_capacidad_personas", (object?)m.CapacidadPersonas ?? DBNull.Value),
                new OracleParameter("p_senalizacion_visible", (object?)m.SenalizacionVisible ?? DBNull.Value),
                new OracleParameter("p_iluminacion", (object?)m.Iluminacion ?? DBNull.Value),
                new OracleParameter("p_recursos_disponibles", (object?)m.RecursosDisponibles ?? DBNull.Value),
                new OracleParameter("p_responsable_asignado", (object?)m.ResponsableAsignado ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PuntosEncuentro: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_puntos_encuentro.delete_punto(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PuntosEncuentro: {ex.Message}"); return false; }
        }
    }
}
