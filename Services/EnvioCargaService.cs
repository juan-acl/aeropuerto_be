using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EnvioCargaService : IEnvioCargaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public EnvioCargaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<EnvioCarga>> ListarTodo()
        {
            try { return await _replica.ENVIOS_CARGA.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EnvioCarga: {ex.Message}"); return new List<EnvioCarga>(); }
        }

        public async Task<EnvioCarga ?> ObtenerPorId(int id)
        {
            try { return await _replica.ENVIOS_CARGA.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EnvioCarga: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EnvioCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_envios_carga.insert_envio(:p_codigo_envio, :p_id_vuelo, :p_id_tipo_carga, :p_peso_kg, :p_volumen_m3, :p_cantidad_bultos, :p_contenido, :p_valor_declarado, :p_moneda, :p_consignador_nombre, :p_consignador_documento, :p_consignatario_nombre, :p_consignatario_documento, :p_instrucciones_especiales, :p_fecha_recepcion, :p_fecha_embarque, :p_estado, :p_ubicacion_actual); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_envio", DBNull.Value),
                    new OracleParameter("p_id_vuelo", DBNull.Value),
                    new OracleParameter("p_id_tipo_carga", DBNull.Value),
                    new OracleParameter("p_peso_kg", DBNull.Value),
                    new OracleParameter("p_volumen_m3", DBNull.Value),
                    new OracleParameter("p_cantidad_bultos", DBNull.Value),
                    new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                    new OracleParameter("p_valor_declarado", DBNull.Value),
                    new OracleParameter("p_moneda", DBNull.Value),
                    new OracleParameter("p_consignador_nombre", DBNull.Value),
                    new OracleParameter("p_consignador_documento", DBNull.Value),
                    new OracleParameter("p_consignatario_nombre", DBNull.Value),
                    new OracleParameter("p_consignatario_documento", DBNull.Value),
                    new OracleParameter("p_instrucciones_especiales", DBNull.Value),
                    new OracleParameter("p_fecha_recepcion", DBNull.Value),
                    new OracleParameter("p_fecha_embarque", DBNull.Value),
                    new OracleParameter("p_estado", DBNull.Value),
                    new OracleParameter("p_ubicacion_actual", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar EnvioCarga: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, EnvioCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_envios_carga.update_envio(:p_id_envio, :p_codigo_envio, :p_id_vuelo, :p_id_tipo_carga, :p_peso_kg, :p_volumen_m3, :p_cantidad_bultos, :p_contenido, :p_valor_declarado, :p_moneda, :p_consignador_nombre, :p_consignador_documento, :p_consignatario_nombre, :p_consignatario_documento, :p_instrucciones_especiales, :p_fecha_recepcion, :p_fecha_embarque, :p_estado, :p_ubicacion_actual); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_envio", id),
                    new OracleParameter("p_codigo_envio", DBNull.Value),
                    new OracleParameter("p_id_vuelo", DBNull.Value),
                    new OracleParameter("p_id_tipo_carga", DBNull.Value),
                    new OracleParameter("p_peso_kg", DBNull.Value),
                    new OracleParameter("p_volumen_m3", DBNull.Value),
                    new OracleParameter("p_cantidad_bultos", DBNull.Value),
                    new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                    new OracleParameter("p_valor_declarado", DBNull.Value),
                    new OracleParameter("p_moneda", DBNull.Value),
                    new OracleParameter("p_consignador_nombre", DBNull.Value),
                    new OracleParameter("p_consignador_documento", DBNull.Value),
                    new OracleParameter("p_consignatario_nombre", DBNull.Value),
                    new OracleParameter("p_consignatario_documento", DBNull.Value),
                    new OracleParameter("p_instrucciones_especiales", DBNull.Value),
                    new OracleParameter("p_fecha_recepcion", DBNull.Value),
                    new OracleParameter("p_fecha_embarque", DBNull.Value),
                    new OracleParameter("p_estado", DBNull.Value),
                    new OracleParameter("p_ubicacion_actual", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar EnvioCarga: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_envios_carga.delete_envio(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar EnvioCarga: {ex.Message}"); throw; }
        }
    }
}
