using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PerfilViajeroService : IPerfilViajeroService
    {
        private readonly DBContext _context;

        public PerfilViajeroService(DBContext context) => _context = context;

        public async Task<bool> Insertar(PerfilViajeroModel m)
        {
            var sql = @"BEGIN pkg_pasajeros.insert_perfil(
                :p_id_pasajero, :p_tipo, :p_num_prog, :p_aerolinea, :p_cat); END;";

            var parametros = new[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_tipo", m.TipoPerfil),
                new OracleParameter("p_num_prog", (object?)m.NumeroPrograma ?? DBNull.Value),
                new OracleParameter("p_aerolinea", (object?)m.AerolineaAsociada ?? DBNull.Value),
                new OracleParameter("p_cat", (object?)m.Categoria ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<PerfilViajeroModel?> ObtenerPorPasajero(int idPasajero)
        {
            return await _context.PerfilesViajero
                .FirstOrDefaultAsync(p => p.IdPasajero == idPasajero);
        }

        public async Task<bool> SumarPuntos(int idPerfil, int puntos)
        {
            var sql = "UPDATE perfiles_viajero SET puntos_acumulados = puntos_acumulados + :p_puntos, fecha_ultima_actividad = SYSDATE WHERE id_perfil = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_puntos", puntos),
                new OracleParameter("p_id", idPerfil));
            return true;
        }

        public async Task<bool> ActualizarCategoria(int idPerfil, string nuevaCategoria)
        {
            var sql = "UPDATE perfiles_viajero SET categoria = :p_cat WHERE id_perfil = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_cat", nuevaCategoria),
                new OracleParameter("p_id", idPerfil));
            return true;
        }
        public async Task<bool> Eliminar(int idPerfil)
        {
            var sql = "DELETE FROM perfiles_viajero WHERE id_perfil = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", idPerfil));
            return true;
        }
    }
}