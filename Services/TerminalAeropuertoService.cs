using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class TerminalAeropuertoService : ITerminalAeropuertoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public TerminalAeropuertoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<TerminalAeropuertoModel>> ListarTodo()
        {
            try { return await _replica.Terminales.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TerminalAeropuertoModel: {ex.Message}"); return new List<TerminalAeropuertoModel>(); }
        }

        public async Task<TerminalAeropuertoModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.Terminales.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TerminalAeropuertoModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TerminalAeropuertoModel m)
        {
            _primary.Terminales.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, TerminalAeropuertoModel m)
        {
            _primary.Terminales.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.Terminales.FindAsync(id);
            if (e == null) return false;
            _primary.Terminales.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
