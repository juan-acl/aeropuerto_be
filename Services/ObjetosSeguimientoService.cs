using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ObjetosSeguimientoService : IObjetosSeguimientoService
    {
        private readonly DBContext _context;

        public ObjetosSeguimientoService(DBContext context) => _context = context;

        public async Task<bool> RegistrarMovimiento(ObjetosSeguimientoModel m)
        {
            var sql = "pkg_objetos_seguimiento.insert_seguimiento";

            var parametros = new[] {
                new OracleParameter("p_id_objeto", (object?)m.IdObjeto ?? DBNull.Value),
                new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                new OracleParameter("p_responsable", (object?)m.Responsable ?? DBNull.Value),
                new OracleParameter("p_accion", (object?)m.Accion ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_objeto, :p_ubicacion, :p_responsable, :p_accion, :p_observaciones); END;", parametros);
            return true;
        }

        public async Task<List<ObjetosSeguimientoModel>> ListarHistorialPorObjeto(int idObjeto)
        {
            return await _context.ObjetosSeguimiento
                .Where(s => s.IdObjeto == idObjeto)
                .OrderByDescending(s => s.FechaMovimiento)
                .ToListAsync();
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "pkg_objetos_seguimiento.delete_seguimiento";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_seguimiento); END;", new OracleParameter("p_id_seguimiento", id));
            return true;
        }
    }
}