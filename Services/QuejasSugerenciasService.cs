using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class QuejasSugerenciasService : IQuejasSugerenciasService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public QuejasSugerenciasService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<QuejasSugerenciasModel>> ListarTodo()
        {
            try { return await _replica.QuejasSugerencias.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo QuejasSugerenciasModel: {ex.Message}"); return new List<QuejasSugerenciasModel>(); }
        }

        public async Task<QuejasSugerenciasModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.QuejasSugerencias.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId QuejasSugerenciasModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(QuejasSugerenciasModel m)
        {
            try
            {
                string sql = "BEGIN pkg_quejas_sugerencias.insert_queja(:p_id_pasajero, :p_id_vuelo, :p_tipo_contacto, :p_fecha_contacto, :p_medio_recepcion, :p_descripcion, :p_area_relacionada, :p_estado, :p_fecha_respuesta, :p_respuesta, :p_satisfaccion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_tipo_contacto", (object?)m.TipoContacto ?? DBNull.Value),
                    new OracleParameter("p_fecha_contacto", (object?)m.FechaContacto ?? DBNull.Value),
                    new OracleParameter("p_medio_recepcion", (object?)m.MedioRecepcion ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_area_relacionada", (object?)m.AreaRelacionada ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_fecha_respuesta", (object?)m.FechaRespuesta ?? DBNull.Value),
                    new OracleParameter("p_respuesta", (object?)m.Respuesta ?? DBNull.Value),
                    new OracleParameter("p_satisfaccion", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar QuejasSugerenciasModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, QuejasSugerenciasModel m)
        {
            try
            {
                string sql = "BEGIN pkg_quejas_sugerencias.update_queja(:p_id_queja, :p_id_pasajero, :p_id_vuelo, :p_tipo_contacto, :p_fecha_contacto, :p_medio_recepcion, :p_descripcion, :p_area_relacionada, :p_estado, :p_fecha_respuesta, :p_respuesta, :p_satisfaccion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_queja", id),
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                    new OracleParameter("p_tipo_contacto", (object?)m.TipoContacto ?? DBNull.Value),
                    new OracleParameter("p_fecha_contacto", (object?)m.FechaContacto ?? DBNull.Value),
                    new OracleParameter("p_medio_recepcion", (object?)m.MedioRecepcion ?? DBNull.Value),
                    new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                    new OracleParameter("p_area_relacionada", (object?)m.AreaRelacionada ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_fecha_respuesta", (object?)m.FechaRespuesta ?? DBNull.Value),
                    new OracleParameter("p_respuesta", (object?)m.Respuesta ?? DBNull.Value),
                    new OracleParameter("p_satisfaccion", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar QuejasSugerenciasModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_quejas_sugerencias.delete_queja(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar QuejasSugerenciasModel: {ex.Message}"); throw; }
        }
    }
}
