using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class AlertasSeguridadService : IAlertasSeguridadService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public AlertasSeguridadService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<AlertasSeguridadModel>> ListarTodo()
        {
            try { return await _replica.AlertasSeguridad.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo AlertasSeguridadModel: {ex.Message}"); return new List<AlertasSeguridadModel>(); }
        }

        public async Task<AlertasSeguridadModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.AlertasSeguridad.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId AlertasSeguridadModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(AlertasSeguridadModel m)
        {
            _primary.AlertasSeguridad.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, AlertasSeguridadModel m)
        {
            _primary.AlertasSeguridad.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.AlertasSeguridad.FindAsync(id);
            if (e == null) return false;
            _primary.AlertasSeguridad.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
