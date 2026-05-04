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
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public BotiquinesVueloService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<BotiquinesVueloModel>> ListarTodo()
        {
            try { return await _replica.BotiquinesVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo BotiquinesVueloModel: {ex.Message}"); return new List<BotiquinesVueloModel>(); }
        }

        public async Task<BotiquinesVueloModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.BotiquinesVuelo.FindAsync(id); }
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
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar BotiquinesVueloModel: {ex.Message}"); throw; }
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
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar BotiquinesVueloModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_botiquines_vuelo.delete_botiquin(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar BotiquinesVueloModel: {ex.Message}"); throw; }
        }
    }
}
