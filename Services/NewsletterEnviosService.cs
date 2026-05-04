using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class NewsletterEnviosService : INewsletterEnviosService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public NewsletterEnviosService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<NewsletterEnvios>> ListarTodo()
        {
            try { return await _replica.NewsletterEnvios.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo NewsletterEnvios: {ex.Message}"); return new List<NewsletterEnvios>(); }
        }

        public async Task<NewsletterEnvios ?> ObtenerPorId(int id)
        {
            try { return await _replica.NewsletterEnvios.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId NewsletterEnvios: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(NewsletterEnvios m)
        {
            _primary.NewsletterEnvios.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, NewsletterEnvios m)
        {
            _primary.NewsletterEnvios.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.NewsletterEnvios.FindAsync(id);
            if (e == null) return false;
            _primary.NewsletterEnvios.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
