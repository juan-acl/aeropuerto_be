using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
namespace Aeropuerto.Backend.Services
{
    public class RetrasoVueloService : IRetrasoVueloService
    {
        private readonly DBContext _ctx;
        public RetrasoVueloService(DBContext ctx) => _ctx = ctx;

        public async Task<List<RetrasoVueloModel>> ListarTodo()
            => await _ctx.Set<RetrasoVueloModel>().ToListAsync();

        public async Task<RetrasoVueloModel?> ObtenerPorId(int id)
            => await _ctx.Set<RetrasoVueloModel>().FirstOrDefaultAsync(x => x.IdRetraso == id);

        public async Task<bool> Insertar(RetrasoVueloModel m)
        {
            _ctx.Set<RetrasoVueloModel>().Add(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, RetrasoVueloModel m)
        {
            var existing = await _ctx.Set<RetrasoVueloModel>().FindAsync(id);
            if (existing == null) return false;
            _ctx.Entry(existing).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var item = await _ctx.Set<RetrasoVueloModel>().FindAsync(id);
            if (item == null) return false;
            _ctx.Set<RetrasoVueloModel>().Remove(item);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
