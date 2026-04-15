using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class PosicionRadarService : IPosicionRadarService
    {
        private readonly DBContext _ctx;
        public PosicionRadarService(DBContext ctx) => _ctx = ctx;
        public async Task<List<PosicionesRadar>> ListarTodo() => await _ctx.Set<PosicionesRadar>().ToListAsync();
        public async Task<PosicionesRadar?> ObtenerPorId(int id) => await _ctx.Set<PosicionesRadar>().FindAsync(id);
        public async Task<bool> Insertar(PosicionesRadar m) { _ctx.Set<PosicionesRadar>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, PosicionesRadar m) {
            var e = await _ctx.Set<PosicionesRadar>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<PosicionesRadar>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<PosicionesRadar>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
