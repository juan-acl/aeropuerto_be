using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class CodigosOaciPaisesService : ICodigosOaciPaisesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CodigosOaciPaisesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CodigosOaciPaises>> ListarTodo()
        {
            try { return await _replica.CodigosOaci.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CodigosOaciPaises: {ex.Message}"); return new List<CodigosOaciPaises>(); }
        }

        public async Task<CodigosOaciPaises ?> ObtenerPorId(int id)
        {
            try { return await _replica.CodigosOaci.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CodigosOaciPaises: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CodigosOaciPaises m)
        {
            _primary.CodigosOaci.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, CodigosOaciPaises m)
        {
            _primary.CodigosOaci.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.CodigosOaci.FindAsync(id);
            if (e == null) return false;
            _primary.CodigosOaci.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
