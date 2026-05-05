using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class GruposPasajerosService : IGruposPasajerosService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public GruposPasajerosService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<GruposPasajerosModel>> ListarTodo()
        {
            try { return await _replica.GruposPasajeros.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo GruposPasajerosModel: {ex.Message}"); return new List<GruposPasajerosModel>(); }
        }

        public async Task<GruposPasajerosModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.GruposPasajeros.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId GruposPasajerosModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(GruposPasajerosModel m)
        {
            _primary.GruposPasajeros.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, GruposPasajerosModel m)
        {
            _primary.GruposPasajeros.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.GruposPasajeros.FindAsync(id);
            if (e == null) return false;
            _primary.GruposPasajeros.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
