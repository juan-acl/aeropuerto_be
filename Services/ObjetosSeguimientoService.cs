using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class ObjetosSeguimientoService : IObjetosSeguimientoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ObjetosSeguimientoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ObjetosSeguimientoModel>> ListarTodo()
        {
            try { return await _replica.ObjetosSeguimiento.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ObjetosSeguimientoModel: {ex.Message}"); return new List<ObjetosSeguimientoModel>(); }
        }

        public async Task<ObjetosSeguimientoModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.ObjetosSeguimiento.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ObjetosSeguimientoModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ObjetosSeguimientoModel m)
        {
            _primary.ObjetosSeguimiento.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, ObjetosSeguimientoModel m)
        {
            _primary.ObjetosSeguimiento.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.ObjetosSeguimiento.FindAsync(id);
            if (e == null) return false;
            _primary.ObjetosSeguimiento.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
