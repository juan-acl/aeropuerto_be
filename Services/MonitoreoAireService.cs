using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class MonitoreoAireService : IMonitoreoAireService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public MonitoreoAireService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<MonitoreoAire>> ListarTodo()
        {
            try { return await _replica.MonitoreoAire.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo MonitoreoAire: {ex.Message}"); return new List<MonitoreoAire>(); }
        }

        public async Task<MonitoreoAire ?> ObtenerPorId(int id)
        {
            try { return await _replica.MonitoreoAire.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId MonitoreoAire: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(MonitoreoAire m)
        {
            _primary.MonitoreoAire.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, MonitoreoAire m)
        {
            _primary.MonitoreoAire.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.MonitoreoAire.FindAsync(id);
            if (e == null) return false;
            _primary.MonitoreoAire.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
