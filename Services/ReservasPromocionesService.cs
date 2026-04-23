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
            var sql = "pkg_reservas_promociones.insert_promocion";

            var parametros = new[] {
                new OracleParameter("p_id_reserva", m.IdReserva),
                new OracleParameter("p_id_promocion", m.IdPromocion),
                new OracleParameter("p_descuento_aplicado", m.DescuentoAplicado)
            };

            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_reserva, :p_id_promocion, :p_descuento_aplicado); END;", parametros);

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
            var sql = "pkg_reservas_promociones.delete_promocion";
            await _context.Database.ExecuteSqlRawAsync($"BEGIN {sql}(:p_id_reserva, :p_id_promocion); END;",
                new OracleParameter("p_id_reserva", idReserva),
                new OracleParameter("p_id_promocion", idPromocion));
            return true;
        }
    }
}