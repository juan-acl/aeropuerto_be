using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class LogAccesoSistemaService : ILogAccesoSistemaService
    {
        private readonly DBContext _ctx;
        public LogAccesoSistemaService(DBContext ctx) => _ctx = ctx;
        public async Task<List<LogsAccesoSistema>> ListarTodo() => await _ctx.Set<LogsAccesoSistema>().ToListAsync();
        public async Task<LogsAccesoSistema?> ObtenerPorId(int id) => await _ctx.Set<LogsAccesoSistema>().FindAsync(id);
        public async Task<bool> Insertar(LogsAccesoSistema m) { _ctx.Set<LogsAccesoSistema>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, LogsAccesoSistema m) {
            var e = await _ctx.Set<LogsAccesoSistema>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<LogsAccesoSistema>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<LogsAccesoSistema>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
