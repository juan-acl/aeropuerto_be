using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class RevisionesDocumentosService : IRevisionesDocumentosService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public RevisionesDocumentosService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<RevisionesDocumentos>> ListarTodo()
        {
            try { return await _replica.RevisionesDocumentos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo RevisionesDocumentos: {ex.Message}"); return new List<RevisionesDocumentos>(); }
        }

        public async Task<RevisionesDocumentos ?> ObtenerPorId(int id)
        {
            try { return await _replica.RevisionesDocumentos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId RevisionesDocumentos: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(RevisionesDocumentos m)
        {
            _primary.RevisionesDocumentos.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, RevisionesDocumentos m)
        {
            _primary.RevisionesDocumentos.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.RevisionesDocumentos.FindAsync(id);
            if (e == null) return false;
            _primary.RevisionesDocumentos.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
