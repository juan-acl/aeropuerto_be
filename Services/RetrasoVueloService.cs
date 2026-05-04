using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class RetrasoVueloService : IRetrasoVueloService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public RetrasoVueloService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<RetrasoVueloModel>> ListarTodo()
        {
            try { return await _replica.RetrasosVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo RetrasoVueloModel: {ex.Message}"); return new List<RetrasoVueloModel>(); }
        }

        public async Task<RetrasoVueloModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.RetrasosVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId RetrasoVueloModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(RetrasoVueloModel m)
        {
            _primary.RetrasosVuelo.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, RetrasoVueloModel m)
        {
            _primary.RetrasosVuelo.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.RetrasosVuelo.FindAsync(id);
            if (e == null) return false;
            _primary.RetrasosVuelo.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
