using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ObjetosPerdidosService : IObjetosPerdidosService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ObjetosPerdidosService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ObjetosPerdidosModel>> ListarTodo()
        {
            try { return await _replica.ObjetosPerdidos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ObjetosPerdidosModel: {ex.Message}"); return new List<ObjetosPerdidosModel>(); }
        }

        public async Task<ObjetosPerdidosModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.ObjetosPerdidos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ObjetosPerdidosModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ObjetosPerdidosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_objetos_perdidos.insert_objeto(:p_descripcion, :p_categoria_objeto, :p_fecha_reporte, :p_hora_reporte, :p_lugar_encontrado, :p_ubicacion_detallada, :p_id_vuelo, :p_codigo_aeropuerto, :p_color, :p_marca, :p_modelo, :p_numero_serie, :p_valor_estimado, :p_encontrado_por, :p_ubicacion_actual, :p_estado, :p_fecha_entrega, :p_id_pasajero_entrega, :p_observaciones, :p_foto_objeto); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_categoria_objeto", (object?)m.CategoriaObjeto ?? DBNull.Value),
                    new OracleParameter("p_fecha_reporte", (object?)m.FechaReporte ?? DBNull.Value),
                    new OracleParameter("p_hora_reporte", (object?)m.HoraReporte ?? DBNull.Value),
                    new OracleParameter("p_lugar_encontrado", (object?)m.LugarEncontrado ?? DBNull.Value),
                    new OracleParameter("p_ubicacion_detallada", (object?)m.UbicacionDetallada ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_color", (object?)m.Color ?? DBNull.Value),
                    new OracleParameter("p_marca", (object?)m.Marca ?? DBNull.Value),
                    new OracleParameter("p_modelo", (object?)m.Modelo ?? DBNull.Value),
                    new OracleParameter("p_numero_serie", (object?)m.NumeroSerie ?? DBNull.Value),
                    new OracleParameter("p_valor_estimado", (object?)m.ValorEstimado ?? DBNull.Value),
                    new OracleParameter("p_encontrado_por", (object?)m.EncontradoPor ?? DBNull.Value),
                    new OracleParameter("p_ubicacion_actual", (object?)m.UbicacionActual ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_fecha_entrega", (object?)m.FechaEntrega ?? DBNull.Value),
                    new OracleParameter("p_id_pasajero_entrega", (object?)m.IdPasajeroEntrega ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
                    new OracleParameter("p_foto_objeto", (object?)m.FotoObjeto ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ObjetosPerdidosModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ObjetosPerdidosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_objetos_perdidos.update_objeto(:p_id_objeto, :p_descripcion, :p_categoria_objeto, :p_fecha_reporte, :p_hora_reporte, :p_lugar_encontrado, :p_ubicacion_detallada, :p_id_vuelo, :p_codigo_aeropuerto, :p_color, :p_marca, :p_modelo, :p_numero_serie, :p_valor_estimado, :p_encontrado_por, :p_ubicacion_actual, :p_estado, :p_fecha_entrega, :p_id_pasajero_entrega, :p_observaciones, :p_foto_objeto); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_objeto", id),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_categoria_objeto", (object?)m.CategoriaObjeto ?? DBNull.Value),
                    new OracleParameter("p_fecha_reporte", (object?)m.FechaReporte ?? DBNull.Value),
                    new OracleParameter("p_hora_reporte", (object?)m.HoraReporte ?? DBNull.Value),
                    new OracleParameter("p_lugar_encontrado", (object?)m.LugarEncontrado ?? DBNull.Value),
                    new OracleParameter("p_ubicacion_detallada", (object?)m.UbicacionDetallada ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_color", (object?)m.Color ?? DBNull.Value),
                    new OracleParameter("p_marca", (object?)m.Marca ?? DBNull.Value),
                    new OracleParameter("p_modelo", (object?)m.Modelo ?? DBNull.Value),
                    new OracleParameter("p_numero_serie", (object?)m.NumeroSerie ?? DBNull.Value),
                    new OracleParameter("p_valor_estimado", (object?)m.ValorEstimado ?? DBNull.Value),
                    new OracleParameter("p_encontrado_por", (object?)m.EncontradoPor ?? DBNull.Value),
                    new OracleParameter("p_ubicacion_actual", (object?)m.UbicacionActual ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_fecha_entrega", (object?)m.FechaEntrega ?? DBNull.Value),
                    new OracleParameter("p_id_pasajero_entrega", (object?)m.IdPasajeroEntrega ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
                    new OracleParameter("p_foto_objeto", (object?)m.FotoObjeto ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ObjetosPerdidosModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_objetos_perdidos.delete_objeto(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ObjetosPerdidosModel: {ex.Message}"); throw; }
        }
    }
}
