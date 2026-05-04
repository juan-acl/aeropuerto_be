using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class CapacidadTerminalTiempoRealService : ICapacidadTerminalTiempoRealService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CapacidadTerminalTiempoRealService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CapacidadTerminalTiempoReal>> ListarTodo()
        {
            try { return await _replica.CapacidadTerminal.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CapacidadTerminalTiempoReal: {ex.Message}"); return new List<CapacidadTerminalTiempoReal>(); }
        }

        public async Task<CapacidadTerminalTiempoReal ?> ObtenerPorId(int id)
        {
            try { return await _replica.CapacidadTerminal.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CapacidadTerminalTiempoReal: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CapacidadTerminalTiempoReal m)
        {
            _primary.CapacidadTerminal.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, CapacidadTerminalTiempoReal m)
        {
            _primary.CapacidadTerminal.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.CapacidadTerminal.FindAsync(id);
            if (e == null) return false;
            _primary.CapacidadTerminal.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
