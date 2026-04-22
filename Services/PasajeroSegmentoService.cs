using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PasajeroSegmentoService : IPasajeroSegmentoService
    {
        private readonly DBContext _context;
        public PasajeroSegmentoService(DBContext context) => _context = context;

        public async Task<List<PasajerosSegmentos>> ListarTodo()
        {
            try { return await _context.PasajerosSegmentos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PasajerosSegmentos: {ex.Message}"); return new List<PasajerosSegmentos>(); }
        }

        public async Task<PasajerosSegmentos?> ObtenerPorId(int id)
        {
            try { return await _context.PasajerosSegmentos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PasajerosSegmentos: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PasajerosSegmentos m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_segmentos.insert_pasajero_segmento(:p_id_pasajero, :p_id_segmento_cliente, :p_fecha_asignacion, :p_automatico, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_id_segmento_cliente", (object?)m.IdSegmentoCliente ?? DBNull.Value),
                new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_automatico", (object?)m.Automatico ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PasajerosSegmentos: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, PasajerosSegmentos m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_segmentos.update_pasajero_segmento(:p_id_pasajero, :p_id_segmento_cliente, :p_fecha_asignacion, :p_automatico, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_pasajero", id),
                new OracleParameter("p_id_segmento_cliente", (object?)m.IdSegmentoCliente ?? DBNull.Value),
                new OracleParameter("p_fecha_asignacion", (object?)m.FechaAsignacion ?? DBNull.Value),
                new OracleParameter("p_automatico", (object?)m.Automatico ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PasajerosSegmentos: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_segmentos.delete_pasajero_segmento(:p_id_pasajero); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_pasajero", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PasajerosSegmentos: {ex.Message}"); return false; }
        }
    }
}
