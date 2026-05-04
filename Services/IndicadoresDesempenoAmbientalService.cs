using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class IndicadoresDesempenoAmbientalService : IIndicadoresDesempenoAmbientalService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public IndicadoresDesempenoAmbientalService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<IndicadoresDesempenoAmbiental>> ListarTodo()
        {
            try { return await _replica.IndicadoresDesempenoAmbiental.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo IndicadoresDesempenoAmbiental: {ex.Message}"); return new List<IndicadoresDesempenoAmbiental>(); }
        }

        public async Task<IndicadoresDesempenoAmbiental ?> ObtenerPorId(int id)
        {
            try { return await _replica.IndicadoresDesempenoAmbiental.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId IndicadoresDesempenoAmbiental: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(IndicadoresDesempenoAmbiental m)
        {
            _primary.IndicadoresDesempenoAmbiental.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, IndicadoresDesempenoAmbiental m)
        {
            _primary.IndicadoresDesempenoAmbiental.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.IndicadoresDesempenoAmbiental.FindAsync(id);
            if (e == null) return false;
            _primary.IndicadoresDesempenoAmbiental.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
