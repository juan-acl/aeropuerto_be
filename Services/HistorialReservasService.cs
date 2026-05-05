using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class HistorialReservasService : IHistorialReservasService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public HistorialReservasService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<HistorialReservasModel>> ListarTodo()
        {
            try { return await _replica.HistorialReservas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo HistorialReservasModel: {ex.Message}"); return new List<HistorialReservasModel>(); }
        }

        public async Task<HistorialReservasModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.HistorialReservas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId HistorialReservasModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(HistorialReservasModel m)
        {
            _primary.HistorialReservas.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, HistorialReservasModel m)
        {
            _primary.HistorialReservas.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.HistorialReservas.FindAsync(id);
            if (e == null) return false;
            _primary.HistorialReservas.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
