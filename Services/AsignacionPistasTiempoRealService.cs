using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class AsignacionPistasTiempoRealService : IAsignacionPistasTiempoRealService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AsignacionPistasTiempoRealService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AsignacionPistasTiempoReal>> ListarTodo()
        {
            try { return await _replica.AsignacionesPistas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AsignacionPistasTiempoReal: {ex.Message}"); return new List<AsignacionPistasTiempoReal>(); }
        }

        public async Task<AsignacionPistasTiempoReal ?> ObtenerPorId(int id)
        {
            try { return await _replica.AsignacionesPistas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AsignacionPistasTiempoReal: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AsignacionPistasTiempoReal m)
        {
            _primary.AsignacionesPistas.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, AsignacionPistasTiempoReal m)
        {
            _primary.AsignacionesPistas.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.AsignacionesPistas.FindAsync(id);
            if (e == null) return false;
            _primary.AsignacionesPistas.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
