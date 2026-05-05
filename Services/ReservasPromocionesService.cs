using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class ReservasPromocionesService : IReservasPromocionesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ReservasPromocionesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ReservasPromocionesModel>> ListarTodo()
        {
            try { return await _replica.ReservasPromociones.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ReservasPromocionesModel: {ex.Message}"); return new List<ReservasPromocionesModel>(); }
        }

        public async Task<ReservasPromocionesModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.ReservasPromociones.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ReservasPromocionesModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ReservasPromocionesModel m)
        {
            _primary.ReservasPromociones.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, ReservasPromocionesModel m)
        {
            _primary.ReservasPromociones.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.ReservasPromociones.FindAsync(id);
            if (e == null) return false;
            _primary.ReservasPromociones.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
