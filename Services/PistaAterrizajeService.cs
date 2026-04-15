using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
namespace Aeropuerto.Backend.Services
{
    public class PistaAterrizajeService : IPistaAterrizajeService
    {
        private readonly DBContext _ctx;
        public PistaAterrizajeService(DBContext ctx) => _ctx = ctx;

        public async Task<List<PistaAterrizajeModel>> ListarTodo()
            => await _ctx.Set<PistaAterrizajeModel>().ToListAsync();

        public async Task<PistaAterrizajeModel?> ObtenerPorId(int id)
            => await _ctx.Set<PistaAterrizajeModel>().FirstOrDefaultAsync(x => x.IdPista == id);

        public async Task<bool> Insertar(PistaAterrizajeModel m)
        {
            _ctx.Set<PistaAterrizajeModel>().Add(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, PistaAterrizajeModel m)
        {
            var existing = await _ctx.Set<PistaAterrizajeModel>().FindAsync(id);
            if (existing == null) return false;
            _ctx.Entry(existing).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var item = await _ctx.Set<PistaAterrizajeModel>().FindAsync(id);
            if (item == null) return false;
            _ctx.Set<PistaAterrizajeModel>().Remove(item);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
