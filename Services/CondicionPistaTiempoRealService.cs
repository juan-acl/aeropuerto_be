using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class CondicionPistaTiempoRealService : ICondicionPistaTiempoRealService
    {
        private readonly DBContext _ctx;
        public CondicionPistaTiempoRealService(DBContext ctx) => _ctx = ctx;
        public async Task<List<CondicionesPistaTiempoReal>> ListarTodo() => await _ctx.Set<CondicionesPistaTiempoReal>().ToListAsync();
        public async Task<CondicionesPistaTiempoReal?> ObtenerPorId(int id) => await _ctx.Set<CondicionesPistaTiempoReal>().FindAsync(id);
        public async Task<bool> Insertar(CondicionesPistaTiempoReal m) { _ctx.Set<CondicionesPistaTiempoReal>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, CondicionesPistaTiempoReal m) {
            var e = await _ctx.Set<CondicionesPistaTiempoReal>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<CondicionesPistaTiempoReal>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<CondicionesPistaTiempoReal>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
