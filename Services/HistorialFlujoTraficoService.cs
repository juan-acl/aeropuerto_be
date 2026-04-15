using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class HistorialFlujoTraficoService : IHistorialFlujoTraficoService
    {
        private readonly DBContext _ctx;
        public HistorialFlujoTraficoService(DBContext ctx) => _ctx = ctx;
        public async Task<List<HistorialFlujoTrafico>> ListarTodo() => await _ctx.Set<HistorialFlujoTrafico>().ToListAsync();
        public async Task<HistorialFlujoTrafico?> ObtenerPorId(int id) => await _ctx.Set<HistorialFlujoTrafico>().FindAsync(id);
        public async Task<bool> Insertar(HistorialFlujoTrafico m) { _ctx.Set<HistorialFlujoTrafico>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, HistorialFlujoTrafico m) {
            var e = await _ctx.Set<HistorialFlujoTrafico>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<HistorialFlujoTrafico>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<HistorialFlujoTrafico>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
