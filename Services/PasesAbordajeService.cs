using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PasesAbordajeService : IPasesAbordajeService
    {
        private readonly DBContext _context;
        public PasesAbordajeService(DBContext context) => _context = context;

        public async Task<List<PasesAbordajeModel>> ListarTodo()
        {
            try { return await _context.PasesAbordaje.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PasesAbordajeModel: {ex.Message}"); return new List<PasesAbordajeModel>(); }
        }

        public async Task<PasesAbordajeModel?> ObtenerPorId(int id)
        {
            try { return await _context.PasesAbordaje.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PasesAbordajeModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PasesAbordajeModel m)
        {
            try
            {
                string sql = "BEGIN pkg_pases_abordaje.insert_pase(:p_id_reserva, :p_codigo_barras, :p_qr_code, :p_fecha_generacion, :p_fecha_escaneo, :p_puerta_embarque, :p_grupo_embarque, :p_asiento, :p_utilizado); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_reserva", m.IdReserva),
                new OracleParameter("p_codigo_barras", (object?)m.CodigoBarras ?? DBNull.Value),
                new OracleParameter("p_qr_code", (object?)m.QrCode ?? DBNull.Value),
                new OracleParameter("p_fecha_generacion", (object?)m.FechaGeneracion ?? DBNull.Value),
                new OracleParameter("p_fecha_escaneo", (object?)m.FechaEscaneo ?? DBNull.Value),
                new OracleParameter("p_puerta_embarque", (object?)m.PuertaEmbarque ?? DBNull.Value),
                new OracleParameter("p_grupo_embarque", (object?)m.GrupoEmbarque ?? DBNull.Value),
                new OracleParameter("p_asiento", (object?)m.Asiento ?? DBNull.Value),
                new OracleParameter("p_utilizado", m.Utilizado)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PasesAbordajeModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, PasesAbordajeModel m)
        {
            try
            {
                string sql = "BEGIN pkg_pases_abordaje.update_pase(:p_id_pase_abordaje, :p_id_reserva, :p_codigo_barras, :p_qr_code, :p_fecha_generacion, :p_fecha_escaneo, :p_puerta_embarque, :p_grupo_embarque, :p_asiento, :p_utilizado); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_pase_abordaje", id),
                new OracleParameter("p_id_reserva", m.IdReserva),
                new OracleParameter("p_codigo_barras", (object?)m.CodigoBarras ?? DBNull.Value),
                new OracleParameter("p_qr_code", (object?)m.QrCode ?? DBNull.Value),
                new OracleParameter("p_fecha_generacion", (object?)m.FechaGeneracion ?? DBNull.Value),
                new OracleParameter("p_fecha_escaneo", (object?)m.FechaEscaneo ?? DBNull.Value),
                new OracleParameter("p_puerta_embarque", (object?)m.PuertaEmbarque ?? DBNull.Value),
                new OracleParameter("p_grupo_embarque", (object?)m.GrupoEmbarque ?? DBNull.Value),
                new OracleParameter("p_asiento", (object?)m.Asiento ?? DBNull.Value),
                new OracleParameter("p_utilizado", m.Utilizado)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PasesAbordajeModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_pases_abordaje.delete_pase(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PasesAbordajeModel: {ex.Message}"); return false; }
        }
    }
}
