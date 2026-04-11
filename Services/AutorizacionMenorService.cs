using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class AutorizacionMenorService : IAutorizacionMenorService
    {
        private readonly DBContext _context;
        public AutorizacionMenorService(DBContext context) => _context = context;

        public async Task<List<AutorizacionMenor>> ListarTodo() => await _context.AUTORIZACIONES_MENORES.ToListAsync();

        public async Task<bool> Insertar(AutorizacionMenor m)
        {
            try
            {
                string sql = "BEGIN pkg_autorizaciones_menores.insert_autorizacion(:p_idm, :p_nom, :p_dpi, :p_tipo, :p_doc, :p_fec); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_idm", m.IdPasajeroMenor),
                    new OracleParameter("p_nom", m.NombreTutor),
                    new OracleParameter("p_dpi", m.DpiTutor),
                    new OracleParameter("p_tipo", m.TipoRelacion),
                    new OracleParameter("p_doc", m.DocumentoAdjunto),
                    new OracleParameter("p_fec", m.FechaEmision)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR AUTORIZACION: {ex.Message}");
                return false;
            }
        }
    }
}