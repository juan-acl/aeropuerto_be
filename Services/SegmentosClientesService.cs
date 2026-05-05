using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class SegmentosClientesService : ISegmentosClientesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public SegmentosClientesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<SegmentosClientes>> ListarTodo()
        {
            try { return await _replica.SegmentosClientes.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo SegmentosClientes: {ex.Message}"); return new List<SegmentosClientes>(); }
        }

        public async Task<SegmentosClientes ?> ObtenerPorId(int id)
        {
            try { return await _replica.SegmentosClientes.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId SegmentosClientes: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(SegmentosClientes m)
        {
            try
            {
                string sql = "BEGIN pkg_segmentos_clientes.insert_segmento(:p_nombre_segmento, :p_descripcion, :p_criterios_json, :p_frecuencia_viajes, :p_clase_preferida, :p_destinos_frecuentes, :p_edad_promedio, :p_nivel_ingresos, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nombre_segmento", (object?)m.NombreSegmento ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_criterios_json", (object?)m.CriteriosJson ?? DBNull.Value),
                    new OracleParameter("p_frecuencia_viajes", (object?)m.FrecuenciaViajes ?? DBNull.Value),
                    new OracleParameter("p_clase_preferida", (object?)m.ClasePreferida ?? DBNull.Value),
                    new OracleParameter("p_destinos_frecuentes", (object?)m.DestinosFrecuentes ?? DBNull.Value),
                    new OracleParameter("p_edad_promedio", (object?)m.EdadPromedio ?? DBNull.Value),
                    new OracleParameter("p_nivel_ingresos", (object?)m.NivelIngresos ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar SegmentosClientes: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, SegmentosClientes m)
        {
            try
            {
                string sql = "BEGIN pkg_segmentos_clientes.update_segmento(:p_id_segmento_cliente, :p_nombre_segmento, :p_descripcion, :p_criterios_json, :p_frecuencia_viajes, :p_clase_preferida, :p_destinos_frecuentes, :p_edad_promedio, :p_nivel_ingresos, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_segmento_cliente", id),
                    new OracleParameter("p_nombre_segmento", (object?)m.NombreSegmento ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_criterios_json", (object?)m.CriteriosJson ?? DBNull.Value),
                    new OracleParameter("p_frecuencia_viajes", (object?)m.FrecuenciaViajes ?? DBNull.Value),
                    new OracleParameter("p_clase_preferida", (object?)m.ClasePreferida ?? DBNull.Value),
                    new OracleParameter("p_destinos_frecuentes", (object?)m.DestinosFrecuentes ?? DBNull.Value),
                    new OracleParameter("p_edad_promedio", (object?)m.EdadPromedio ?? DBNull.Value),
                    new OracleParameter("p_nivel_ingresos", (object?)m.NivelIngresos ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar SegmentosClientes: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_segmentos_clientes.delete_segmento(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar SegmentosClientes: {ex.Message}"); throw; }
        }
    }
}
