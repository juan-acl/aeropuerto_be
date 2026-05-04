using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class OfertasPersonalizadasService : IOfertasPersonalizadasService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public OfertasPersonalizadasService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<OfertasPersonalizadas>> ListarTodo()
        {
            try { return await _replica.OfertasPersonalizadas.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo OfertasPersonalizadas: {ex.Message}"); return new List<OfertasPersonalizadas>(); }
        }

        public async Task<OfertasPersonalizadas ?> ObtenerPorId(int id)
        {
            try { return await _replica.OfertasPersonalizadas.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId OfertasPersonalizadas: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(OfertasPersonalizadas m)
        {
            try
            {
                string sql = "BEGIN pkg_ofertas_personalizadas.insert_oferta(:p_id_segmento_cliente, :p_id_promocion, :p_titulo_oferta, :p_descripcion, :p_condiciones, :p_descuento_porcentaje, :p_descuento_fijo, :p_fecha_inicio, :p_fecha_fin, :p_prioridad, :p_visualizaciones, :p_conversiones, :p_activa, :p_creada_por, :p_resultados); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_segmento_cliente", (object?)m.IdSegmentoCliente ?? DBNull.Value),
                    new OracleParameter("p_id_promocion", (object?)m.IdPromocion ?? DBNull.Value),
                    new OracleParameter("p_titulo_oferta", (object?)m.TituloOferta ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_condiciones", (object?)m.Condiciones ?? DBNull.Value),
                    new OracleParameter("p_descuento_porcentaje", (object?)m.DescuentoPorcentaje ?? DBNull.Value),
                    new OracleParameter("p_descuento_fijo", (object?)m.DescuentoFijo ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", m.FechaInicio),
                    new OracleParameter("p_fecha_fin", m.FechaFin),
                    new OracleParameter("p_prioridad", (object?)m.Prioridad ?? DBNull.Value),
                    new OracleParameter("p_visualizaciones", (object?)m.Visualizaciones ?? DBNull.Value),
                    new OracleParameter("p_conversiones", (object?)m.Conversiones ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                    new OracleParameter("p_creada_por", (object?)m.CreadaPor ?? DBNull.Value),
                    new OracleParameter("p_resultados", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar OfertasPersonalizadas: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, OfertasPersonalizadas m)
        {
            try
            {
                string sql = "BEGIN pkg_ofertas_personalizadas.update_oferta(:p_id_oferta_personalizada, :p_id_segmento_cliente, :p_id_promocion, :p_titulo_oferta, :p_descripcion, :p_condiciones, :p_descuento_porcentaje, :p_descuento_fijo, :p_fecha_inicio, :p_fecha_fin, :p_prioridad, :p_visualizaciones, :p_conversiones, :p_activa, :p_creada_por, :p_resultados); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_oferta_personalizada", id),
                    new OracleParameter("p_id_segmento_cliente", (object?)m.IdSegmentoCliente ?? DBNull.Value),
                    new OracleParameter("p_id_promocion", (object?)m.IdPromocion ?? DBNull.Value),
                    new OracleParameter("p_titulo_oferta", (object?)m.TituloOferta ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_condiciones", (object?)m.Condiciones ?? DBNull.Value),
                    new OracleParameter("p_descuento_porcentaje", (object?)m.DescuentoPorcentaje ?? DBNull.Value),
                    new OracleParameter("p_descuento_fijo", (object?)m.DescuentoFijo ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", m.FechaInicio),
                    new OracleParameter("p_fecha_fin", m.FechaFin),
                    new OracleParameter("p_prioridad", (object?)m.Prioridad ?? DBNull.Value),
                    new OracleParameter("p_visualizaciones", (object?)m.Visualizaciones ?? DBNull.Value),
                    new OracleParameter("p_conversiones", (object?)m.Conversiones ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                    new OracleParameter("p_creada_por", (object?)m.CreadaPor ?? DBNull.Value),
                    new OracleParameter("p_resultados", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar OfertasPersonalizadas: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_ofertas_personalizadas.delete_oferta(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar OfertasPersonalizadas: {ex.Message}"); throw; }
        }
    }
}
