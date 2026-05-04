using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class TarifaVueloService : ITarifaVueloService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TarifaVueloService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TarifaVueloModel>> ListarTodo()
        {
            try { return await _replica.TarifasVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TarifaVueloModel: {ex.Message}"); return new List<TarifaVueloModel>(); }
        }

        public async Task<TarifaVueloModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.TarifasVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TarifaVueloModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TarifaVueloModel m)
        {
            _primary.TarifasVuelo.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, TarifaVueloModel m)
        {
            _primary.TarifasVuelo.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.TarifasVuelo.FindAsync(id);
            if (e == null) return false;
            _primary.TarifasVuelo.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
