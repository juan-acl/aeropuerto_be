using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
namespace Aeropuerto.Backend.Services
{
    public class TripulacionVueloService : ITripulacionVueloService
    {
        private readonly DBContext _ctx;
        public TripulacionVueloService(DBContext ctx) => _ctx = ctx;

        public async Task<List<TripulacionVueloModel>> ListarTodo()
            => await _ctx.Set<TripulacionVueloModel>().ToListAsync();

        public async Task<TripulacionVueloModel?> ObtenerPorId(int id)
            => await _ctx.Set<TripulacionVueloModel>().FirstOrDefaultAsync(x => x.IdAsignacion == id);

        public async Task<bool> Insertar(TripulacionVueloModel m)
        {
            _ctx.Set<TripulacionVueloModel>().Add(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, TripulacionVueloModel m)
        {
            var existing = await _ctx.Set<TripulacionVueloModel>().FindAsync(id);
            if (existing == null) return false;
            _ctx.Entry(existing).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var item = await _ctx.Set<TripulacionVueloModel>().FindAsync(id);
            if (item == null) return false;
            _ctx.Set<TripulacionVueloModel>().Remove(item);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
