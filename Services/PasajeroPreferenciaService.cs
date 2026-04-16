using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PasajeroPreferenciaService : IPasajeroPreferenciaService
    {
        private readonly DBContext _context;

        public PasajeroPreferenciaService(DBContext context) => _context = context;

        public async Task<bool> Insertar(PasajeroPreferenciaModel m)
        {
            var sql = @"BEGIN pkg_pasajeros.insert_preferencia(
                :p_id_pasajero, :p_tipo, :p_desc); END;";

            var parametros = new[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_tipo", m.TipoPreferencia),
                new OracleParameter("p_desc", (object?)m.Descripcion ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<PasajeroPreferenciaModel>> ListarPorPasajero(int idPasajero)
        {
            return await _context.PasajerosPreferencias
                .Where(p => p.IdPasajero == idPasajero && p.Activo == 1)
                .ToListAsync();
        }

        public async Task<bool> ActualizarPreferencia(int id, string descripcion)
        {
            var sql = "UPDATE pasajeros_preferencias SET descripcion = :p_desc, fecha_actualizacion = SYSDATE WHERE id_preferencia = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_desc", descripcion),
                new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarLogico(int id)
        {
            var sql = "UPDATE pasajeros_preferencias SET activo = 0 WHERE id_preferencia = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}