using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class AvionService : IAvionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AvionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AvionModel>> ListarTodo()
        {
            try { return await _replica.Aviones.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AvionModel: {ex.Message}"); return new List<AvionModel>(); }
        }

        public async Task<AvionModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.Aviones.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AvionModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AvionModel m)
        {
            _primary.Aviones.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, AvionModel m)
        {
            _primary.Aviones.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.Aviones.FindAsync(id);
            if (e == null) return false;
            _primary.Aviones.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
