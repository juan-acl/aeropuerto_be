using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PasesAbordajeService : IPasesAbordajeService
    {
        private readonly DBContext _context;

        public PasesAbordajeService(DBContext context) => _context = context;

        public async Task<bool> GenerarPase(PasesAbordajeModel m)
        {
            var sql = @"INSERT INTO pases_abordaje 
                        (id_reserva, codigo_barras, qr_code, fecha_generacion, puerta_embarque, grupo_embarque, asiento) 
                        VALUES (:p_res, :p_barras, :p_qr, SYSTIMESTAMP, :p_puerta, :p_grupo, :p_asiento)";

            var parametros = new[] {
                new OracleParameter("p_res", m.IdReserva),
                new OracleParameter("p_barras", (object?)m.CodigoBarras ?? DBNull.Value),
                new OracleParameter("p_qr", (object?)m.QrCode ?? DBNull.Value),
                new OracleParameter("p_puerta", (object?)m.PuertaEmbarque ?? DBNull.Value),
                new OracleParameter("p_grupo", (object?)m.GrupoEmbarque ?? DBNull.Value),
                new OracleParameter("p_asiento", (object?)m.Asiento ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<PasesAbordajeModel?> ObtenerPorReserva(int idReserva)
        {
            return await _context.PasesAbordaje
                .FirstOrDefaultAsync(p => p.IdReserva == idReserva);
        }

        public async Task<bool> RegistrarUso(int idPase)
        {
            var sql = "UPDATE pases_abordaje SET utilizado = 1, fecha_escaneo = SYSTIMESTAMP WHERE id_pase_abordaje = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", idPase));
            return true;
        }

        public async Task<bool> EliminarFisico(int idPase)
        {
            var sql = "DELETE FROM pases_abordaje WHERE id_pase_abordaje = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", idPase));
            return true;
        }
    }
}