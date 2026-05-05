using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class TripulacionService : ITripulacionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TripulacionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TripulacionModel>> ListarTodo()
        {
            try { return await _replica.Tripulacion.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TripulacionModel: {ex.Message}"); return new List<TripulacionModel>(); }
        }

        public async Task<TripulacionModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.Tripulacion.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TripulacionModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TripulacionModel m)
        {
            _primary.Tripulacion.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, TripulacionModel m)
        {
            _primary.Tripulacion.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.Tripulacion.FindAsync(id);
            if (e == null) return false;
            _primary.Tripulacion.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
