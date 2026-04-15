using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class NewsletterEnvioService : INewsletterEnvioService
    {
        private readonly DBContext _ctx;
        public NewsletterEnvioService(DBContext ctx) => _ctx = ctx;
        public async Task<List<NewsletterEnvios>> ListarTodo() => await _ctx.Set<NewsletterEnvios>().ToListAsync();
        public async Task<NewsletterEnvios?> ObtenerPorId(int id) => await _ctx.Set<NewsletterEnvios>().FindAsync(id);
        public async Task<bool> Insertar(NewsletterEnvios m) { _ctx.Set<NewsletterEnvios>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, NewsletterEnvios m) {
            var e = await _ctx.Set<NewsletterEnvios>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<NewsletterEnvios>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<NewsletterEnvios>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
