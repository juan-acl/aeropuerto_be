using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class GruposViajeService : IGruposViajeService
    {
        private readonly DBContext _context;

        public GruposViajeService(DBContext context) => _context = context;

        public async Task<bool> Insertar(GruposViajeModel m)
        {
            var sql = @"INSERT INTO grupos_viaje 
                        (nombre_grupo, tipo_grupo, cantidad_pasajeros, contacto_responsable, telefono_responsable, email_responsable, observaciones) 
                        VALUES (:p_nom, :p_tipo, :p_cant, :p_cont, :p_tel, :p_mail, :p_obs)";

            var parametros = new[] {
                new OracleParameter("p_nom", (object?)m.NombreGrupo ?? DBNull.Value),
                new OracleParameter("p_tipo", m.TipoGrupo),
                new OracleParameter("p_cant", m.CantidadPasajeros),
                new OracleParameter("p_cont", (object?)m.ContactoResponsable ?? DBNull.Value),
                new OracleParameter("p_tel", (object?)m.TelefonoResponsable ?? DBNull.Value),
                new OracleParameter("p_mail", (object?)m.EmailResponsable ?? DBNull.Value),
                new OracleParameter("p_obs", (object?)m.Observaciones ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<GruposViajeModel>> ListarTodos()
        {
            return await _context.GruposViaje.ToListAsync();
        }

        public async Task<GruposViajeModel?> ObtenerPorId(int id)
        {
            return await _context.GruposViaje.FindAsync(id);
        }

        public async Task<bool> Actualizar(int id, GruposViajeModel m)
        {
            var sql = @"UPDATE grupos_viaje 
                        SET nombre_grupo = :p_nom, tipo_grupo = :p_tipo, 
                            cantidad_pasajeros = :p_cant, contacto_responsable = :p_cont, 
                            telefono_responsable = :p_tel, email_responsable = :p_mail, 
                            observaciones = :p_obs 
                        WHERE id_grupo = :p_id";

            var parametros = new[] {
                new OracleParameter("p_nom", m.NombreGrupo),
                new OracleParameter("p_tipo", m.TipoGrupo),
                new OracleParameter("p_cant", m.CantidadPasajeros),
                new OracleParameter("p_cont", m.ContactoResponsable),
                new OracleParameter("p_tel", m.TelefonoResponsable),
                new OracleParameter("p_mail", m.EmailResponsable),
                new OracleParameter("p_obs", m.Observaciones),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM grupos_viaje WHERE id_grupo = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}