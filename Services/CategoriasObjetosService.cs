using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class CategoriasObjetosService : ICategoriasObjetosService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CategoriasObjetosService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CategoriasObjetosModel>> ListarTodo()
        {
            try { return await _replica.CategoriasObjetos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CategoriasObjetosModel: {ex.Message}"); return new List<CategoriasObjetosModel>(); }
        }

        public async Task<CategoriasObjetosModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.CategoriasObjetos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CategoriasObjetosModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CategoriasObjetosModel m)
        {
            _primary.CategoriasObjetos.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, CategoriasObjetosModel m)
        {
            _primary.CategoriasObjetos.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.CategoriasObjetos.FindAsync(id);
            if (e == null) return false;
            _primary.CategoriasObjetos.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
