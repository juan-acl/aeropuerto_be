using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class SegmentoClienteService : ISegmentoClienteService
    {
        private readonly DBContext _context;
        public SegmentoClienteService(DBContext context) => _context = context;

        public async Task<bool> Insertar(SegmentosClientes m)
        {
            var p = new[] {
                new OracleParameter("p_nombre_segmento", (object?)m.NombreSegmento ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_criterios_json", (object?)m.CriteriosJson ?? DBNull.Value),
                new OracleParameter("p_frecuencia_viajes", (object?)m.FrecuenciaViajes ?? DBNull.Value),
                new OracleParameter("p_clase_preferida", (object?)m.ClasePreferida ?? DBNull.Value),
                new OracleParameter("p_destinos_frecuentes", (object?)m.DestinosFrecuentes ?? DBNull.Value),
                new OracleParameter("p_edad_promedio", (object?)m.EdadPromedio ?? DBNull.Value),
                new OracleParameter("p_nivel_ingresos", (object?)m.NivelIngresos ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_segmentos_clientes.insert_segmento(:p_nombre_segmento, :p_descripcion, :p_criterios_json, :p_frecuencia_viajes, :p_clase_preferida, :p_destinos_frecuentes, :p_edad_promedio, :p_nivel_ingresos, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, SegmentosClientes m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_segmento_cliente", m.IdSegmentoCliente)
            };
            p.AddRange(new[] {
                new OracleParameter("p_nombre_segmento", (object?)m.NombreSegmento ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_criterios_json", (object?)m.CriteriosJson ?? DBNull.Value),
                new OracleParameter("p_frecuencia_viajes", (object?)m.FrecuenciaViajes ?? DBNull.Value),
                new OracleParameter("p_clase_preferida", (object?)m.ClasePreferida ?? DBNull.Value),
                new OracleParameter("p_destinos_frecuentes", (object?)m.DestinosFrecuentes ?? DBNull.Value),
                new OracleParameter("p_edad_promedio", (object?)m.EdadPromedio ?? DBNull.Value),
                new OracleParameter("p_nivel_ingresos", (object?)m.NivelIngresos ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_segmentos_clientes.update_segmento(:p_id_segmento_cliente, :p_nombre_segmento, :p_descripcion, :p_criterios_json, :p_frecuencia_viajes, :p_clase_preferida, :p_destinos_frecuentes, :p_edad_promedio, :p_nivel_ingresos, :p_activo); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_segmentos_clientes.delete_segmento(:p_id_segmento_cliente); END;", 
                new OracleParameter("p_id_segmento_cliente", id));
            return true;
        }

        public async Task<List<SegmentosClientes>> ListarTodo() => await _context.Set<SegmentosClientes>().ToListAsync();

        public async Task<SegmentosClientes?> ObtenerPorId(int id) => await _context.Set<SegmentosClientes>().FindAsync(id);
    }
}
