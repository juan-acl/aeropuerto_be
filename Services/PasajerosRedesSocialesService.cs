using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class PasajerosRedesSocialesService : IPasajerosRedesSocialesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PasajerosRedesSocialesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PasajerosRedesSocialesModel>> ListarTodo()
        {
            try { return await _replica.PasajerosRedesSociales.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PasajerosRedesSocialesModel: {ex.Message}"); return new List<PasajerosRedesSocialesModel>(); }
        }

        public async Task<PasajerosRedesSocialesModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.PasajerosRedesSociales.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PasajerosRedesSocialesModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PasajerosRedesSocialesModel m)
        {
            _primary.PasajerosRedesSociales.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, PasajerosRedesSocialesModel m)
        {
            _primary.PasajerosRedesSociales.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.PasajerosRedesSociales.FindAsync(id);
            if (e == null) return false;
            _primary.PasajerosRedesSociales.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
