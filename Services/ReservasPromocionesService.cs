using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ReservasPromocionesService : IReservasPromocionesService
    {
        private readonly DBContext _context;

        public ReservasPromocionesService(DBContext context) => _context = context;

        public async Task<bool> AplicarPromocion(ReservasPromocionesModel m)
        {
            // Usamos SYSTIMESTAMP para la fecha de aplicación automática
            var sql = @"INSERT INTO reservas_promociones (id_reserva, id_promocion, descuento_aplicado, fecha_aplicacion) 
                        VALUES (:p_res, :p_promo, :p_desc, SYSTIMESTAMP)";

            var parametros = new[] {
                new OracleParameter("p_res", m.IdReserva),
                new OracleParameter("p_promo", m.IdPromocion),
                new OracleParameter("p_desc", m.DescuentoAplicado)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);

            // Opcional: Aquí podrías disparar un UPDATE a la tabla PROMOCIONES 
            // para incrementar el campo USOS_ACTUALES.

            return true;
        }

        public async Task<List<ReservasPromocionesModel>> ListarPorReserva(int idReserva)
        {
            return await _context.ReservasPromociones
                .Where(rp => rp.IdReserva == idReserva)
                .ToListAsync();
        }

        public async Task<bool> EliminarRelacion(int idReserva, int idPromocion)
        {
            var sql = "DELETE FROM reservas_promociones WHERE id_reserva = :p_res AND id_promocion = :p_promo";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_res", idReserva),
                new OracleParameter("p_promo", idPromocion));
            return true;
        }
    }
}