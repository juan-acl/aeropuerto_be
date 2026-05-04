using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class EstandaresInternacionalesService : IEstandaresInternacionalesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public EstandaresInternacionalesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<EstandaresInternacionales>> ListarTodo()
        {
            try { return await _replica.EstandaresInternacionales.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EstandaresInternacionales: {ex.Message}"); return new List<EstandaresInternacionales>(); }
        }

        public async Task<EstandaresInternacionales ?> ObtenerPorId(int id)
        {
            try { return await _replica.EstandaresInternacionales.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EstandaresInternacionales: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EstandaresInternacionales m)
        {
            _primary.EstandaresInternacionales.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, EstandaresInternacionales m)
        {
            _primary.EstandaresInternacionales.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.EstandaresInternacionales.FindAsync(id);
            if (e == null) return false;
            _primary.EstandaresInternacionales.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
