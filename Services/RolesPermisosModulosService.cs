using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class RolesPermisosModulosService : IRolesPermisosModulosService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public RolesPermisosModulosService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<RolesPermisosModulos>> ListarTodo()
        {
            try { return await _replica.RolesPermisosModulos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo RolesPermisosModulos: {ex.Message}"); return new List<RolesPermisosModulos>(); }
        }

        public async Task<RolesPermisosModulos ?> ObtenerPorId(int id)
        {
            try { return await _replica.RolesPermisosModulos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId RolesPermisosModulos: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(RolesPermisosModulos m)
        {
            _primary.RolesPermisosModulos.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, RolesPermisosModulos m)
        {
            _primary.RolesPermisosModulos.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.RolesPermisosModulos.FindAsync(id);
            if (e == null) return false;
            _primary.RolesPermisosModulos.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
