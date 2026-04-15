using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PasajeroSegmentoService : IPasajeroSegmentoService
    {
        private readonly DBContext _context;
        public PasajeroSegmentoService(DBContext context) => _context = context;

        public async Task<bool> Insertar(PasajerosSegmentos m)
        {
            var p = new[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_id_segmento_cliente", m.IdSegmentoCliente),
                new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_automatico", m.Automatico),
                new OracleParameter("p_activo", m.Activo)
            };
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN pkg_pasajeros_segmentos.insert_pasajero_segmento(:p_id_pasajero, :p_id_segmento_cliente, :p_fecha_asignacion, :p_automatico, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, PasajerosSegmentos m)
        {
            var p = new[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_id_segmento_cliente", m.IdSegmentoCliente),
                new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_automatico", m.Automatico),
                new OracleParameter("p_activo", m.Activo)
            };
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN pkg_pasajeros_segmentos.update_pasajero_segmento(:p_id_pasajero, :p_id_segmento_cliente, :p_fecha_asignacion, :p_automatico, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN pkg_pasajeros_segmentos.delete_by_id(:p_id); END;",
                new OracleParameter("p_id", id));
            return true;
        }

        public async Task<List<PasajerosSegmentos>> ListarTodo() =>
            await _context.Set<PasajerosSegmentos>().ToListAsync();

        public async Task<PasajerosSegmentos?> ObtenerPorId(int id) =>
            await _context.Set<PasajerosSegmentos>().FindAsync(id);
    }
}
