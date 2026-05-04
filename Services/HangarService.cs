using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class HangarService : IHangarService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public HangarService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<HangarModel>> ListarTodo()
        {
            try { return await _replica.Hangares.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo HangarModel: {ex.Message}"); return new List<HangarModel>(); }
        }

        public async Task<HangarModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.Hangares.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId HangarModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(HangarModel m)
        {
            _primary.Hangares.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, HangarModel m)
        {
            _primary.Hangares.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.Hangares.FindAsync(id);
            if (e == null) return false;
            _primary.Hangares.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
