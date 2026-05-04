using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class ProgramaVueloService : IProgramaVueloService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ProgramaVueloService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ProgramaVueloModel>> ListarTodo()
        {
            try { return await _replica.ProgramasVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ProgramaVueloModel: {ex.Message}"); return new List<ProgramaVueloModel>(); }
        }

        public async Task<ProgramaVueloModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.ProgramasVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ProgramaVueloModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ProgramaVueloModel m)
        {
            _primary.ProgramasVuelo.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, ProgramaVueloModel m)
        {
            _primary.ProgramasVuelo.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.ProgramasVuelo.FindAsync(id);
            if (e == null) return false;
            _primary.ProgramasVuelo.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
