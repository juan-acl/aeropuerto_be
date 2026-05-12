using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class ReservasService : IReservasService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ReservasService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ReservasModel>> ListarTodo()
        {
            try { return await _replica.Reservas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ReservasModel: {ex.Message}"); return new List<ReservasModel>(); }
        }

        public async Task<ReservasModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.Reservas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ReservasModel: {ex.Message}"); return null; }
        }

        public async Task<List<ReservasModel>> ListarPorPasajero(int idPasajero)
        {
            try { return await _replica.Reservas.Where(r => r.IdPasajero == idPasajero).ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarPorPasajero ReservasModel: {ex.Message}"); return new List<ReservasModel>(); }
        }

        public async Task<List<ReservasModel>> ListarPorVuelo(int idVuelo)
        {
            try { return await _replica.Reservas.Where(r => r.IdVuelo == idVuelo && r.EstadoReserva != "CANCELADA").ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarPorVuelo ReservasModel: {ex.Message}"); return new List<ReservasModel>(); }
        }

        public async Task<bool> Insertar(ReservasModel m)
        {
            _primary.Reservas.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, ReservasModel m)
        {   
            _primary.Reservas.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.Reservas.FindAsync(id);
            if (e == null) return false;
            _primary.Reservas.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
