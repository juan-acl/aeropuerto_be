using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class HistorialFlujoTraficoService : IHistorialFlujoTraficoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public HistorialFlujoTraficoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<HistorialFlujoTrafico>> ListarTodo()
        {
            try { return await _replica.HistorialFlujo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo HistorialFlujoTrafico: {ex.Message}"); return new List<HistorialFlujoTrafico>(); }
        }

        public async Task<HistorialFlujoTrafico ?> ObtenerPorId(int id)
        {
            try { return await _replica.HistorialFlujo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId HistorialFlujoTrafico: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(HistorialFlujoTrafico m)
        {
            _primary.HistorialFlujo.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, HistorialFlujoTrafico m)
        {
            _primary.HistorialFlujo.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.HistorialFlujo.FindAsync(id);
            if (e == null) return false;
            _primary.HistorialFlujo.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
