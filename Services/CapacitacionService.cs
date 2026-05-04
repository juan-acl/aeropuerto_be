using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CapacitacionService : ICapacitacionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CapacitacionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<Capacitacion>> ListarTodo()
        {
            try { return await _replica.CAPACITACIONES.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo Capacitacion: {ex.Message}"); return new List<Capacitacion>(); }
        }

        public async Task<Capacitacion ?> ObtenerPorId(int id)
        {
            try { return await _replica.CAPACITACIONES.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId Capacitacion: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(Capacitacion m)
        {
            try
            {
                string sql = "BEGIN pkg_capacitaciones.insert_capacitacion(:p_nombre_curso, :p_descripcion, :p_tipo_capacitacion, :p_duracion_horas, :p_costo, :p_proveedor, :p_fecha_inicio, :p_fecha_fin, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nombre_curso", (object?)m.NombreCurso ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_capacitacion", (object?)m.TipoCapacitacion ?? DBNull.Value),
                    new OracleParameter("p_duracion_horas", m.DuracionHoras),
                    new OracleParameter("p_costo", m.Costo),
                    new OracleParameter("p_proveedor", (object?)m.Proveedor ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", m.FechaInicio),
                    new OracleParameter("p_fecha_fin", m.FechaFin),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar Capacitacion: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, Capacitacion m)
        {
            try
            {
                string sql = "BEGIN pkg_capacitaciones.update_capacitacion(:p_id_capacitacion, :p_nombre_curso, :p_descripcion, :p_tipo_capacitacion, :p_duracion_horas, :p_costo, :p_proveedor, :p_fecha_inicio, :p_fecha_fin, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_capacitacion", id),
                    new OracleParameter("p_nombre_curso", (object?)m.NombreCurso ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_capacitacion", (object?)m.TipoCapacitacion ?? DBNull.Value),
                    new OracleParameter("p_duracion_horas", m.DuracionHoras),
                    new OracleParameter("p_costo", m.Costo),
                    new OracleParameter("p_proveedor", (object?)m.Proveedor ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", m.FechaInicio),
                    new OracleParameter("p_fecha_fin", m.FechaFin),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar Capacitacion: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_capacitaciones.delete_capacitacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar Capacitacion: {ex.Message}"); throw; }
        }
    }
}
