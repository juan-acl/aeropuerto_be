using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class BitacoraCambiosDbService : IBitacoraCambiosDbService
    {
        private readonly DBContext _ctx;
        public BitacoraCambiosDbService(DBContext ctx) => _ctx = ctx;
        public async Task<List<BitacoraCambiosDb>> ListarTodo() => await _ctx.Set<BitacoraCambiosDb>().ToListAsync();
        public async Task<BitacoraCambiosDb?> ObtenerPorId(int id) => await _ctx.Set<BitacoraCambiosDb>().FindAsync(id);
        public async Task<bool> Insertar(BitacoraCambiosDb m) { _ctx.Set<BitacoraCambiosDb>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, BitacoraCambiosDb m) {
            var e = await _ctx.Set<BitacoraCambiosDb>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<BitacoraCambiosDb>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<BitacoraCambiosDb>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
