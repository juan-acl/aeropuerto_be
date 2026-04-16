using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ObjetosPerdidosService : IObjetosPerdidosService
    {
        private readonly DBContext _context;

        public ObjetosPerdidosService(DBContext context) => _context = context;

        public async Task<bool> RegistrarObjeto(ObjetosPerdidosModel m)
        {
            var sql = @"INSERT INTO objetos_perdidos 
                        (descripcion, categoria_objeto, fecha_reporte, hora_reporte, 
                         lugar_encontrado, ubicacion_detallada, id_vuelo, codigo_aeropuerto, 
                         color, marca, modelo, numero_serie, valor_estimado, encontrado_por, 
                         ubicacion_actual, estado, observaciones, foto_objeto) 
                        VALUES (:p_desc, :p_cat, SYSDATE, SYSTIMESTAMP, :p_lugar, :p_udetal, 
                                :p_vuelo, :p_aero, :p_col, :p_mar, :p_mod, :p_num, :p_val, 
                                :p_enc, :p_uact, 'ENCONTRADO', :p_obs, :p_foto)";

            var parametros = new[] {
                new OracleParameter("p_desc", m.Descripcion),
                new OracleParameter("p_cat", (object?)m.CategoriaObjeto ?? DBNull.Value),
                new OracleParameter("p_lugar", (object?)m.LugarEncontrado ?? DBNull.Value),
                new OracleParameter("p_udetal", (object?)m.UbicacionDetallada ?? DBNull.Value),
                new OracleParameter("p_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_aero", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_col", (object?)m.Color ?? DBNull.Value),
                new OracleParameter("p_mar", (object?)m.Marca ?? DBNull.Value),
                new OracleParameter("p_mod", (object?)m.Modelo ?? DBNull.Value),
                new OracleParameter("p_num", (object?)m.NumeroSerie ?? DBNull.Value),
                new OracleParameter("p_val", (object?)m.ValorEstimado ?? DBNull.Value),
                new OracleParameter("p_enc", (object?)m.EncontradoPor ?? DBNull.Value),
                new OracleParameter("p_uact", (object?)m.UbicacionActual ?? DBNull.Value),
                new OracleParameter("p_obs", (object?)m.Observaciones ?? DBNull.Value),
                new OracleParameter("p_foto", (object?)m.FotoObjeto ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<ObjetosPerdidosModel>> ListarNoEntregados(string? codigoAeropuerto = null)
        {
            var query = _context.ObjetosPerdidos
                .Where(o => o.Estado == "ENCONTRADO" || o.Estado == "EN_PROCESO");

            if (!string.IsNullOrEmpty(codigoAeropuerto))
            {
                query = query.Where(o => o.CodigoAeropuerto == codigoAeropuerto);
            }

            // Usamos proyección para omitir el BLOB en la lista general
            return await query
                .Select(o => new ObjetosPerdidosModel
                {
                    IdObjeto = o.IdObjeto,
                    Descripcion = o.Descripcion,
                    CategoriaObjeto = o.CategoriaObjeto,
                    FechaReporte = o.FechaReporte,
                    LugarEncontrado = o.LugarEncontrado,
                    Marca = o.Marca,
                    Color = o.Color,
                    Estado = o.Estado,
                    UbicacionActual = o.UbicacionActual,
                    FotoObjeto = null // Omitimos el binario aquí
                })
                .OrderByDescending(o => o.FechaReporte)
                .ToListAsync();
        }

        public async Task<ObjetosPerdidosModel?> ObtenerFoto(int id)
        {
            return await _context.ObjetosPerdidos
                .Where(o => o.IdObjeto == id)
                .Select(o => new ObjetosPerdidosModel { FotoObjeto = o.FotoObjeto })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> EntregarObjeto(int id, int idPasajero)
        {
            var sql = @"UPDATE objetos_perdidos 
                        SET estado = 'ENTREGADO', 
                            fecha_entrega = SYSDATE, 
                            id_pasajero_entrega = :p_pas 
                        WHERE id_objeto = :p_id";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_pas", idPasajero),
                new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM objetos_perdidos WHERE id_objeto = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}