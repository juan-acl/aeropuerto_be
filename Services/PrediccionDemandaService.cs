using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class PrediccionDemandaService : IPrediccionDemandaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PrediccionDemandaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PrediccionDemanda>> ListarTodo()
        {
            try { return await _replica.PrediccionDemanda.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PrediccionDemanda: {ex.Message}"); return new List<PrediccionDemanda>(); }
        }

        public async Task<PrediccionDemanda ?> ObtenerPorId(int id)
        {
            try { return await _replica.PrediccionDemanda.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PrediccionDemanda: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PrediccionDemanda m)
        {
            _primary.PrediccionDemanda.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, PrediccionDemanda m)
        {
            _primary.PrediccionDemanda.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.PrediccionDemanda.FindAsync(id);
            if (e == null) return false;
            _primary.PrediccionDemanda.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
