using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class ModeloAvionService : IModeloAvionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ModeloAvionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ModeloAvionModel>> ListarTodo()
        {
            try { return await _replica.ModelosAviones.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ModeloAvionModel: {ex.Message}"); return new List<ModeloAvionModel>(); }
        }

        public async Task<ModeloAvionModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.ModelosAviones.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ModeloAvionModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ModeloAvionModel m)
        {
            _primary.ModelosAviones.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, ModeloAvionModel m)
        {
            _primary.ModelosAviones.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.ModelosAviones.FindAsync(id);
            if (e == null) return false;
            _primary.ModelosAviones.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
