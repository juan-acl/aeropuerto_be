using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public DepartamentoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<Departamento>> ListarTodo()
        {
            try { return await _replica.DEPARTAMENTOS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo Departamento: {ex.Message}"); return new List<Departamento>(); }
        }

        public async Task<Departamento ?> ObtenerPorId(int id)
        {
            try { return await _replica.DEPARTAMENTOS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId Departamento: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(Departamento m)
        {
            try
            {
                string sql = "BEGIN pkg_departamentos.insert_departamento(:p_nombre_departamento, :p_descripcion, :p_ubicacion, :p_presupuesto_anual, :p_gerente_id, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nombre_departamento", (object?)m.Nombre ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                    new OracleParameter("p_presupuesto_anual", (object?)m.PresupuestoAnual ?? DBNull.Value),
                    new OracleParameter("p_gerente_id", (object?)m.GerenteId ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar Departamento: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, Departamento m)
        {
            try
            {
                string sql = "BEGIN pkg_departamentos.update_departamento(:p_id_departamento, :p_nombre_departamento, :p_descripcion, :p_ubicacion, :p_presupuesto_anual, :p_gerente_id, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_departamento", id),
                    new OracleParameter("p_nombre_departamento", (object?)m.Nombre ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                    new OracleParameter("p_presupuesto_anual", (object?)m.PresupuestoAnual ?? DBNull.Value),
                    new OracleParameter("p_gerente_id", (object?)m.GerenteId ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar Departamento: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_departamentos.delete_departamento(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar Departamento: {ex.Message}"); throw; }
        }
    }
}
