using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class DiaOperacionService : IDiaOperacionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public DiaOperacionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<DiaOperacionModel>> ListarTodo()
        {
            try { return await _replica.DiasOperacion.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo DiaOperacionModel: {ex.Message}"); return new List<DiaOperacionModel>(); }
        }

        public async Task<DiaOperacionModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.DiasOperacion.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId DiaOperacionModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(DiaOperacionModel m)
        {
            _primary.DiasOperacion.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, DiaOperacionModel m)
        {
            _primary.DiasOperacion.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.DiasOperacion.FindAsync(id);
            if (e == null) return false;
            _primary.DiasOperacion.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
