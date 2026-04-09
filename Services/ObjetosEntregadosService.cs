using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ObjetosEntregadosService : IObjetosEntregadosService
    {
        private readonly DBContext _context;

        public ObjetosEntregadosService(DBContext context) => _context = context;

        public async Task<bool> RegistrarEntrega(ObjetosEntregadosModel m)
        {
            var sql = @"INSERT INTO objetos_entregados 
                        (id_objeto, id_pasajero, fecha_entrega, documento_identificacion, 
                         firma_digital, entregado_por, observaciones) 
                        VALUES (:p_obj, :p_pas, SYSTIMESTAMP, :p_doc, 
                                :p_firma, :p_entreg, :p_obs)";

            var parametros = new[] {
                new OracleParameter("p_obj", (object?)m.IdObjeto ?? DBNull.Value),
                new OracleParameter("p_pas", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_doc", (object?)m.DocumentoIdentificacion ?? DBNull.Value),
                new OracleParameter("p_firma", (object?)m.FirmaDigital ?? DBNull.Value),
                new OracleParameter("p_entreg", (object?)m.EntregadoPor ?? DBNull.Value),
                new OracleParameter("p_obs", (object?)m.Observaciones ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<ObjetosEntregadosModel>> ListarEntregas()
        {
            // Usamos proyección para excluir el BLOB de la firma digital por rendimiento
            return await _context.ObjetosEntregados
                .Select(o => new ObjetosEntregadosModel
                {
                    IdEntrega = o.IdEntrega,
                    IdObjeto = o.IdObjeto,
                    IdPasajero = o.IdPasajero,
                    FechaEntrega = o.FechaEntrega,
                    DocumentoIdentificacion = o.DocumentoIdentificacion,
                    EntregadoPor = o.EntregadoPor,
                    Observaciones = o.Observaciones,
                    FirmaDigital = null // Ignoramos el BLOB aquí
                })
                .OrderByDescending(o => o.FechaEntrega)
                .ToListAsync();
        }

        public async Task<ObjetosEntregadosModel?> ObtenerFirma(int idEntrega)
        {
            return await _context.ObjetosEntregados
                .Where(o => o.IdEntrega == idEntrega)
                .Select(o => new ObjetosEntregadosModel { FirmaDigital = o.FirmaDigital })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM objetos_entregados WHERE id_entrega = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}