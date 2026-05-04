using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CompensacionesVueloService : ICompensacionesVueloService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CompensacionesVueloService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CompensacionesVuelo>> ListarTodo()
        {
            try { return await _replica.CompensacionesVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CompensacionesVuelo: {ex.Message}"); return new List<CompensacionesVuelo>(); }
        }

        public async Task<CompensacionesVuelo ?> ObtenerPorId(int id)
        {
            try { return await _replica.CompensacionesVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CompensacionesVuelo: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CompensacionesVuelo m)
        {
            try
            {
                string sql = "BEGIN pkg_compensaciones_vuelo.insert_compensacion(:p_id_huella_carbono, :p_id_programa_compensacion, :p_fecha_compensacion, :p_cantidad_compensada_kg, :p_porcentaje_compensado, :p_monto_aportado, :p_moneda, :p_comprobante_compensacion, :p_verificada); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_huella_carbono", m.IdHuellaCarbono),
                    new OracleParameter("p_id_programa_compensacion", m.IdProgramaCompensacion),
                    new OracleParameter("p_fecha_compensacion", (object?)m.FechaCompensacion ?? DBNull.Value),
                    new OracleParameter("p_cantidad_compensada_kg", (object?)m.CantidadCompensadaKg ?? DBNull.Value),
                    new OracleParameter("p_porcentaje_compensado", (object?)m.PorcentajeCompensado ?? DBNull.Value),
                    new OracleParameter("p_monto_aportado", (object?)m.MontoAportado ?? DBNull.Value),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_comprobante_compensacion", (object?)m.ComprobanteCompensacion ?? DBNull.Value),
                    new OracleParameter("p_verificada", (object?)m.Verificada ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar CompensacionesVuelo: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, CompensacionesVuelo m)
        {
            try
            {
                string sql = "BEGIN pkg_compensaciones_vuelo.update_compensacion(:p_id_compensacion_vuelo, :p_id_huella_carbono, :p_id_programa_compensacion, :p_fecha_compensacion, :p_cantidad_compensada_kg, :p_porcentaje_compensado, :p_monto_aportado, :p_moneda, :p_comprobante_compensacion, :p_verificada); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_compensacion_vuelo", id),
                    new OracleParameter("p_id_huella_carbono", m.IdHuellaCarbono),
                    new OracleParameter("p_id_programa_compensacion", m.IdProgramaCompensacion),
                    new OracleParameter("p_fecha_compensacion", (object?)m.FechaCompensacion ?? DBNull.Value),
                    new OracleParameter("p_cantidad_compensada_kg", (object?)m.CantidadCompensadaKg ?? DBNull.Value),
                    new OracleParameter("p_porcentaje_compensado", (object?)m.PorcentajeCompensado ?? DBNull.Value),
                    new OracleParameter("p_monto_aportado", (object?)m.MontoAportado ?? DBNull.Value),
                    new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                    new OracleParameter("p_comprobante_compensacion", (object?)m.ComprobanteCompensacion ?? DBNull.Value),
                    new OracleParameter("p_verificada", (object?)m.Verificada ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar CompensacionesVuelo: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_compensaciones_vuelo.delete_compensacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar CompensacionesVuelo: {ex.Message}"); throw; }
        }
    }
}
