using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class FrecuenciaVueloService : IFrecuenciaVueloService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public FrecuenciaVueloService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<FrecuenciaVueloModel>> ListarTodo()
        {
            try { return await _replica.FrecuenciasVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo FrecuenciaVueloModel: {ex.Message}"); return new List<FrecuenciaVueloModel>(); }
        }

        public async Task<FrecuenciaVueloModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.FrecuenciasVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId FrecuenciaVueloModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(FrecuenciaVueloModel m)
        {
            _primary.FrecuenciasVuelo.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, FrecuenciaVueloModel m)
        {
            _primary.FrecuenciasVuelo.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.FrecuenciasVuelo.FindAsync(id);
            if (e == null) return false;
            _primary.FrecuenciasVuelo.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
