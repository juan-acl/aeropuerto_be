using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class CondicionMeteorologicaService : ICondicionMeteorologicaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CondicionMeteorologicaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CondicionMeteorologicaModel>> ListarTodo()
        {
            try { return await _replica.CondicionesMeteorologicas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CondicionMeteorologicaModel: {ex.Message}"); return new List<CondicionMeteorologicaModel>(); }
        }

        public async Task<CondicionMeteorologicaModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.CondicionesMeteorologicas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CondicionMeteorologicaModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CondicionMeteorologicaModel m)
        {
            _primary.CondicionesMeteorologicas.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, CondicionMeteorologicaModel m)
        {
            _primary.CondicionesMeteorologicas.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.CondicionesMeteorologicas.FindAsync(id);
            if (e == null) return false;
            _primary.CondicionesMeteorologicas.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
