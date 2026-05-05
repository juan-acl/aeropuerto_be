using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PuestoTrabajoService : IPuestoTrabajoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PuestoTrabajoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PuestoTrabajo>> ListarTodo()
        {
            try { return await _replica.PUESTOS_TRABAJO.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PuestoTrabajo: {ex.Message}"); return new List<PuestoTrabajo>(); }
        }

        public async Task<PuestoTrabajo ?> ObtenerPorId(int id)
        {
            try { return await _replica.PUESTOS_TRABAJO.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PuestoTrabajo: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PuestoTrabajo m)
        {
            try
            {
                string sql = "BEGIN pkg_puestos_trabajo.insert_puesto(:p_nombre_puesto, :p_id_departamento, :p_nivel_jerarquico, :p_salario_minimo, :p_salario_maximo, :p_descripcion_funciones, :p_requisitos, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nombre_puesto", (object?)m.NombrePuesto ?? DBNull.Value),
                    new OracleParameter("p_id_departamento", m.IdDepartamento),
                    new OracleParameter("p_nivel_jerarquico", m.NivelJerarquico),
                    new OracleParameter("p_salario_minimo", m.SalarioMinimo),
                    new OracleParameter("p_salario_maximo", m.SalarioMaximo),
                    new OracleParameter("p_descripcion_funciones", (object?)m.DescripcionFunciones ?? DBNull.Value),
                    new OracleParameter("p_requisitos", (object?)m.Requisitos ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PuestoTrabajo: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, PuestoTrabajo m)
        {
            try
            {
                string sql = "BEGIN pkg_puestos_trabajo.update_puesto(:p_id_puesto, :p_nombre_puesto, :p_id_departamento, :p_nivel_jerarquico, :p_salario_minimo, :p_salario_maximo, :p_descripcion_funciones, :p_requisitos, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_puesto", id),
                    new OracleParameter("p_nombre_puesto", (object?)m.NombrePuesto ?? DBNull.Value),
                    new OracleParameter("p_id_departamento", m.IdDepartamento),
                    new OracleParameter("p_nivel_jerarquico", m.NivelJerarquico),
                    new OracleParameter("p_salario_minimo", m.SalarioMinimo),
                    new OracleParameter("p_salario_maximo", m.SalarioMaximo),
                    new OracleParameter("p_descripcion_funciones", (object?)m.DescripcionFunciones ?? DBNull.Value),
                    new OracleParameter("p_requisitos", (object?)m.Requisitos ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PuestoTrabajo: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_puestos_trabajo.delete_puesto(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PuestoTrabajo: {ex.Message}"); throw; }
        }
    }
}
