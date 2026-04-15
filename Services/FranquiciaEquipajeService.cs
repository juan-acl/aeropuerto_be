using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
namespace Aeropuerto.Backend.Services
{
    public class FranquiciaEquipajeService : IFranquiciaEquipajeService
    {
        private readonly DBContext _ctx;
        public FranquiciaEquipajeService(DBContext ctx) => _ctx = ctx;

        public async Task<List<FranquiciaEquipajeModel>> ListarTodo()
            => await _ctx.Set<FranquiciaEquipajeModel>().ToListAsync();

        public async Task<FranquiciaEquipajeModel?> ObtenerPorId(int id)
            => await _ctx.Set<FranquiciaEquipajeModel>().FirstOrDefaultAsync(x => x.IdFranquicia == id);

        public async Task<bool> Insertar(FranquiciaEquipajeModel m)
        {
            _ctx.Set<FranquiciaEquipajeModel>().Add(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, FranquiciaEquipajeModel m)
        {
            var existing = await _ctx.Set<FranquiciaEquipajeModel>().FindAsync(id);
            if (existing == null) return false;
            _ctx.Entry(existing).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var item = await _ctx.Set<FranquiciaEquipajeModel>().FindAsync(id);
            if (item == null) return false;
            _ctx.Set<FranquiciaEquipajeModel>().Remove(item);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
