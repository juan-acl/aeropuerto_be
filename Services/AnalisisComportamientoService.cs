using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class AnalisisComportamientoService : IAnalisisComportamientoService
    {
        private readonly DBContext _ctx;
        public AnalisisComportamientoService(DBContext ctx) => _ctx = ctx;
        public async Task<List<AnalisisComportamiento>> ListarTodo() => await _ctx.Set<AnalisisComportamiento>().ToListAsync();
        public async Task<AnalisisComportamiento?> ObtenerPorId(int id) => await _ctx.Set<AnalisisComportamiento>().FindAsync(id);
        public async Task<bool> Insertar(AnalisisComportamiento m) { _ctx.Set<AnalisisComportamiento>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, AnalisisComportamiento m) {
            var e = await _ctx.Set<AnalisisComportamiento>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<AnalisisComportamiento>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<AnalisisComportamiento>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
