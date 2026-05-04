using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class FabricanteAvionService : IFabricanteAvionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public FabricanteAvionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<FabricanteAvionModel>> ListarTodo()
        {
            try { return await _replica.FabricantesAviones.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo FabricanteAvionModel: {ex.Message}"); return new List<FabricanteAvionModel>(); }
        }

        public async Task<FabricanteAvionModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.FabricantesAviones.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId FabricanteAvionModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(FabricanteAvionModel m)
        {
            _primary.FabricantesAviones.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, FabricanteAvionModel m)
        {
            _primary.FabricantesAviones.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.FabricantesAviones.FindAsync(id);
            if (e == null) return false;
            _primary.FabricantesAviones.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
