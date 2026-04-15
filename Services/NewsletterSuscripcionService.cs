using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class NewsletterSuscripcionService : INewsletterSuscripcionService
    {
        private readonly DBContext _context;
        public NewsletterSuscripcionService(DBContext context) => _context = context;

        public async Task<bool> Insertar(NewsletterSuscripciones m)
        {
            var p = new[] {
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                new OracleParameter("p_nombre", (object?)m.Nombre ?? DBNull.Value),
                new OracleParameter("p_fecha_suscripcion", (object?)m.FechaSuscripcion ?? DBNull.Value),
                new OracleParameter("p_fecha_baja", (object?)m.FechaBaja ?? DBNull.Value),
                new OracleParameter("p_frecuencia", (object?)m.Frecuencia ?? DBNull.Value),
                new OracleParameter("p_temas_interes", (object?)m.TemasInteres ?? DBNull.Value),
                new OracleParameter("p_confirmado", (object?)m.Confirmado ?? DBNull.Value),
                new OracleParameter("p_token_confirmacion", (object?)m.TokenConfirmacion ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_newsletter_suscripciones.insert_suscripcion(:p_id_pasajero, :p_email, :p_nombre, :p_fecha_suscripcion, :p_fecha_baja, :p_frecuencia, :p_temas_interes, :p_confirmado, :p_token_confirmacion, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, NewsletterSuscripciones m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_suscripcion_newsletter", m.IdSuscripcionNewsletter)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                new OracleParameter("p_nombre", (object?)m.Nombre ?? DBNull.Value),
                new OracleParameter("p_fecha_suscripcion", (object?)m.FechaSuscripcion ?? DBNull.Value),
                new OracleParameter("p_fecha_baja", (object?)m.FechaBaja ?? DBNull.Value),
                new OracleParameter("p_frecuencia", (object?)m.Frecuencia ?? DBNull.Value),
                new OracleParameter("p_temas_interes", (object?)m.TemasInteres ?? DBNull.Value),
                new OracleParameter("p_confirmado", (object?)m.Confirmado ?? DBNull.Value),
                new OracleParameter("p_token_confirmacion", (object?)m.TokenConfirmacion ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_newsletter_suscripciones.update_suscripcion(:p_id_suscripcion_newsletter, :p_id_pasajero, :p_email, :p_nombre, :p_fecha_suscripcion, :p_fecha_baja, :p_frecuencia, :p_temas_interes, :p_confirmado, :p_token_confirmacion, :p_activo); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_newsletter_suscripciones.delete_suscripcion(:p_id_suscripcion_newsletter); END;", 
                new OracleParameter("p_id_suscripcion_newsletter", id));
            return true;
        }

        public async Task<List<NewsletterSuscripciones>> ListarTodo() => await _context.Set<NewsletterSuscripciones>().ToListAsync();

        public async Task<NewsletterSuscripciones?> ObtenerPorId(int id) => await _context.Set<NewsletterSuscripciones>().FindAsync(id);
    }
}
