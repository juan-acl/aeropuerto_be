using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class CapacidadTerminalTiempoRealService : ICapacidadTerminalTiempoRealService
    {
        private readonly DBContext _ctx;
        public CapacidadTerminalTiempoRealService(DBContext ctx) => _ctx = ctx;
        public async Task<List<CapacidadTerminalTiempoReal>> ListarTodo() => await _ctx.Set<CapacidadTerminalTiempoReal>().ToListAsync();
        public async Task<CapacidadTerminalTiempoReal?> ObtenerPorId(int id) => await _ctx.Set<CapacidadTerminalTiempoReal>().FindAsync(id);
        public async Task<bool> Insertar(CapacidadTerminalTiempoReal m) { _ctx.Set<CapacidadTerminalTiempoReal>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, CapacidadTerminalTiempoReal m) {
            var e = await _ctx.Set<CapacidadTerminalTiempoReal>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<CapacidadTerminalTiempoReal>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<CapacidadTerminalTiempoReal>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
