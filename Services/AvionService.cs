using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
namespace Aeropuerto.Backend.Services
{
    public class AvionService : IAvionService
    {
        private readonly DBContext _ctx;
        public AvionService(DBContext ctx) => _ctx = ctx;

        public async Task<List<AvionModel>> ListarTodo()
            => await _ctx.Set<AvionModel>().ToListAsync();

        public async Task<AvionModel?> ObtenerPorId(string id)
            => await _ctx.Set<AvionModel>().FirstOrDefaultAsync(x => x.MatriculaAvion == id);

        public async Task<bool> Insertar(AvionModel m)
        {
            _ctx.Set<AvionModel>().Add(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(string id, AvionModel m)
        {
            var existing = await _ctx.Set<AvionModel>().FindAsync(id);
            if (existing == null) return false;
            _ctx.Entry(existing).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(string id)
        {
            var item = await _ctx.Set<AvionModel>().FindAsync(id);
            if (item == null) return false;
            _ctx.Set<AvionModel>().Remove(item);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
