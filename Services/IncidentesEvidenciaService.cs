using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Services
{
    public class IncidentesEvidenciaService : IIncidentesEvidenciaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public IncidentesEvidenciaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<IncidentesEvidenciaModel>> ListarTodo()
        {
            try { return await _replica.IncidentesEvidencia.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo IncidentesEvidenciaModel: {ex.Message}"); return new List<IncidentesEvidenciaModel>(); }
        }

        public async Task<IncidentesEvidenciaModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.IncidentesEvidencia.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId IncidentesEvidenciaModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(IncidentesEvidenciaModel m)
        {
            _primary.IncidentesEvidencia.Add(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Actualizar(int id, IncidentesEvidenciaModel m)
        {
            _primary.IncidentesEvidencia.Update(m);
            await _primary.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var e = await _primary.IncidentesEvidencia.FindAsync(id);
            if (e == null) return false;
            _primary.IncidentesEvidencia.Remove(e);
            await _primary.SaveChangesAsync();
            return true;
        }
    }
}
