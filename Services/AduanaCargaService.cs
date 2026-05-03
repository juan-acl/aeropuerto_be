using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class AduanaCargaService : IAduanaCargaService
    {
        private readonly DBContext _context;
        public AduanaCargaService(DBContext context) => _context = context;

        public async Task<List<AduanaCarga>> ListarTodo() => await _context.ADUANAS_CARGA.ToListAsync();
        public async Task<AduanaCarga?> ObtenerPorId(int id) => await _context.ADUANAS_CARGA.FindAsync(id);

        public async Task<bool> Insertar(AduanaCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_aduanas_carga.insert_aduana(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT ADUANA_CARGA: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(AduanaCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_aduanas_carga.update_aduana(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE ADUANA_CARGA: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_aduanas_carga.delete_aduana(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE ADUANA_CARGA: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(AduanaCarga m) => new OracleParameter[]
        {
            new OracleParameter("p1",  m.id_registro_aduanal),
            new OracleParameter("p2",  m.id_envio),
            new OracleParameter("p3",  m.tipo_operacion),
            new OracleParameter("p4",  m.fecha_revision),
            new OracleParameter("p5",  m.estado_aduanal),
            new OracleParameter("p6",  m.inspector_asignado),
            new OracleParameter("p7",  m.documentos_verificados),
            new OracleParameter("p8",  m.impuesto_aplicado),
            new OracleParameter("p9",  m.moneda_impuesto),
            new OracleParameter("p10", m.fecha_liberacion),
            new OracleParameter("p11", m.observaciones)
        };
    }
}