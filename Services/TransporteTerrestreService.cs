using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TransporteTerrestreService : ITransporteTerrestreService
    {
        private readonly DBContext _context;
        public TransporteTerrestreService(DBContext context) => _context = context;

        public async Task<List<TransporteTerrestreModel>> ListarTodo()
        {
            try { return await _context.TransporteTerrestre.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TransporteTerrestreModel: {ex.Message}"); return new List<TransporteTerrestreModel>(); }
        }

        public async Task<TransporteTerrestreModel?> ObtenerPorId(int id)
        {
            try { return await _context.TransporteTerrestre.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TransporteTerrestreModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TransporteTerrestreModel m)
        {
            try
            {
                string sql = "BEGIN pkg_transporte_terrestre.insert_transporte(:p_codigo_aeropuerto, :p_tipo_transporte, :p_empresa, :p_telefono_contacto, :p_tarifa_estimada, :p_horario_operacion, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_tipo_transporte", (object?)m.TipoTransporte ?? DBNull.Value),
                new OracleParameter("p_empresa", (object?)m.Empresa ?? DBNull.Value),
                new OracleParameter("p_telefono_contacto", (object?)m.TelefonoContacto ?? DBNull.Value),
                new OracleParameter("p_tarifa_estimada", (object?)m.TarifaEstimada ?? DBNull.Value),
                new OracleParameter("p_horario_operacion", (object?)m.HorarioOperacion ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar TransporteTerrestreModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, TransporteTerrestreModel m)
        {
            try
            {
                string sql = "BEGIN pkg_transporte_terrestre.update_transporte(:p_id_transporte, :p_codigo_aeropuerto, :p_tipo_transporte, :p_empresa, :p_telefono_contacto, :p_tarifa_estimada, :p_horario_operacion, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_transporte", id),
                new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_tipo_transporte", (object?)m.TipoTransporte ?? DBNull.Value),
                new OracleParameter("p_empresa", (object?)m.Empresa ?? DBNull.Value),
                new OracleParameter("p_telefono_contacto", (object?)m.TelefonoContacto ?? DBNull.Value),
                new OracleParameter("p_tarifa_estimada", (object?)m.TarifaEstimada ?? DBNull.Value),
                new OracleParameter("p_horario_operacion", (object?)m.HorarioOperacion ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar TransporteTerrestreModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_transporte_terrestre.delete_transporte(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar TransporteTerrestreModel: {ex.Message}"); return false; }
        }
    }
}
