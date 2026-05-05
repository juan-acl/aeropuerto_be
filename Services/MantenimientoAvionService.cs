using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class MantenimientoAvionService : IMantenimientoAvionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public MantenimientoAvionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<MantenimientoAvionModel>> ListarTodo()
        {
            try { return await _replica.MantenimientosAviones.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo MantenimientoAvionModel: {ex.Message}"); return new List<MantenimientoAvionModel>(); }
        }

        public async Task<MantenimientoAvionModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.MantenimientosAviones.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId MantenimientoAvionModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(MantenimientoAvionModel m)
        {
            _primary.MantenimientosAviones.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, MantenimientoAvionModel m)
        {
            _primary.MantenimientosAviones.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.MantenimientosAviones.FindAsync(id);
            if (e == null) return false;
            _primary.MantenimientosAviones.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
