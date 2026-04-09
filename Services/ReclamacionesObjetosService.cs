using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ReclamacionesObjetosService : IReclamacionesObjetosService
    {
        private readonly DBContext _context;

        public ReclamacionesObjetosService(DBContext context) => _context = context;

        public async Task<bool> RegistrarReclamacion(ReclamacionesObjetosModel m)
        {
            var sql = @"INSERT INTO reclamaciones_objetos 
                        (id_pasajero, id_objeto, fecha_reclamacion, descripcion_reclamacion, estado) 
                        VALUES (:p_pas, :p_obj, SYSTIMESTAMP, :p_desc, 'PENDIENTE')";

            var parametros = new[] {
                new OracleParameter("p_pas", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_obj", (object?)m.IdObjeto ?? DBNull.Value),
                new OracleParameter("p_desc", (object?)m.DescripcionReclamacion ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<ReclamacionesObjetosModel>> ListarPendientes()
        {
            return await _context.ReclamacionesObjetos
                .Where(r => r.Estado == "PENDIENTE")
                .OrderBy(r => r.FechaReclamacion)
                .ToListAsync();
        }

        public async Task<List<ReclamacionesObjetosModel>> ListarPorPasajero(int idPasajero)
        {
            return await _context.ReclamacionesObjetos
                .Where(r => r.IdPasajero == idPasajero)
                .OrderByDescending(r => r.FechaReclamacion)
                .ToListAsync();
        }

        public async Task<bool> ResolverReclamacion(int idReclamacion, string estado, string resolucion, string resueltoPor)
        {
            var sql = @"UPDATE reclamaciones_objetos 
                        SET estado = :p_estado, 
                            fecha_resolucion = SYSTIMESTAMP, 
                            resolucion = :p_res, 
                            resuelto_por = :p_user 
                        WHERE id_reclamacion = :p_id";

            var parametros = new[] {
                new OracleParameter("p_estado", estado),
                new OracleParameter("p_res", resolucion),
                new OracleParameter("p_user", resueltoPor),
                new OracleParameter("p_id", idReclamacion)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM reclamaciones_objetos WHERE id_reclamacion = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}