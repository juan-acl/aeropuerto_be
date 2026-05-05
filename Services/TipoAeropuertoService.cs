using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class TipoAeropuertoService : ITipoAeropuertoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TipoAeropuertoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TipoAeropuertoModel>> ListarTodo()
        {
            try { return await _replica.TiposAeropuerto.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TipoAeropuertoModel: {ex.Message}"); return new List<TipoAeropuertoModel>(); }
        }

        public async Task<TipoAeropuertoModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.TiposAeropuerto.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TipoAeropuertoModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TipoAeropuertoModel m)
        {
            _primary.TiposAeropuerto.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, TipoAeropuertoModel m)
        {
            _primary.TiposAeropuerto.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.TiposAeropuerto.FindAsync(id);
            if (e == null) return false;
            _primary.TiposAeropuerto.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
