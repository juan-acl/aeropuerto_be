using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ObjetosDecomisadosService : IObjetosDecomisadosService
    {
        private readonly DBContext _context;
        public ObjetosDecomisadosService(DBContext context) => _context = context;

        public async Task<List<ObjetosDecomisadosModel>> ListarTodo()
        {
            try { return await _context.ObjetosDecomisados.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ObjetosDecomisadosModel: {ex.Message}"); return new List<ObjetosDecomisadosModel>(); }
        }

        public async Task<ObjetosDecomisadosModel?> ObtenerPorId(int id)
        {
            try { return await _context.ObjetosDecomisados.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ObjetosDecomisadosModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ObjetosDecomisadosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_objetos_decomisados.insert_decomiso(:p_id_control, :p_id_pasajero, :p_tipo_objeto, :p_descripcion, :p_cantidad, :p_motivo_decomiso, :p_destino_final, :p_fecha_registro, :p_registrado_por); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_control", (object?)m.IdControl ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_tipo_objeto", (object?)m.TipoObjeto ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_cantidad", m.Cantidad),
                new OracleParameter("p_motivo_decomiso", (object?)m.MotivoDecomiso ?? DBNull.Value),
                new OracleParameter("p_destino_final", (object?)m.DestinoFinal ?? DBNull.Value),
                new OracleParameter("p_fecha_registro", (object?)m.FechaRegistro ?? DBNull.Value),
                new OracleParameter("p_registrado_por", (object?)m.RegistradoPor ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ObjetosDecomisadosModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, ObjetosDecomisadosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_objetos_decomisados.update_decomiso(:p_id_decomiso, :p_id_control, :p_id_pasajero, :p_tipo_objeto, :p_descripcion, :p_cantidad, :p_motivo_decomiso, :p_destino_final, :p_fecha_registro, :p_registrado_por); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_decomiso", id),
                new OracleParameter("p_id_control", (object?)m.IdControl ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_tipo_objeto", (object?)m.TipoObjeto ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_cantidad", m.Cantidad),
                new OracleParameter("p_motivo_decomiso", (object?)m.MotivoDecomiso ?? DBNull.Value),
                new OracleParameter("p_destino_final", (object?)m.DestinoFinal ?? DBNull.Value),
                new OracleParameter("p_fecha_registro", (object?)m.FechaRegistro ?? DBNull.Value),
                new OracleParameter("p_registrado_por", (object?)m.RegistradoPor ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ObjetosDecomisadosModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_objetos_decomisados.delete_decomiso(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ObjetosDecomisadosModel: {ex.Message}"); return false; }
        }
    }
}
