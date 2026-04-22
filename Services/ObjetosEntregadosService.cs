using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ObjetosEntregadosService : IObjetosEntregadosService
    {
        private readonly DBContext _context;
        public ObjetosEntregadosService(DBContext context) => _context = context;

        public async Task<List<ObjetosEntregadosModel>> ListarTodo()
        {
            try { return await _context.ObjetosEntregados.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ObjetosEntregadosModel: {ex.Message}"); return new List<ObjetosEntregadosModel>(); }
        }

        public async Task<ObjetosEntregadosModel?> ObtenerPorId(int id)
        {
            try { return await _context.ObjetosEntregados.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ObjetosEntregadosModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ObjetosEntregadosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_objetos_entregados.insert_entrega(:p_id_objeto, :p_id_pasajero, :p_fecha_entrega, :p_documento_identificacion, :p_firma_digital, :p_entregado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_objeto", (object?)m.IdObjeto ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_fecha_entrega", (object?)m.FechaEntrega ?? DBNull.Value),
                new OracleParameter("p_documento_identificacion", (object?)m.DocumentoIdentificacion ?? DBNull.Value),
                new OracleParameter("p_firma_digital", OracleDbType.Blob) { Value = (object?)m.FirmaDigital ?? DBNull.Value },
                new OracleParameter("p_entregado_por", (object?)m.EntregadoPor ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ObjetosEntregadosModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, ObjetosEntregadosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_objetos_entregados.update_entrega(:p_id_entrega, :p_id_objeto, :p_id_pasajero, :p_fecha_entrega, :p_documento_identificacion, :p_firma_digital, :p_entregado_por, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_entrega", id),
                new OracleParameter("p_id_objeto", (object?)m.IdObjeto ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_fecha_entrega", (object?)m.FechaEntrega ?? DBNull.Value),
                new OracleParameter("p_documento_identificacion", (object?)m.DocumentoIdentificacion ?? DBNull.Value),
                new OracleParameter("p_firma_digital", OracleDbType.Blob) { Value = (object?)m.FirmaDigital ?? DBNull.Value },
                new OracleParameter("p_entregado_por", (object?)m.EntregadoPor ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ObjetosEntregadosModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_objetos_entregados.delete_entrega(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ObjetosEntregadosModel: {ex.Message}"); return false; }
        }
    }
}
