using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EnvioCargaService : IEnvioCargaService
    {
        private readonly DBContext _context;
        public EnvioCargaService(DBContext context) => _context = context;

        public async Task<List<EnvioCarga>> ListarTodo() => await _context.ENVIOS_CARGA.ToListAsync();

        public async Task<bool> Insertar(EnvioCarga m)
        {
            try {
                string sql = "BEGIN pkg_envios_carga.insert_envio(:p_guia, :p_rem, :p_dest, :p_peso, :p_vol, :p_cont, :p_fec); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_guia", m.NumeroGuia),
                    new OracleParameter("p_rem", m.Remitente),
                    new OracleParameter("p_dest", m.Destinatario),
                    new OracleParameter("p_peso", m.Peso),
                    new OracleParameter("p_vol", m.Volumen),
                    new OracleParameter("p_cont", m.Contenido),
                    new OracleParameter("p_fec", m.FechaEnvio)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            } catch { return false; }
        }
    }
}