using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class LogsAccesoSistemaService : ILogsAccesoSistemaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public LogsAccesoSistemaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<LogsAccesoSistema>> ListarTodo()
        {
            try { return await _replica.LogsAcceso.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo LogsAccesoSistema: {ex.Message}"); return new List<LogsAccesoSistema>(); }
        }

        public async Task<LogsAccesoSistema ?> ObtenerPorId(int id)
        {
            try { return await _replica.LogsAcceso.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId LogsAccesoSistema: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(LogsAccesoSistema m)
        {
            _primary.LogsAcceso.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, LogsAccesoSistema m)
        {
            _primary.LogsAcceso.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.LogsAcceso.FindAsync(id);
            if (e == null) return false;
            _primary.LogsAcceso.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
