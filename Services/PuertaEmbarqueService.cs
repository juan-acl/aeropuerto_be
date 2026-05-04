using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class PuertaEmbarqueService : IPuertaEmbarqueService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PuertaEmbarqueService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PuertaEmbarqueModel>> ListarTodo()
        {
            try { return await _replica.PuertasEmbarque.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PuertaEmbarqueModel: {ex.Message}"); return new List<PuertaEmbarqueModel>(); }
        }

        public async Task<PuertaEmbarqueModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.PuertasEmbarque.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PuertaEmbarqueModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PuertaEmbarqueModel m)
        {
            _primary.PuertasEmbarque.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, PuertaEmbarqueModel m)
        {
            _primary.PuertasEmbarque.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.PuertasEmbarque.FindAsync(id);
            if (e == null) return false;
            _primary.PuertasEmbarque.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
