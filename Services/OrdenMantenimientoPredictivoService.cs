using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class OrdenMantenimientoPredictivoService : IOrdenMantenimientoPredictivoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public OrdenMantenimientoPredictivoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<OrdenMantenimientoPredictivo>> ListarTodo()
        {
            try { return await _replica.ORDENES_MANTENIMIENTO_PRED.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo OrdenMantenimientoPredictivo: {ex.Message}"); return new List<OrdenMantenimientoPredictivo>(); }
        }

        public async Task<OrdenMantenimientoPredictivo ?> ObtenerPorId(int id)
        {
            try { return await _replica.ORDENES_MANTENIMIENTO_PRED.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId OrdenMantenimientoPredictivo: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(OrdenMantenimientoPredictivo m)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_mp.insert_orden(:p_id_alerta_tecnica, :p_id_pieza, :p_id_avion_matricula, :p_fecha_creacion, :p_prioridad, :p_descripcion_trabajo, :p_tecnico_asignado, :p_fecha_inicio_estimada, :p_fecha_fin_estimada, :p_fecha_inicio_real, :p_fecha_fin_real, :p_estado, :p_horas_trabajadas, :p_costo_estimado, :p_costo_real, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_alerta_tecnica", DBNull.Value),
                    new OracleParameter("p_id_pieza", DBNull.Value),
                    new OracleParameter("p_id_avion_matricula", DBNull.Value),
                    new OracleParameter("p_fecha_creacion", DBNull.Value),
                    new OracleParameter("p_prioridad", DBNull.Value),
                    new OracleParameter("p_descripcion_trabajo", DBNull.Value),
                    new OracleParameter("p_tecnico_asignado", DBNull.Value),
                    new OracleParameter("p_fecha_inicio_estimada", DBNull.Value),
                    new OracleParameter("p_fecha_fin_estimada", DBNull.Value),
                    new OracleParameter("p_fecha_inicio_real", DBNull.Value),
                    new OracleParameter("p_fecha_fin_real", DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_horas_trabajadas", DBNull.Value),
                    new OracleParameter("p_costo_estimado", DBNull.Value),
                    new OracleParameter("p_costo_real", DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar OrdenMantenimientoPredictivo: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, OrdenMantenimientoPredictivo m)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_mp.update_orden(:p_id_orden_mp, :p_id_alerta_tecnica, :p_id_pieza, :p_id_avion_matricula, :p_fecha_creacion, :p_prioridad, :p_descripcion_trabajo, :p_tecnico_asignado, :p_fecha_inicio_estimada, :p_fecha_fin_estimada, :p_fecha_inicio_real, :p_fecha_fin_real, :p_estado, :p_horas_trabajadas, :p_costo_estimado, :p_costo_real, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_orden_mp", id),
                    new OracleParameter("p_id_alerta_tecnica", DBNull.Value),
                    new OracleParameter("p_id_pieza", DBNull.Value),
                    new OracleParameter("p_id_avion_matricula", DBNull.Value),
                    new OracleParameter("p_fecha_creacion", DBNull.Value),
                    new OracleParameter("p_prioridad", DBNull.Value),
                    new OracleParameter("p_descripcion_trabajo", DBNull.Value),
                    new OracleParameter("p_tecnico_asignado", DBNull.Value),
                    new OracleParameter("p_fecha_inicio_estimada", DBNull.Value),
                    new OracleParameter("p_fecha_fin_estimada", DBNull.Value),
                    new OracleParameter("p_fecha_inicio_real", DBNull.Value),
                    new OracleParameter("p_fecha_fin_real", DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_horas_trabajadas", DBNull.Value),
                    new OracleParameter("p_costo_estimado", DBNull.Value),
                    new OracleParameter("p_costo_real", DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar OrdenMantenimientoPredictivo: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_mp.delete_orden(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar OrdenMantenimientoPredictivo: {ex.Message}"); throw; }
        }
    }
}
