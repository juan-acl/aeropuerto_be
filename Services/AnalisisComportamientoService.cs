using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class AnalisisComportamientoService : IAnalisisComportamientoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AnalisisComportamientoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AnalisisComportamiento>> ListarTodo()
        {
            try { return await _replica.AnalisisComportamiento.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AnalisisComportamiento: {ex.Message}"); return new List<AnalisisComportamiento>(); }
        }

        public async Task<AnalisisComportamiento ?> ObtenerPorId(int id)
        {
            try { return await _replica.AnalisisComportamiento.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AnalisisComportamiento: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AnalisisComportamiento m)
        {
            _primary.AnalisisComportamiento.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, AnalisisComportamiento m)
        {
            _primary.AnalisisComportamiento.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.AnalisisComportamiento.FindAsync(id);
            if (e == null) return false;
            _primary.AnalisisComportamiento.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
