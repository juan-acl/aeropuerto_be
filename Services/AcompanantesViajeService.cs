using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class AcompanantesViajeService : IAcompanantesViajeService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AcompanantesViajeService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AcompanantesViajeModel>> ListarTodo()
        {
            try { return await _replica.AcompanantesViaje.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AcompanantesViajeModel: {ex.Message}"); return new List<AcompanantesViajeModel>(); }
        }

        public async Task<AcompanantesViajeModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.AcompanantesViaje.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AcompanantesViajeModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AcompanantesViajeModel m)
        {
            _primary.AcompanantesViaje.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, AcompanantesViajeModel m)
        {
            _primary.AcompanantesViaje.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.AcompanantesViaje.FindAsync(id);
            if (e == null) return false;
            _primary.AcompanantesViaje.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
