using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PromocionesService : IPromocionesService
    {
        private readonly DBContext _context;

        public PromocionesService(DBContext context) => _context = context;

        public async Task<bool> Insertar(PromocionesModel p)
        {
            var sql = @"INSERT INTO promociones 
                        (codigo_promocion, nombre_promocion, descripcion, tipo_descuento, valor_descuento, fecha_inicio, fecha_fin, uso_maximo, activa) 
                        VALUES (:p_cod, :p_nom, :p_desc, :p_tipo, :p_val, :p_ini, :p_fin, :p_max, :p_act)";

            var parametros = new[] {
                new OracleParameter("p_cod", p.CodigoPromocion?.ToUpper()),
                new OracleParameter("p_nom", (object?)p.NombrePromocion ?? DBNull.Value),
                new OracleParameter("p_desc", (object?)p.Descripcion ?? DBNull.Value),
                new OracleParameter("p_tipo", p.TipoDescuento),
                new OracleParameter("p_val", p.ValorDescuento),
                new OracleParameter("p_ini", (object?)p.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fin", (object?)p.FechaFin ?? DBNull.Value),
                new OracleParameter("p_max", (object?)p.UsoMaximo ?? DBNull.Value),
                new OracleParameter("p_act", p.Activa)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<PromocionesModel>> ListarTodas()
        {
            return await _context.Promociones.ToListAsync();
        }

        public async Task<PromocionesModel?> ObtenerPorCodigo(string codigo)
        {
            return await _context.Promociones
                .FirstOrDefaultAsync(p => p.CodigoPromocion == codigo.ToUpper() && p.Activa == 1);
        }

        public async Task<bool> Actualizar(int id, PromocionesModel p)
        {
            var sql = @"UPDATE promociones 
                        SET nombre_promocion = :p_nom, descripcion = :p_desc, 
                            tipo_descuento = :p_tipo, valor_descuento = :p_val, 
                            fecha_inicio = :p_ini, fecha_fin = :p_fin, 
                            uso_maximo = :p_max, activa = :p_act 
                        WHERE id_promocion = :p_id";

            var parametros = new[] {
                new OracleParameter("p_nom", p.NombrePromocion),
                new OracleParameter("p_desc", p.Descripcion),
                new OracleParameter("p_tipo", p.TipoDescuento),
                new OracleParameter("p_val", p.ValorDescuento),
                new OracleParameter("p_ini", p.FechaInicio),
                new OracleParameter("p_fin", p.FechaFin),
                new OracleParameter("p_max", p.UsoMaximo),
                new OracleParameter("p_act", p.Activa),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM promociones WHERE id_promocion = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}