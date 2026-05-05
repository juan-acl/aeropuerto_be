using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class AlianzaAerolineaService : IAlianzaAerolineaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AlianzaAerolineaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AlianzaAerolineaModel>> ListarTodo()
        {
            try { return await _replica.AlianzasAerolineas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AlianzaAerolineaModel: {ex.Message}"); return new List<AlianzaAerolineaModel>(); }
        }

        public async Task<AlianzaAerolineaModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.AlianzasAerolineas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AlianzaAerolineaModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AlianzaAerolineaModel m)
        {
            _primary.AlianzasAerolineas.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, AlianzaAerolineaModel m)
        {
            _primary.AlianzasAerolineas.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.AlianzasAerolineas.FindAsync(id);
            if (e == null) return false;
            _primary.AlianzasAerolineas.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
