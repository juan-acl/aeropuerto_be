using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TemporadaVueloService : ITemporadaVueloService
    {
        private readonly DBContext _context;

        public TemporadaVueloService(DBContext context)
        {
            _context = context;
        }

        // 1. INSERTAR
        public async Task<bool> Insertar(TemporadaVueloModel m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_temporada", m.IdTemporada),
                new OracleParameter("p_nombre_temporada", m.NombreTemporada),
                new OracleParameter("p_fecha_inicio", m.FechaInicio),
                new OracleParameter("p_fecha_fin", m.FechaFin),
                new OracleParameter("p_factor_demanda", m.FactorDemanda),
                new OracleParameter("p_activa", m.Activa)
            };

            string sql = "BEGIN pkg_temporadas_vuelo.insert_temporada(:p_id_temporada, :p_nombre_temporada, :p_fecha_inicio, :p_fecha_fin, :p_factor_demanda, :p_activa); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        // 2. ACTUALIZAR
        public async Task<bool> Actualizar(int id, string nombre, DateTime inicio, DateTime fin, decimal factor, int activa)
        {
            var sql = "BEGIN pkg_temporadas_vuelo.update_temporada(:p_id_temporada, :p_nombre_temporada, :p_fecha_inicio, :p_fecha_fin, :p_factor_demanda, :p_activa); END;";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_id_temporada", id),
                new OracleParameter("p_nombre_temporada", nombre),
                new OracleParameter("p_fecha_inicio", inicio),
                new OracleParameter("p_fecha_fin", fin),
                new OracleParameter("p_factor_demanda", factor),
                new OracleParameter("p_activa", activa));

            return true;
        }

        // 3. ELIMINAR
        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_temporadas_vuelo.delete_temporada(:p_id_temporada); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_temporada", id));
            return true;
        }

        // 4. LISTAR
        public async Task<List<TemporadaVueloModel>> ListarTodo()
        {
            return await _context.TemporadasVuelo.ToListAsync();
        }

        // 5. OBTENER POR ID
        public async Task<TemporadaVueloModel?> ObtenerPorId(int id)
        {
            return await _context.TemporadasVuelo.FirstOrDefaultAsync(x => x.IdTemporada == id);
        }
    }
}

