using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
namespace Aeropuerto.Backend.Services
{
    public class CondicionMeteorologicaService : ICondicionMeteorologicaService
    {
        private readonly DBContext _ctx;
        public CondicionMeteorologicaService(DBContext ctx) => _ctx = ctx;

        public async Task<List<CondicionMeteorologicaModel>> ListarTodo()
            => await _ctx.Set<CondicionMeteorologicaModel>().ToListAsync();

        public async Task<CondicionMeteorologicaModel?> ObtenerPorId(int id)
            => await _ctx.Set<CondicionMeteorologicaModel>().FirstOrDefaultAsync(x => x.IdCondicion == id);

        public async Task<bool> Insertar(CondicionMeteorologicaModel m)
        {
            _ctx.Set<CondicionMeteorologicaModel>().Add(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, CondicionMeteorologicaModel m)
        {
            var existing = await _ctx.Set<CondicionMeteorologicaModel>().FindAsync(id);
            if (existing == null) return false;
            _ctx.Entry(existing).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var item = await _ctx.Set<CondicionMeteorologicaModel>().FindAsync(id);
            if (item == null) return false;
            _ctx.Set<CondicionMeteorologicaModel>().Remove(item);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
