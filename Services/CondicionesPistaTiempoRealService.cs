using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class CondicionesPistaTiempoRealService : ICondicionesPistaTiempoRealService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CondicionesPistaTiempoRealService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CondicionesPistaTiempoReal>> ListarTodo()
        {
            try { return await _replica.CondicionesPista.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CondicionesPistaTiempoReal: {ex.Message}"); return new List<CondicionesPistaTiempoReal>(); }
        }

        public async Task<CondicionesPistaTiempoReal ?> ObtenerPorId(int id)
        {
            try { return await _replica.CondicionesPista.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CondicionesPistaTiempoReal: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CondicionesPistaTiempoReal m)
        {
            _primary.CondicionesPista.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, CondicionesPistaTiempoReal m)
        {
            _primary.CondicionesPista.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.CondicionesPista.FindAsync(id);
            if (e == null) return false;
            _primary.CondicionesPista.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
