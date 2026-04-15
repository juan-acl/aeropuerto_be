using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
namespace Aeropuerto.Backend.Services
{
    public class IncidenteVueloService : IIncidenteVueloService
    {
        private readonly DBContext _ctx;
        public IncidenteVueloService(DBContext ctx) => _ctx = ctx;

        public async Task<List<IncidenteVueloModel>> ListarTodo()
            => await _ctx.Set<IncidenteVueloModel>().ToListAsync();

        public async Task<IncidenteVueloModel?> ObtenerPorId(int id)
            => await _ctx.Set<IncidenteVueloModel>().FirstOrDefaultAsync(x => x.IdIncidenteVuelo == id);

        public async Task<bool> Insertar(IncidenteVueloModel m)
        {
            _ctx.Set<IncidenteVueloModel>().Add(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, IncidenteVueloModel m)
        {
            var existing = await _ctx.Set<IncidenteVueloModel>().FindAsync(id);
            if (existing == null) return false;
            _ctx.Entry(existing).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var item = await _ctx.Set<IncidenteVueloModel>().FindAsync(id);
            if (item == null) return false;
            _ctx.Set<IncidenteVueloModel>().Remove(item);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
