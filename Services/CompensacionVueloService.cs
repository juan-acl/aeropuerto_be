using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CompensacionVueloService : ICompensacionesVueloService
    {
        private readonly DBContext _context;

        public CompensacionVueloService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(CompensacionesVuelo m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_huella_carbono", (object?)m.IdHuellaCarbono ?? DBNull.Value),
                new OracleParameter("p_id_programa_compensacion", (object?)m.IdProgramaCompensacion ?? DBNull.Value),
                new OracleParameter("p_fecha_compensacion", (object?)m.FechaCompensacion ?? DBNull.Value),
                new OracleParameter("p_cantidad_compensada_kg", (object?)m.CantidadCompensadaKg ?? DBNull.Value),
                new OracleParameter("p_porcentaje_compensado", (object?)m.PorcentajeCompensado ?? DBNull.Value),
                new OracleParameter("p_monto_aportado", (object?)m.MontoAportado ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_comprobante_compensacion", (object?)m.ComprobanteCompensacion ?? DBNull.Value),
                new OracleParameter("p_verificada", (object?)m.Verificada ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_compensaciones_vuelo.insert_compensacion(:p_id_huella_carbono, :p_id_programa_compensacion, :p_fecha_compensacion, :p_cantidad_compensada_kg, :p_porcentaje_compensado, :p_monto_aportado, :p_moneda, :p_comprobante_compensacion, :p_verificada); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, CompensacionesVuelo m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_compensacion", (object?)id),
                new OracleParameter("p_id_huella_carbono", (object?)m.IdHuellaCarbono ?? DBNull.Value),
                new OracleParameter("p_id_programa_compensacion", (object?)m.IdProgramaCompensacion ?? DBNull.Value),
                new OracleParameter("p_fecha_compensacion", (object?)m.FechaCompensacion ?? DBNull.Value),
                new OracleParameter("p_cantidad_compensada_kg", (object?)m.CantidadCompensadaKg ?? DBNull.Value),
                new OracleParameter("p_porcentaje_compensado", (object?)m.PorcentajeCompensado ?? DBNull.Value),
                new OracleParameter("p_monto_aportado", (object?)m.MontoAportado ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_comprobante_compensacion", (object?)m.ComprobanteCompensacion ?? DBNull.Value),
                new OracleParameter("p_verificada", (object?)m.Verificada ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_compensaciones_vuelo.update_compensacion(:p_id_compensacion, :p_id_huella_carbono, :p_id_programa_compensacion, :p_fecha_compensacion, :p_cantidad_compensada_kg, :p_porcentaje_compensado, :p_monto_aportado, :p_moneda, :p_comprobante_compensacion, :p_verificada); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_compensaciones_vuelo.delete_compensacion(:p_id_compensacion); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_compensacion", id));
            return true;
        }

        public async Task<List<CompensacionesVuelo>> ListarTodo()
        {
            return await _context.Set<CompensacionesVuelo>().ToListAsync();
        }
        public async Task<CompensacionesVuelo?> ObtenerPorId(int id) => await _context.Set<CompensacionesVuelo>().FindAsync(id);
    }
}
