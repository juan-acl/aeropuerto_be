using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
namespace Aeropuerto.Backend.Services
{
    public class FrecuenciaVueloService : IFrecuenciaVueloService
    {
        private readonly DBContext _ctx;
        public FrecuenciaVueloService(DBContext ctx) => _ctx = ctx;

        public async Task<List<FrecuenciaVueloModel>> ListarTodo()
            => await _ctx.Set<FrecuenciaVueloModel>().ToListAsync();

        public async Task<FrecuenciaVueloModel?> ObtenerPorId(int id)
            => await _ctx.Set<FrecuenciaVueloModel>().FirstOrDefaultAsync(x => x.IdFrecuencia == id);

        public async Task<bool> Insertar(FrecuenciaVueloModel m)
        {
            _ctx.Set<FrecuenciaVueloModel>().Add(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, FrecuenciaVueloModel m)
        {
            var existing = await _ctx.Set<FrecuenciaVueloModel>().FindAsync(id);
            if (existing == null) return false;
            _ctx.Entry(existing).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var item = await _ctx.Set<FrecuenciaVueloModel>().FindAsync(id);
            if (item == null) return false;
            _ctx.Set<FrecuenciaVueloModel>().Remove(item);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
