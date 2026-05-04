using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class RespaldosSistemaService : IRespaldosSistemaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public RespaldosSistemaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<RespaldosSistema>> ListarTodo()
        {
            try { return await _replica.Respaldos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo RespaldosSistema: {ex.Message}"); return new List<RespaldosSistema>(); }
        }

        public async Task<RespaldosSistema ?> ObtenerPorId(int id)
        {
            try { return await _replica.Respaldos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId RespaldosSistema: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(RespaldosSistema m)
        {
            _primary.Respaldos.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, RespaldosSistema m)
        {
            _primary.Respaldos.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.Respaldos.FindAsync(id);
            if (e == null) return false;
            _primary.Respaldos.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
