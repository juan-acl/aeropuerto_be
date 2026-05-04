using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class PasajerosSegmentosService : IPasajerosSegmentosService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PasajerosSegmentosService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PasajerosSegmentos>> ListarTodo()
        {
            try { return await _replica.PasajerosSegmentos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PasajerosSegmentos: {ex.Message}"); return new List<PasajerosSegmentos>(); }
        }

        public async Task<PasajerosSegmentos ?> ObtenerPorId(int id)
        {
            try { return await _replica.PasajerosSegmentos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PasajerosSegmentos: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PasajerosSegmentos m)
        {
            _primary.PasajerosSegmentos.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, PasajerosSegmentos m)
        {
            _primary.PasajerosSegmentos.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.PasajerosSegmentos.FindAsync(id);
            if (e == null) return false;
            _primary.PasajerosSegmentos.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
