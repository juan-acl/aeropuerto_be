using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PromocionesService : IPromocionesService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PromocionesService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PromocionesModel>> ListarTodo()
        {
            try { return await _replica.Promociones.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PromocionesModel: {ex.Message}"); return new List<PromocionesModel>(); }
        }

        public async Task<PromocionesModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.Promociones.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PromocionesModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PromocionesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_promociones.insert_promocion(:p_codigo_promocion, :p_nombre_promocion, :p_descripcion, :p_tipo_descuento, :p_valor_descuento, :p_fecha_inicio, :p_fecha_fin, :p_uso_maximo, :p_usos_actuales, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_promocion", (object?)m.CodigoPromocion ?? DBNull.Value),
                    new OracleParameter("p_nombre_promocion", (object?)m.NombrePromocion ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_descuento", (object?)m.TipoDescuento ?? DBNull.Value),
                    new OracleParameter("p_valor_descuento", m.ValorDescuento),
                    new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                    new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                    new OracleParameter("p_uso_maximo", (object?)m.UsoMaximo ?? DBNull.Value),
                    new OracleParameter("p_usos_actuales", m.UsosActuales),
                    new OracleParameter("p_activa", m.Activa)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PromocionesModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, PromocionesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_promociones.update_promocion(:p_id_promocion, :p_codigo_promocion, :p_nombre_promocion, :p_descripcion, :p_tipo_descuento, :p_valor_descuento, :p_fecha_inicio, :p_fecha_fin, :p_uso_maximo, :p_usos_actuales, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_promocion", id),
                    new OracleParameter("p_codigo_promocion", (object?)m.CodigoPromocion ?? DBNull.Value),
                    new OracleParameter("p_nombre_promocion", (object?)m.NombrePromocion ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_tipo_descuento", (object?)m.TipoDescuento ?? DBNull.Value),
                    new OracleParameter("p_valor_descuento", m.ValorDescuento),
                    new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                    new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                    new OracleParameter("p_uso_maximo", (object?)m.UsoMaximo ?? DBNull.Value),
                    new OracleParameter("p_usos_actuales", m.UsosActuales),
                    new OracleParameter("p_activa", m.Activa)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PromocionesModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_promociones.delete_promocion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PromocionesModel: {ex.Message}"); throw; }
        }
    }
}
