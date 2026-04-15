using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ProgramaVueloService : IProgramaVueloService
    {
        private readonly DBContext _context;

        public ProgramaVueloService(DBContext context)
        {
            _context = context;
        }

        public async Task<List<ProgramaVueloModel>> ListarTodo()
        {
            return await _context.ProgramasVuelo
                .Where(p => p.Activo == 1)
                .OrderBy(p => p.NumeroVuelo)
                .ToListAsync();
        }

        public async Task<ProgramaVueloModel?> ObtenerPorId(int id)
        {
            return await _context.ProgramasVuelo.FirstOrDefaultAsync(p => p.IdPrograma == id);
        }

        public async Task<List<ProgramaVueloModel>> BuscarPorRuta(string origen, string destino)
        {
            return await _context.ProgramasVuelo
                .Where(p =>
                    p.Activo == 1 &&
                    (string.IsNullOrEmpty(origen)  || p.AeropuertoOrigen  == origen) &&
                    (string.IsNullOrEmpty(destino) || p.AeropuertoDestino == destino))
                .OrderBy(p => p.NumeroVuelo)
                .ToListAsync();
        }

        public async Task<List<ProgramaVueloModel>> ListarPorAerolinea(int idAerolinea)
        {
            return await _context.ProgramasVuelo
                .Where(p => p.IdAerolinea == idAerolinea && p.Activo == 1)
                .ToListAsync();
        }

        public async Task<bool> Insertar(ProgramaVueloModel m)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"BEGIN pkg_programas_vuelo.insert_programa(
                    :p_numero_vuelo, :p_id_aerolinea, :p_aeropuerto_origen,
                    :p_aeropuerto_destino, :p_tipo_vuelo, :p_duracion_min,
                    :p_distancia_km, :p_clase_servicio, :p_fecha_inicio, :p_fecha_fin
                ); END;",
                new OracleParameter("p_numero_vuelo",      m.NumeroVuelo),
                new OracleParameter("p_id_aerolinea",      m.IdAerolinea),
                new OracleParameter("p_aeropuerto_origen", m.AeropuertoOrigen),
                new OracleParameter("p_aeropuerto_destino",m.AeropuertoDestino),
                new OracleParameter("p_tipo_vuelo",        (object?)m.TipoVuelo ?? DBNull.Value),
                new OracleParameter("p_duracion_min",      (object?)m.DuracionEstimadaMinutos ?? DBNull.Value),
                new OracleParameter("p_distancia_km",      (object?)m.DistanciaKm ?? DBNull.Value),
                new OracleParameter("p_clase_servicio",    (object?)m.ClaseServicio ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio",      (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin",         (object?)m.FechaFin ?? DBNull.Value)
            );
            return true;
        }

        public async Task<bool> Actualizar(int id, ProgramaVueloModel m)
        {
            var existing = await _context.ProgramasVuelo.FindAsync(id);
            if (existing == null) return false;

            existing.DuracionEstimadaMinutos = m.DuracionEstimadaMinutos ?? existing.DuracionEstimadaMinutos;
            existing.DistanciaKm             = m.DistanciaKm ?? existing.DistanciaKm;
            existing.ClaseServicio           = m.ClaseServicio ?? existing.ClaseServicio;
            existing.Activo                  = m.Activo;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var p = await _context.ProgramasVuelo.FindAsync(id);
            if (p == null) return false;
            p.Activo = 0;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
