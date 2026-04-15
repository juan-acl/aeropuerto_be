using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
namespace Aeropuerto.Backend.Services
{
    public class TarifaVueloService : ITarifaVueloService
    {
        private readonly DBContext _ctx;
        public TarifaVueloService(DBContext ctx) => _ctx = ctx;

        public async Task<List<TarifaVueloModel>> ListarTodo()
            => await _ctx.Set<TarifaVueloModel>().ToListAsync();

        public async Task<TarifaVueloModel?> ObtenerPorId(int id)
            => await _ctx.Set<TarifaVueloModel>().FirstOrDefaultAsync(x => x.IdTarifa == id);

        public async Task<bool> Insertar(TarifaVueloModel m)
        {
            _ctx.Set<TarifaVueloModel>().Add(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, TarifaVueloModel m)
        {
            var existing = await _ctx.Set<TarifaVueloModel>().FindAsync(id);
            if (existing == null) return false;
            _ctx.Entry(existing).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var item = await _ctx.Set<TarifaVueloModel>().FindAsync(id);
            if (item == null) return false;
            _ctx.Set<TarifaVueloModel>().Remove(item);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
