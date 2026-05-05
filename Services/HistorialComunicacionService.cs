using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class HistorialComunicacionService : IHistorialComunicacionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public HistorialComunicacionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<HistorialComunicacionModel>> ListarTodo()
        {
            try { return await _replica.HistorialComunicacion.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo HistorialComunicacionModel: {ex.Message}"); return new List<HistorialComunicacionModel>(); }
        }

        public async Task<HistorialComunicacionModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.HistorialComunicacion.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId HistorialComunicacionModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(HistorialComunicacionModel m)
        {
            _primary.HistorialComunicacion.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, HistorialComunicacionModel m)
        {
            _primary.HistorialComunicacion.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.HistorialComunicacion.FindAsync(id);
            if (e == null) return false;
            _primary.HistorialComunicacion.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
