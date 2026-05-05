using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class IncidenteVueloService : IIncidenteVueloService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public IncidenteVueloService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<IncidenteVueloModel>> ListarTodo()
        {
            try { return await _replica.IncidentesVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo IncidenteVueloModel: {ex.Message}"); return new List<IncidenteVueloModel>(); }
        }

        public async Task<IncidenteVueloModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.IncidentesVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId IncidenteVueloModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(IncidenteVueloModel m)
        {
            _primary.IncidentesVuelo.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, IncidenteVueloModel m)
        {
            _primary.IncidentesVuelo.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.IncidentesVuelo.FindAsync(id);
            if (e == null) return false;
            _primary.IncidentesVuelo.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
