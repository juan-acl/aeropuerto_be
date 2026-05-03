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
        public async Task<EnvioCarga?> ObtenerPorId(int id) => await _context.ENVIOS_CARGA.FindAsync(id);

        public async Task<bool> Insertar(EnvioCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_envios_carga.insert_envio(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12, :p13, :p14, :p15, :p16, :p17, :p18); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT ENVIO_CARGA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(EnvioCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_envios_carga.update_envio(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12, :p13, :p14, :p15, :p16, :p17, :p18); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE ENVIO_CARGA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_envios_carga.delete_envio(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE ENVIO_CARGA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(EnvioCarga m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_envio),
            new OracleParameter("p2",  m.codigo_envio),
            new OracleParameter("p3",  m.id_vuelo),
            new OracleParameter("p4",  m.id_tipo_carga),
            new OracleParameter("p5",  m.peso_kg),
            new OracleParameter("p6",  m.volumen_m3),
            new OracleParameter("p7",  m.cantidad_bultos),
            new OracleParameter("p8",  m.contenido),
            new OracleParameter("p9",  m.valor_declarado),
            new OracleParameter("p10", m.moneda),
            new OracleParameter("p11", m.consignador_nombre),
            new OracleParameter("p12", m.consignador_documento),
            new OracleParameter("p13", m.consignatario_nombre),
            new OracleParameter("p14", m.consignatario_documento),
            new OracleParameter("p15", m.instrucciones_especiales),
            new OracleParameter("p16", m.fecha_embarque),
            new OracleParameter("p17", m.estado),
            new OracleParameter("p18", m.ubicacion_actual)
        };
    }
}