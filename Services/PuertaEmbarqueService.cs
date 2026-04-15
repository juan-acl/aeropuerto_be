using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
namespace Aeropuerto.Backend.Services
{
    public class PuertaEmbarqueService : IPuertaEmbarqueService
    {
        private readonly DBContext _ctx;
        public PuertaEmbarqueService(DBContext ctx) => _ctx = ctx;

        public async Task<List<PuertaEmbarqueModel>> ListarTodo()
            => await _ctx.Set<PuertaEmbarqueModel>().ToListAsync();

        public async Task<PuertaEmbarqueModel?> ObtenerPorId(int id)
            => await _ctx.Set<PuertaEmbarqueModel>().FirstOrDefaultAsync(x => x.IdPuerta == id);

        public async Task<bool> Insertar(PuertaEmbarqueModel m)
        {
            _ctx.Set<PuertaEmbarqueModel>().Add(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, PuertaEmbarqueModel m)
        {
            var existing = await _ctx.Set<PuertaEmbarqueModel>().FindAsync(id);
            if (existing == null) return false;
            _ctx.Entry(existing).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var item = await _ctx.Set<PuertaEmbarqueModel>().FindAsync(id);
            if (item == null) return false;
            _ctx.Set<PuertaEmbarqueModel>().Remove(item);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
