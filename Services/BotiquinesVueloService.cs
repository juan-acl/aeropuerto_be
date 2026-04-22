using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class BotiquinesVueloService : IBotiquinesVueloService
    {
        private readonly DBContext _context;
        public BotiquinesVueloService(DBContext context) => _context = context;

        public async Task<List<BotiquinesVueloModel>> ListarTodo()
        {
            try { return await _context.BotiquinesVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo BotiquinesVueloModel: {ex.Message}"); return new List<BotiquinesVueloModel>(); }
        }

        public async Task<BotiquinesVueloModel?> ObtenerPorId(int id)
        {
            try { return await _context.BotiquinesVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId BotiquinesVueloModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(BotiquinesVueloModel m)
        {
            try
            {
                string sql = "BEGIN pkg_botiquines_vuelo.insert_botiquin(:p_id_vuelo, :p_fecha_verificacion, :p_contenido_completo, :p_medicamentos_caducados, :p_observaciones, :p_verificado_por); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_vuelo", m.IdVuelo),
                new OracleParameter("p_fecha_verificacion", (object?)m.FechaVerificacion ?? DBNull.Value),
                new OracleParameter("p_contenido_completo", m.ContenidoCompleto),
                new OracleParameter("p_medicamentos_caducados", m.MedicamentosCaducados),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
                new OracleParameter("p_verificado_por", (object?)m.VerificadoPor ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar BotiquinesVueloModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, BotiquinesVueloModel m)
        {
            try
            {
                string sql = "BEGIN pkg_botiquines_vuelo.update_botiquin(:p_id_botiquin, :p_id_vuelo, :p_fecha_verificacion, :p_contenido_completo, :p_medicamentos_caducados, :p_observaciones, :p_verificado_por); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_botiquin", id),
                new OracleParameter("p_id_vuelo", m.IdVuelo),
                new OracleParameter("p_fecha_verificacion", (object?)m.FechaVerificacion ?? DBNull.Value),
                new OracleParameter("p_contenido_completo", m.ContenidoCompleto),
                new OracleParameter("p_medicamentos_caducados", m.MedicamentosCaducados),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
                new OracleParameter("p_verificado_por", (object?)m.VerificadoPor ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar BotiquinesVueloModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_botiquines_vuelo.delete_botiquin(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar BotiquinesVueloModel: {ex.Message}"); return false; }
        }
    }
}
