using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class OfertaPersonalizadaService : IOfertaPersonalizadaService
    {
        private readonly DBContext _context;
        public OfertaPersonalizadaService(DBContext context) => _context = context;

        public async Task<bool> Insertar(OfertasPersonalizadas m)
        {
            var p = new[] {
                new OracleParameter("p_id_segmento_cliente", (object?)m.IdSegmentoCliente ?? DBNull.Value),
                new OracleParameter("p_id_promocion", (object?)m.IdPromocion ?? DBNull.Value),
                new OracleParameter("p_titulo_oferta", (object?)m.TituloOferta ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_condiciones", (object?)m.Condiciones ?? DBNull.Value),
                new OracleParameter("p_descuento_porcentaje", (object?)m.DescuentoPorcentaje ?? DBNull.Value),
                new OracleParameter("p_descuento_fijo", (object?)m.DescuentoFijo ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_prioridad", (object?)m.Prioridad ?? DBNull.Value),
                new OracleParameter("p_visualizaciones", (object?)m.Visualizaciones ?? DBNull.Value),
                new OracleParameter("p_conversiones", (object?)m.Conversiones ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                new OracleParameter("p_creada_por", (object?)m.CreadaPor ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_ofertas_personalizadas.insert_oferta(:p_id_segmento_cliente, :p_id_promocion, :p_titulo_oferta, :p_descripcion, :p_condiciones, :p_descuento_porcentaje, :p_descuento_fijo, :p_fecha_inicio, :p_fecha_fin, :p_prioridad, :p_visualizaciones, :p_conversiones, :p_activa, :p_creada_por, :p_resultados); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, OfertasPersonalizadas m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_oferta_personalizada", m.IdOfertaPersonalizada)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_segmento_cliente", (object?)m.IdSegmentoCliente ?? DBNull.Value),
                new OracleParameter("p_id_promocion", (object?)m.IdPromocion ?? DBNull.Value),
                new OracleParameter("p_titulo_oferta", (object?)m.TituloOferta ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_condiciones", (object?)m.Condiciones ?? DBNull.Value),
                new OracleParameter("p_descuento_porcentaje", (object?)m.DescuentoPorcentaje ?? DBNull.Value),
                new OracleParameter("p_descuento_fijo", (object?)m.DescuentoFijo ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_prioridad", (object?)m.Prioridad ?? DBNull.Value),
                new OracleParameter("p_visualizaciones", (object?)m.Visualizaciones ?? DBNull.Value),
                new OracleParameter("p_conversiones", (object?)m.Conversiones ?? DBNull.Value),
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
                new OracleParameter("p_creada_por", (object?)m.CreadaPor ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_ofertas_personalizadas.update_oferta(:p_id_oferta_personalizada, :p_id_segmento_cliente, :p_id_promocion, :p_titulo_oferta, :p_descripcion, :p_condiciones, :p_descuento_porcentaje, :p_descuento_fijo, :p_fecha_inicio, :p_fecha_fin, :p_prioridad, :p_visualizaciones, :p_conversiones, :p_activa, :p_creada_por, :p_resultados); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_ofertas_personalizadas.delete_oferta(:p_id_oferta_personalizada); END;", 
                new OracleParameter("p_id_oferta_personalizada", id));
            return true;
        }

        public async Task<List<OfertasPersonalizadas>> ListarTodo() => await _context.Set<OfertasPersonalizadas>().ToListAsync();

        public async Task<OfertasPersonalizadas?> ObtenerPorId(int id) => await _context.Set<OfertasPersonalizadas>().FindAsync(id);
    }
}
