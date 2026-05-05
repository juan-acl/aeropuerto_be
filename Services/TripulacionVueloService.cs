using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class TripulacionVueloService : ITripulacionVueloService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TripulacionVueloService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TripulacionVueloModel>> ListarTodo()
        {
            try { return await _replica.TripulacionVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TripulacionVueloModel: {ex.Message}"); return new List<TripulacionVueloModel>(); }
        }

        public async Task<TripulacionVueloModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.TripulacionVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TripulacionVueloModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TripulacionVueloModel m)
        {
            _primary.TripulacionVuelo.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, TripulacionVueloModel m)
        {
            _primary.TripulacionVuelo.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.TripulacionVuelo.FindAsync(id);
            if (e == null) return false;
            _primary.TripulacionVuelo.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
