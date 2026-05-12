using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class PasajeroService : IPasajeroService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PasajeroService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PasajeroModel>> ListarTodo()
        {
            try { return await _replica.Pasajeros.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PasajeroModel: {ex.Message}"); return new List<PasajeroModel>(); }
        }

        public async Task<PasajeroModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.Pasajeros.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PasajeroModel: {ex.Message}"); return null; }
        }

        public async Task<PasajeroModel ?> ObtenerPorEmail(string email)
        {
            try { return await _replica.Pasajeros.FirstOrDefaultAsync(p => p.Email != null && p.Email.ToLower() == email.ToLower()); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorEmail PasajeroModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PasajeroModel m)
        {
            _primary.Pasajeros.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, PasajeroModel m)
        {
            _primary.Pasajeros.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.Pasajeros.FindAsync(id);
            if (e == null) return false;
            _primary.Pasajeros.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
