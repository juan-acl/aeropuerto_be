using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class UniformeEquipamientoService : IUniformeEquipamientoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public UniformeEquipamientoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<UniformeEquipamiento>> ListarTodo()
        {
            try { return await _replica.UNIFORMES_EQUIPAMIENTO.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo UniformeEquipamiento: {ex.Message}"); return new List<UniformeEquipamiento>(); }
        }

        public async Task<UniformeEquipamiento ?> ObtenerPorId(int id)
        {
            try { return await _replica.UNIFORMES_EQUIPAMIENTO.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId UniformeEquipamiento: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(UniformeEquipamiento m)
        {
            try
            {
                string sql = "BEGIN pkg_uniformes_equipamiento.insert_asignacion(:p_id_empleado, :p_tipo_equipo, :p_descripcion, :p_talla, :p_fecha_asignacion, :p_fecha_devolucion, :p_estado, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_empleado", m.IdEmpleado),
                    new OracleParameter("p_tipo_equipo", (object?)m.TipoEquipo ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_talla", (object?)m.Talla ?? DBNull.Value),
                    new OracleParameter("p_fecha_asignacion", m.FechaAsignacion),
                    new OracleParameter("p_fecha_devolucion", (object?)m.FechaDevolucion ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar UniformeEquipamiento: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, UniformeEquipamiento m)
        {
            try
            {
                string sql = "BEGIN pkg_uniformes_equipamiento.update_asignacion(:p_id_asignacion, :p_id_empleado, :p_tipo_equipo, :p_descripcion, :p_talla, :p_fecha_asignacion, :p_fecha_devolucion, :p_estado, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_asignacion", id),
                    new OracleParameter("p_id_empleado", m.IdEmpleado),
                    new OracleParameter("p_tipo_equipo", (object?)m.TipoEquipo ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_talla", (object?)m.Talla ?? DBNull.Value),
                    new OracleParameter("p_fecha_asignacion", m.FechaAsignacion),
                    new OracleParameter("p_fecha_devolucion", (object?)m.FechaDevolucion ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar UniformeEquipamiento: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_uniformes_equipamiento.delete_asignacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar UniformeEquipamiento: {ex.Message}"); throw; }
        }
    }
}
