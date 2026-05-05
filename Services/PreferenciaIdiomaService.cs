using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class PreferenciaIdiomaService : IPreferenciaIdiomaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PreferenciaIdiomaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PreferenciaIdiomaModel>> ListarTodo()
        {
            try { return await _replica.PreferenciasIdiomas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PreferenciaIdiomaModel: {ex.Message}"); return new List<PreferenciaIdiomaModel>(); }
        }

        public async Task<PreferenciaIdiomaModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.PreferenciasIdiomas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PreferenciaIdiomaModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PreferenciaIdiomaModel m)
        {
            _primary.PreferenciasIdiomas.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, PreferenciaIdiomaModel m)
        {
            _primary.PreferenciasIdiomas.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.PreferenciasIdiomas.FindAsync(id);
            if (e == null) return false;
            _primary.PreferenciasIdiomas.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
