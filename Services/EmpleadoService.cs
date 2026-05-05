using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public EmpleadoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<Empleado>> ListarTodo()
        {
            try { return await _replica.EMPLEADOS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo Empleado: {ex.Message}"); return new List<Empleado>(); }
        }

        public async Task<Empleado ?> ObtenerPorId(int id)
        {
            try { return await _replica.EMPLEADOS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId Empleado: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(Empleado m)
        {
            try
            {
                string sql = "BEGIN pkg_empleados.insert_empleado(:p_codigo_empleado, :p_nombres, :p_apellidos, :p_tipo_documento, :p_numero_documento, :p_fecha_nacimiento, :p_nacionalidad, :p_genero, :p_direccion, :p_telefono, :p_email, :p_fecha_contratacion, :p_departamento, :p_cargo, :p_salario_base, :p_tipo_contrato, :p_activo, :p_foto_empleado); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_empleado", (object?)m.CodigoEmpleado ?? DBNull.Value),
                    new OracleParameter("p_nombres", (object?)m.Nombres ?? DBNull.Value),
                    new OracleParameter("p_apellidos", (object?)m.Apellidos ?? DBNull.Value),
                    new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                    new OracleParameter("p_numero_documento", (object?)m.NumeroDocumento ?? DBNull.Value),
                    new OracleParameter("p_fecha_nacimiento", m.FechaNacimiento),
                    new OracleParameter("p_nacionalidad", (object?)m.Nacionalidad ?? DBNull.Value),
                    new OracleParameter("p_genero", (object?)m.Genero ?? DBNull.Value),
                    new OracleParameter("p_direccion", (object?)m.Direccion ?? DBNull.Value),
                    new OracleParameter("p_telefono", (object?)m.Telefono ?? DBNull.Value),
                    new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                    new OracleParameter("p_fecha_contratacion", m.FechaContratacion),
                    new OracleParameter("p_departamento", (object?)m.Departamento ?? DBNull.Value),
                    new OracleParameter("p_cargo", (object?)m.Cargo ?? DBNull.Value),
                    new OracleParameter("p_salario_base", m.SalarioBase),
                    new OracleParameter("p_tipo_contrato", (object?)m.TipoContrato ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo),
                    new OracleParameter("p_foto_empleado", (object?)m.FotoEmpleado ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar Empleado: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, Empleado m)
        {
            try
            {
                string sql = "BEGIN pkg_empleados.update_empleado(:p_id_empleado, :p_codigo_empleado, :p_nombres, :p_apellidos, :p_tipo_documento, :p_numero_documento, :p_fecha_nacimiento, :p_nacionalidad, :p_genero, :p_direccion, :p_telefono, :p_email, :p_fecha_contratacion, :p_departamento, :p_cargo, :p_salario_base, :p_tipo_contrato, :p_activo, :p_foto_empleado); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_empleado", id),
                    new OracleParameter("p_codigo_empleado", (object?)m.CodigoEmpleado ?? DBNull.Value),
                    new OracleParameter("p_nombres", (object?)m.Nombres ?? DBNull.Value),
                    new OracleParameter("p_apellidos", (object?)m.Apellidos ?? DBNull.Value),
                    new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                    new OracleParameter("p_numero_documento", (object?)m.NumeroDocumento ?? DBNull.Value),
                    new OracleParameter("p_fecha_nacimiento", m.FechaNacimiento),
                    new OracleParameter("p_nacionalidad", (object?)m.Nacionalidad ?? DBNull.Value),
                    new OracleParameter("p_genero", (object?)m.Genero ?? DBNull.Value),
                    new OracleParameter("p_direccion", (object?)m.Direccion ?? DBNull.Value),
                    new OracleParameter("p_telefono", (object?)m.Telefono ?? DBNull.Value),
                    new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                    new OracleParameter("p_fecha_contratacion", m.FechaContratacion),
                    new OracleParameter("p_departamento", (object?)m.Departamento ?? DBNull.Value),
                    new OracleParameter("p_cargo", (object?)m.Cargo ?? DBNull.Value),
                    new OracleParameter("p_salario_base", m.SalarioBase),
                    new OracleParameter("p_tipo_contrato", (object?)m.TipoContrato ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo),
                    new OracleParameter("p_foto_empleado", (object?)m.FotoEmpleado ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar Empleado: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_empleados.delete_empleado(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar Empleado: {ex.Message}"); throw; }
        }
    }
}
