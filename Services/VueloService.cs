using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class VueloService : IVueloService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public VueloService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<VueloModel>> ListarTodo()
        {
            try { return await _replica.Vuelos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo VueloModel: {ex.Message}"); return new List<VueloModel>(); }
        }

        public async Task<VueloModel?> ObtenerPorId(int id)
        {
            try { return await _replica.Vuelos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId VueloModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(VueloModel m)
        {
            _primary.Vuelos.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, VueloModel m)
        {
            _primary.Vuelos.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.Vuelos.FindAsync(id);
            if (e == null) return false;
            _primary.Vuelos.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
