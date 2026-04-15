using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class EstandarInternacionalService : IEstandarInternacionalService
    {
        private readonly DBContext _ctx;
        public EstandarInternacionalService(DBContext ctx) => _ctx = ctx;
        public async Task<List<EstandaresInternacionales>> ListarTodo() => await _ctx.Set<EstandaresInternacionales>().ToListAsync();
        public async Task<EstandaresInternacionales?> ObtenerPorId(int id) => await _ctx.Set<EstandaresInternacionales>().FindAsync(id);
        public async Task<bool> Insertar(EstandaresInternacionales m) { _ctx.Set<EstandaresInternacionales>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, EstandaresInternacionales m) {
            var e = await _ctx.Set<EstandaresInternacionales>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<EstandaresInternacionales>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<EstandaresInternacionales>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
