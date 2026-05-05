using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class NewsletterSuscripcionesService : INewsletterSuscripcionesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public NewsletterSuscripcionesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<NewsletterSuscripciones>> ListarTodo()
        {
            try { return await _replica.NewsletterSuscripciones.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo NewsletterSuscripciones: {ex.Message}"); return new List<NewsletterSuscripciones>(); }
        }

        public async Task<NewsletterSuscripciones ?> ObtenerPorId(int id)
        {
            try { return await _replica.NewsletterSuscripciones.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId NewsletterSuscripciones: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(NewsletterSuscripciones m)
        {
            try
            {
                string sql = "BEGIN pkg_newsletter_suscripciones.insert_suscripcion(:p_id_pasajero, :p_email, :p_nombre, :p_fecha_suscripcion, :p_fecha_baja, :p_frecuencia, :p_temas_interes, :p_confirmado, :p_token_confirmacion, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                    new OracleParameter("p_nombre", (object?)m.Nombre ?? DBNull.Value),
                    new OracleParameter("p_fecha_suscripcion", (object?)m.FechaSuscripcion ?? DBNull.Value),
                    new OracleParameter("p_fecha_baja", (object?)m.FechaBaja ?? DBNull.Value),
                    new OracleParameter("p_frecuencia", (object?)m.Frecuencia ?? DBNull.Value),
                    new OracleParameter("p_temas_interes", (object?)m.TemasInteres ?? DBNull.Value),
                    new OracleParameter("p_confirmado", (object?)m.Confirmado ?? DBNull.Value),
                    new OracleParameter("p_token_confirmacion", (object?)m.TokenConfirmacion ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar NewsletterSuscripciones: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, NewsletterSuscripciones m)
        {
            try
            {
                string sql = "BEGIN pkg_newsletter_suscripciones.update_suscripcion(:p_id_suscripcion_newsletter, :p_id_pasajero, :p_email, :p_nombre, :p_fecha_suscripcion, :p_fecha_baja, :p_frecuencia, :p_temas_interes, :p_confirmado, :p_token_confirmacion, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_suscripcion_newsletter", id),
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                    new OracleParameter("p_nombre", (object?)m.Nombre ?? DBNull.Value),
                    new OracleParameter("p_fecha_suscripcion", (object?)m.FechaSuscripcion ?? DBNull.Value),
                    new OracleParameter("p_fecha_baja", (object?)m.FechaBaja ?? DBNull.Value),
                    new OracleParameter("p_frecuencia", (object?)m.Frecuencia ?? DBNull.Value),
                    new OracleParameter("p_temas_interes", (object?)m.TemasInteres ?? DBNull.Value),
                    new OracleParameter("p_confirmado", (object?)m.Confirmado ?? DBNull.Value),
                    new OracleParameter("p_token_confirmacion", (object?)m.TokenConfirmacion ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar NewsletterSuscripciones: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_newsletter_suscripciones.delete_suscripcion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar NewsletterSuscripciones: {ex.Message}"); throw; }
        }
    }
}
