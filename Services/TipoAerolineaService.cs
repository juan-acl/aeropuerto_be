using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class TipoAerolineaService : ITipoAerolineaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TipoAerolineaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TipoAerolineaModel>> ListarTodo()
        {
            try { return await _replica.TiposAerolinea.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TipoAerolineaModel: {ex.Message}"); return new List<TipoAerolineaModel>(); }
        }

        public async Task<TipoAerolineaModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.TiposAerolinea.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TipoAerolineaModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TipoAerolineaModel m)
        {
            _primary.TiposAerolinea.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, TipoAerolineaModel m)
        {
            _primary.TiposAerolinea.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.TiposAerolinea.FindAsync(id);
            if (e == null) return false;
            _primary.TiposAerolinea.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
