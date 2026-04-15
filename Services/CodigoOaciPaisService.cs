using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class CodigoOaciPaisService : ICodigoOaciPaisService
    {
        private readonly DBContext _ctx;
        public CodigoOaciPaisService(DBContext ctx) => _ctx = ctx;
        public async Task<List<CodigosOaciPaises>> ListarTodo() => await _ctx.Set<CodigosOaciPaises>().ToListAsync();
        public async Task<CodigosOaciPaises?> ObtenerPorId(int id) => await _ctx.Set<CodigosOaciPaises>().FindAsync(id);
        public async Task<bool> Insertar(CodigosOaciPaises m) { _ctx.Set<CodigosOaciPaises>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, CodigosOaciPaises m) {
            var e = await _ctx.Set<CodigosOaciPaises>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<CodigosOaciPaises>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<CodigosOaciPaises>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
