using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class PrediccionDemandaService : IPrediccionDemandaService
    {
        private readonly DBContext _ctx;
        public PrediccionDemandaService(DBContext ctx) => _ctx = ctx;
        public async Task<List<PrediccionDemanda>> ListarTodo() => await _ctx.Set<PrediccionDemanda>().ToListAsync();
        public async Task<PrediccionDemanda?> ObtenerPorId(int id) => await _ctx.Set<PrediccionDemanda>().FindAsync(id);
        public async Task<bool> Insertar(PrediccionDemanda m) { _ctx.Set<PrediccionDemanda>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, PrediccionDemanda m) {
            var e = await _ctx.Set<PrediccionDemanda>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<PrediccionDemanda>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<PrediccionDemanda>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
