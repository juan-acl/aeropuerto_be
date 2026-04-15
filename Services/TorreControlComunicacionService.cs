using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class TorreControlComunicacionService : ITorreControlComunicacionService
    {
        private readonly DBContext _ctx;
        public TorreControlComunicacionService(DBContext ctx) => _ctx = ctx;
        public async Task<List<TorreControlComunicaciones>> ListarTodo() => await _ctx.Set<TorreControlComunicaciones>().ToListAsync();
        public async Task<TorreControlComunicaciones?> ObtenerPorId(int id) => await _ctx.Set<TorreControlComunicaciones>().FindAsync(id);
        public async Task<bool> Insertar(TorreControlComunicaciones m) { _ctx.Set<TorreControlComunicaciones>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, TorreControlComunicaciones m) {
            var e = await _ctx.Set<TorreControlComunicaciones>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<TorreControlComunicaciones>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<TorreControlComunicaciones>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
