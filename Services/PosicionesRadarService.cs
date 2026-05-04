using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class PosicionesRadarService : IPosicionesRadarService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PosicionesRadarService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PosicionesRadar>> ListarTodo()
        {
            try { return await _replica.PosicionesRadar.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PosicionesRadar: {ex.Message}"); return new List<PosicionesRadar>(); }
        }

        public async Task<PosicionesRadar ?> ObtenerPorId(int id)
        {
            try { return await _replica.PosicionesRadar.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PosicionesRadar: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PosicionesRadar m)
        {
            _primary.PosicionesRadar.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, PosicionesRadar m)
        {
            _primary.PosicionesRadar.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.PosicionesRadar.FindAsync(id);
            if (e == null) return false;
            _primary.PosicionesRadar.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
