using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class MonitoreoRuidoService : IMonitoreoRuidoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public MonitoreoRuidoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<MonitoreoRuido>> ListarTodo()
        {
            try { return await _replica.MonitoreoRuido.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo MonitoreoRuido: {ex.Message}"); return new List<MonitoreoRuido>(); }
        }

        public async Task<MonitoreoRuido ?> ObtenerPorId(int id)
        {
            try { return await _replica.MonitoreoRuido.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId MonitoreoRuido: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(MonitoreoRuido m)
        {
            _primary.MonitoreoRuido.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, MonitoreoRuido m)
        {
            _primary.MonitoreoRuido.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.MonitoreoRuido.FindAsync(id);
            if (e == null) return false;
            _primary.MonitoreoRuido.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
