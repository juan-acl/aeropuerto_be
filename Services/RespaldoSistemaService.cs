using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class RespaldoSistemaService : IRespaldoSistemaService
    {
        private readonly DBContext _ctx;
        public RespaldoSistemaService(DBContext ctx) => _ctx = ctx;
        public async Task<List<RespaldosSistema>> ListarTodo() => await _ctx.Set<RespaldosSistema>().ToListAsync();
        public async Task<RespaldosSistema?> ObtenerPorId(int id) => await _ctx.Set<RespaldosSistema>().FindAsync(id);
        public async Task<bool> Insertar(RespaldosSistema m) { _ctx.Set<RespaldosSistema>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, RespaldosSistema m) {
            var e = await _ctx.Set<RespaldosSistema>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<RespaldosSistema>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<RespaldosSistema>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
