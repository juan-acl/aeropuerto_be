using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class BitacoraCambiosDbService : IBitacoraCambiosDbService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public BitacoraCambiosDbService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<BitacoraCambiosDb>> ListarTodo()
        {
            try { return await _replica.BitacoraCambios.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo BitacoraCambiosDb: {ex.Message}"); return new List<BitacoraCambiosDb>(); }
        }

        public async Task<BitacoraCambiosDb ?> ObtenerPorId(int id)
        {
            try { return await _replica.BitacoraCambios.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId BitacoraCambiosDb: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(BitacoraCambiosDb m)
        {
            _primary.BitacoraCambios.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, BitacoraCambiosDb m)
        {
            _primary.BitacoraCambios.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.BitacoraCambios.FindAsync(id);
            if (e == null) return false;
            _primary.BitacoraCambios.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
