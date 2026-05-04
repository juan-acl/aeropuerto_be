using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class MotorAvionService : IMotorAvionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public MotorAvionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<MotorAvionModel>> ListarTodo()
        {
            try { return await _replica.MotoresAviones.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo MotorAvionModel: {ex.Message}"); return new List<MotorAvionModel>(); }
        }

        public async Task<MotorAvionModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.MotoresAviones.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId MotorAvionModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(MotorAvionModel m)
        {
            _primary.MotoresAviones.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, MotorAvionModel m)
        {
            _primary.MotoresAviones.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.MotoresAviones.FindAsync(id);
            if (e == null) return false;
            _primary.MotoresAviones.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
