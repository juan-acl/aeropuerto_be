using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class ComunicacionesEmergenciaService : IComunicacionesEmergenciaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ComunicacionesEmergenciaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ComunicacionesEmergencia>> ListarTodo()
        {
            try { return await _replica.ComunicacionesEmergencia.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ComunicacionesEmergencia: {ex.Message}"); return new List<ComunicacionesEmergencia>(); }
        }

        public async Task<ComunicacionesEmergencia ?> ObtenerPorId(int id)
        {
            try { return await _replica.ComunicacionesEmergencia.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ComunicacionesEmergencia: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ComunicacionesEmergencia m)
        {
            _primary.ComunicacionesEmergencia.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, ComunicacionesEmergencia m)
        {
            _primary.ComunicacionesEmergencia.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.ComunicacionesEmergencia.FindAsync(id);
            if (e == null) return false;
            _primary.ComunicacionesEmergencia.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
