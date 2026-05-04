using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class UsuariosRolesService : IUsuariosRolesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public UsuariosRolesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<UsuariosRoles>> ListarTodo()
        {
            try { return await _replica.UsuariosRoles.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo UsuariosRoles: {ex.Message}"); return new List<UsuariosRoles>(); }
        }

        public async Task<UsuariosRoles ?> ObtenerPorId(int id)
        {
            try { return await _replica.UsuariosRoles.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId UsuariosRoles: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(UsuariosRoles m)
        {
            _primary.UsuariosRoles.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, UsuariosRoles m)
        {
            _primary.UsuariosRoles.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.UsuariosRoles.FindAsync(id);
            if (e == null) return false;
            _primary.UsuariosRoles.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
