using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ProyectosEficienciaEnergeticaService : IProyectosEficienciaEnergeticaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ProyectosEficienciaEnergeticaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ProyectosEficienciaEnergetica>> ListarTodo()
        {
            try { return await _replica.ProyectosEficiencia.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ProyectosEficienciaEnergetica: {ex.Message}"); return new List<ProyectosEficienciaEnergetica>(); }
        }

        public async Task<ProyectosEficienciaEnergetica ?> ObtenerPorId(int id)
        {
            try { return await _replica.ProyectosEficiencia.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ProyectosEficienciaEnergetica: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ProyectosEficienciaEnergetica m)
        {
            try
            {
                string sql = "BEGIN pkg_proyectos_eficiencia.insert_proyecto(:p_nombre_proyecto, :p_descripcion, :p_tipo_proyecto, :p_inversion_total, :p_ahorro_energetico_anual_kwh, :p_reduccion_co2_anual_kg, :p_fecha_inicio, :p_fecha_finalizacion, :p_periodo_retorno_anios, :p_estado, :p_responsable_proyecto, :p_resultados_obtenidos); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nombre_proyecto", (object?)m.NombreProyecto ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_proyecto", (object?)m.TipoProyecto ?? DBNull.Value),
                    new OracleParameter("p_inversion_total", (object?)m.InversionTotal ?? DBNull.Value),
                    new OracleParameter("p_ahorro_energetico_anual_kwh", (object?)m.AhorroEnergeticoAnualKwh ?? DBNull.Value),
                    new OracleParameter("p_reduccion_co2_anual_kg", (object?)m.ReduccionCo2AnualKg ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                    new OracleParameter("p_fecha_finalizacion", (object?)m.FechaFinalizacion ?? DBNull.Value),
                    new OracleParameter("p_periodo_retorno_anios", (object?)m.PeriodoRetornoAnios ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_responsable_proyecto", (object?)m.ResponsableProyecto ?? DBNull.Value),
                    new OracleParameter("p_resultados_obtenidos", (object?)m.ResultadosObtenidos ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ProyectosEficienciaEnergetica: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ProyectosEficienciaEnergetica m)
        {
            try
            {
                string sql = "BEGIN pkg_proyectos_eficiencia.update_proyecto(:p_id_proyecto_eficiencia, :p_nombre_proyecto, :p_descripcion, :p_tipo_proyecto, :p_inversion_total, :p_ahorro_energetico_anual_kwh, :p_reduccion_co2_anual_kg, :p_fecha_inicio, :p_fecha_finalizacion, :p_periodo_retorno_anios, :p_estado, :p_responsable_proyecto, :p_resultados_obtenidos); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_proyecto_eficiencia", id),
                    new OracleParameter("p_nombre_proyecto", (object?)m.NombreProyecto ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_proyecto", (object?)m.TipoProyecto ?? DBNull.Value),
                    new OracleParameter("p_inversion_total", (object?)m.InversionTotal ?? DBNull.Value),
                    new OracleParameter("p_ahorro_energetico_anual_kwh", (object?)m.AhorroEnergeticoAnualKwh ?? DBNull.Value),
                    new OracleParameter("p_reduccion_co2_anual_kg", (object?)m.ReduccionCo2AnualKg ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                    new OracleParameter("p_fecha_finalizacion", (object?)m.FechaFinalizacion ?? DBNull.Value),
                    new OracleParameter("p_periodo_retorno_anios", (object?)m.PeriodoRetornoAnios ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_responsable_proyecto", (object?)m.ResponsableProyecto ?? DBNull.Value),
                    new OracleParameter("p_resultados_obtenidos", (object?)m.ResultadosObtenidos ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ProyectosEficienciaEnergetica: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_proyectos_eficiencia.delete_proyecto(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ProyectosEficienciaEnergetica: {ex.Message}"); throw; }
        }
    }
}
