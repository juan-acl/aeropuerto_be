using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class PistaAterrizajeService : IPistaAterrizajeService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PistaAterrizajeService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PistaAterrizajeModel>> ListarTodo()
        {
            try { return await _replica.PistasAterrizaje.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PistaAterrizajeModel: {ex.Message}"); return new List<PistaAterrizajeModel>(); }
        }

        public async Task<PistaAterrizajeModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.PistasAterrizaje.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PistaAterrizajeModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PistaAterrizajeModel m)
        {
            _primary.PistasAterrizaje.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, PistaAterrizajeModel m)
        {
            _primary.PistasAterrizaje.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.PistasAterrizaje.FindAsync(id);
            if (e == null) return false;
            _primary.PistasAterrizaje.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
