using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
namespace Aeropuerto.Backend.Services
{
    public class TerminalAeropuertoService : ITerminalAeropuertoService
    {
        private readonly DBContext _ctx;
        public TerminalAeropuertoService(DBContext ctx) => _ctx = ctx;

        public async Task<List<TerminalAeropuertoModel>> ListarTodo()
            => await _ctx.Set<TerminalAeropuertoModel>().ToListAsync();

        public async Task<TerminalAeropuertoModel?> ObtenerPorId(int id)
            => await _ctx.Set<TerminalAeropuertoModel>().FirstOrDefaultAsync(x => x.IdTerminal == id);

        public async Task<bool> Insertar(TerminalAeropuertoModel m)
        {
            _ctx.Set<TerminalAeropuertoModel>().Add(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, TerminalAeropuertoModel m)
        {
            var existing = await _ctx.Set<TerminalAeropuertoModel>().FindAsync(id);
            if (existing == null) return false;
            _ctx.Entry(existing).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var item = await _ctx.Set<TerminalAeropuertoModel>().FindAsync(id);
            if (item == null) return false;
            _ctx.Set<TerminalAeropuertoModel>().Remove(item);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
