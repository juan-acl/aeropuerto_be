using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
namespace Aeropuerto.Backend.Services
{
    public class HangarService : IHangarService
    {
        private readonly DBContext _ctx;
        public HangarService(DBContext ctx) => _ctx = ctx;

        public async Task<List<HangarModel>> ListarTodo()
            => await _ctx.Set<HangarModel>().ToListAsync();

        public async Task<HangarModel?> ObtenerPorId(int id)
            => await _ctx.Set<HangarModel>().FirstOrDefaultAsync(x => x.IdHangar == id);

        public async Task<bool> Insertar(HangarModel m)
        {
            _ctx.Set<HangarModel>().Add(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, HangarModel m)
        {
            var existing = await _ctx.Set<HangarModel>().FindAsync(id);
            if (existing == null) return false;
            _ctx.Entry(existing).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var item = await _ctx.Set<HangarModel>().FindAsync(id);
            if (item == null) return false;
            _ctx.Set<HangarModel>().Remove(item);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
