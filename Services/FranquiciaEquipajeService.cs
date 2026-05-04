using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class FranquiciaEquipajeService : IFranquiciaEquipajeService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public FranquiciaEquipajeService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<FranquiciaEquipajeModel>> ListarTodo()
        {
            try { return await _replica.FranquiciasEquipaje.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo FranquiciaEquipajeModel: {ex.Message}"); return new List<FranquiciaEquipajeModel>(); }
        }

        public async Task<FranquiciaEquipajeModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.FranquiciasEquipaje.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId FranquiciaEquipajeModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(FranquiciaEquipajeModel m)
        {
            _primary.FranquiciasEquipaje.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, FranquiciaEquipajeModel m)
        {
            _primary.FranquiciasEquipaje.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.FranquiciasEquipaje.FindAsync(id);
            if (e == null) return false;
            _primary.FranquiciasEquipaje.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
