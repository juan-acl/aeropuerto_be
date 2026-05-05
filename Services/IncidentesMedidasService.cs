using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class IncidentesMedidasService : IIncidentesMedidasService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public IncidentesMedidasService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<IncidentesMedidasModel>> ListarTodo()
        {
            try { return await _replica.IncidentesMedidas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo IncidentesMedidasModel: {ex.Message}"); return new List<IncidentesMedidasModel>(); }
        }

        public async Task<IncidentesMedidasModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.IncidentesMedidas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId IncidentesMedidasModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(IncidentesMedidasModel m)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes_medidas.insert_medida(:p_id_incidente, :p_tipo_medida, :p_descripcion, :p_fecha_aplicacion, :p_aplicado_por, :p_vigencia_dias, :p_fecha_vencimiento, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_incidente", m.IdIncidente),
                    new OracleParameter("p_tipo_medida", (object?)m.TipoMedida ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_fecha_aplicacion", (object?)m.FechaAplicacion ?? DBNull.Value),
                    new OracleParameter("p_aplicado_por", (object?)m.AplicadoPor ?? DBNull.Value),
                    new OracleParameter("p_vigencia_dias", (object?)m.VigenciaDias ?? DBNull.Value),
                    new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar IncidentesMedidasModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, IncidentesMedidasModel m)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes_medidas.update_medida(:p_id_medida, :p_id_incidente, :p_tipo_medida, :p_descripcion, :p_fecha_aplicacion, :p_aplicado_por, :p_vigencia_dias, :p_fecha_vencimiento, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_medida", id),
                    new OracleParameter("p_id_incidente", m.IdIncidente),
                    new OracleParameter("p_tipo_medida", (object?)m.TipoMedida ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_fecha_aplicacion", (object?)m.FechaAplicacion ?? DBNull.Value),
                    new OracleParameter("p_aplicado_por", (object?)m.AplicadoPor ?? DBNull.Value),
                    new OracleParameter("p_vigencia_dias", (object?)m.VigenciaDias ?? DBNull.Value),
                    new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimiento ?? DBNull.Value),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar IncidentesMedidasModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes_medidas.delete_medida(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar IncidentesMedidasModel: {ex.Message}"); throw; }
        }
    }
}
