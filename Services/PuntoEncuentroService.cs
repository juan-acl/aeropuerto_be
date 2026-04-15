using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PuntoEncuentroService : IPuntoEncuentroService
    {
        private readonly DBContext _context;
        public PuntoEncuentroService(DBContext context) => _context = context;

        public async Task<bool> Insertar(PuntosEncuentro m)
        {
            var p = new[] {
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
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_puntos_encuentro.insert_punto(:p_codigo_punto, :p_nombre, :p_ubicacion, :p_coordenada_latitud, :p_coordenada_longitud, :p_capacidad_personas, :p_senalizacion_visible, :p_iluminacion, :p_recursos_disponibles, :p_responsable_asignado, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, PuntosEncuentro m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_punto_encuentro", m.IdPuntoEncuentro)
            };
            p.AddRange(new[] {
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
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_puntos_encuentro.update_punto(:p_id_punto_encuentro, :p_codigo_punto, :p_nombre, :p_ubicacion, :p_coordenada_latitud, :p_coordenada_longitud, :p_capacidad_personas, :p_senalizacion_visible, :p_iluminacion, :p_recursos_disponibles, :p_responsable_asignado, :p_activo); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_puntos_encuentro.delete_punto(:p_id_punto_encuentro); END;", 
                new OracleParameter("p_id_punto_encuentro", id));
            return true;
        }

        public async Task<List<PuntosEncuentro>> ListarTodo() => await _context.Set<PuntosEncuentro>().ToListAsync();

        public async Task<PuntosEncuentro?> ObtenerPorId(int id) => await _context.Set<PuntosEncuentro>().FindAsync(id);
    }
}
