using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class AeropuertoService : IAeropuertoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AeropuertoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AeropuertoModel>> ListarTodo()
        {
            try { return await _replica.Aeropuertos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AeropuertoModel: {ex.Message}"); return new List<AeropuertoModel>(); }
        }

        public async Task<AeropuertoModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.Aeropuertos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AeropuertoModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AeropuertoModel m)
        {
            _primary.Aeropuertos.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, AeropuertoModel m)
        {
            _primary.Aeropuertos.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.Aeropuertos.FindAsync(id);
            if (e == null) return false;
            _primary.Aeropuertos.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
