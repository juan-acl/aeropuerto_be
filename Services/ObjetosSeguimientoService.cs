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
            var sql = @"INSERT INTO objetos_seguimiento 
                        (id_objeto, fecha_movimiento, ubicacion, responsable, accion, observaciones) 
                        VALUES (:p_obj, SYSTIMESTAMP, :p_ubic, :p_resp, :p_acc, :p_obs)";

            var parametros = new[] {
                new OracleParameter("p_obj", (object?)m.IdObjeto ?? DBNull.Value),
                new OracleParameter("p_ubic", (object?)m.Ubicacion ?? DBNull.Value),
                new OracleParameter("p_resp", (object?)m.Responsable ?? DBNull.Value),
                new OracleParameter("p_acc", (object?)m.Accion ?? DBNull.Value),
                new OracleParameter("p_obs", (object?)m.Observaciones ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
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
            var sql = "DELETE FROM objetos_seguimiento WHERE id_seguimiento = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}