using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class AerolineaService : IAerolineaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AerolineaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AerolineaModel>> ListarTodo()
        {
            try { return await _replica.Aerolineas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AerolineaModel: {ex.Message}"); return new List<AerolineaModel>(); }
        }

        public async Task<AerolineaModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.Aerolineas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AerolineaModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AerolineaModel m)
        {
            _primary.Aerolineas.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, AerolineaModel m)
        {
            _primary.Aerolineas.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.Aerolineas.FindAsync(id);
            if (e == null) return false;
            _primary.Aerolineas.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
