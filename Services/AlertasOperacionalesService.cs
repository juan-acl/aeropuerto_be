using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class AlertasOperacionalesService : IAlertasOperacionalesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AlertasOperacionalesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AlertasOperacionales>> ListarTodo()
        {
            try { return await _replica.AlertasOperacionales.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AlertasOperacionales: {ex.Message}"); return new List<AlertasOperacionales>(); }
        }

        public async Task<AlertasOperacionales ?> ObtenerPorId(int id)
        {
            try { return await _replica.AlertasOperacionales.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AlertasOperacionales: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AlertasOperacionales m)
        {
            _primary.AlertasOperacionales.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, AlertasOperacionales m)
        {
            _primary.AlertasOperacionales.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.AlertasOperacionales.FindAsync(id);
            if (e == null) return false;
            _primary.AlertasOperacionales.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
