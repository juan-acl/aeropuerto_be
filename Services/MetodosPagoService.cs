using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class MetodosPagoService : IMetodosPagoService
    {
        private readonly DBContext _context;

        public MetodosPagoService(DBContext context) => _context = context;

        public async Task<bool> Insertar(MetodosPagoModel m)
        {
            var sql = @"INSERT INTO metodos_pago (descripcion, tipo_pago, procesador, activo) 
                        VALUES (:p_desc, :p_tipo, :p_proc, :p_activo)";

            var parametros = new[] {
                new OracleParameter("p_desc", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_tipo", m.TipoPago),
                new OracleParameter("p_proc", (object?)m.Procesador ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<MetodosPagoModel>> ListarActivos()
        {
            return await _context.MetodosPago
                .Where(m => m.Activo == 1)
                .ToListAsync();
        }

        public async Task<bool> Actualizar(int id, MetodosPagoModel m)
        {
            var sql = @"UPDATE metodos_pago 
                        SET descripcion = :p_desc, tipo_pago = :p_tipo, 
                            procesador = :p_proc, activo = :p_activo 
                        WHERE id_metodo_pago = :p_id";

            var parametros = new[] {
                new OracleParameter("p_desc", m.Descripcion),
                new OracleParameter("p_tipo", m.TipoPago),
                new OracleParameter("p_proc", m.Procesador),
                new OracleParameter("p_activo", m.Activo),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM metodos_pago WHERE id_metodo_pago = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}