using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class AccesosAreasRestringidasService : IAccesosAreasRestringidasService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AccesosAreasRestringidasService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AccesosAreasRestringidasModel>> ListarTodo()
        {
            try { return await _replica.AccesosAreasRestringidas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AccesosAreasRestringidasModel: {ex.Message}"); return new List<AccesosAreasRestringidasModel>(); }
        }

        public async Task<AccesosAreasRestringidasModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.AccesosAreasRestringidas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AccesosAreasRestringidasModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AccesosAreasRestringidasModel m)
        {
            _primary.AccesosAreasRestringidas.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, AccesosAreasRestringidasModel m)
        {
            _primary.AccesosAreasRestringidas.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.AccesosAreasRestringidas.FindAsync(id);
            if (e == null) return false;
            _primary.AccesosAreasRestringidas.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
