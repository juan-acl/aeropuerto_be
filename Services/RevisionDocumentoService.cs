using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace Aeropuerto.Backend.Services
{
    public class RevisionDocumentoService : IRevisionDocumentoService
    {
        private readonly DBContext _ctx;
        public RevisionDocumentoService(DBContext ctx) => _ctx = ctx;
        public async Task<List<RevisionesDocumentos>> ListarTodo() => await _ctx.Set<RevisionesDocumentos>().ToListAsync();
        public async Task<RevisionesDocumentos?> ObtenerPorId(int id) => await _ctx.Set<RevisionesDocumentos>().FindAsync(id);
        public async Task<bool> Insertar(RevisionesDocumentos m) { _ctx.Set<RevisionesDocumentos>().Add(m); await _ctx.SaveChangesAsync(); return true; }
        public async Task<bool> Actualizar(int id, RevisionesDocumentos m) {
            var e = await _ctx.Set<RevisionesDocumentos>().FindAsync(id);
            if (e == null) return false;
            _ctx.Entry(e).CurrentValues.SetValues(m);
            await _ctx.SaveChangesAsync(); return true;
        }
        public async Task<bool> Eliminar(int id) {
            var e = await _ctx.Set<RevisionesDocumentos>().FindAsync(id);
            if (e == null) return false;
            _ctx.Set<RevisionesDocumentos>().Remove(e); await _ctx.SaveChangesAsync(); return true;
        }
    }
}
