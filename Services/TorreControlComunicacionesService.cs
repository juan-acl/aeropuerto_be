using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class TorreControlComunicacionesService : ITorreControlComunicacionesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TorreControlComunicacionesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TorreControlComunicaciones>> ListarTodo()
        {
            try { return await _replica.TorreControl.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TorreControlComunicaciones: {ex.Message}"); return new List<TorreControlComunicaciones>(); }
        }

        public async Task<TorreControlComunicaciones ?> ObtenerPorId(int id)
        {
            try { return await _replica.TorreControl.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TorreControlComunicaciones: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TorreControlComunicaciones m)
        {
            _primary.TorreControl.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, TorreControlComunicaciones m)
        {
            _primary.TorreControl.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.TorreControl.FindAsync(id);
            if (e == null) return false;
            _primary.TorreControl.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
