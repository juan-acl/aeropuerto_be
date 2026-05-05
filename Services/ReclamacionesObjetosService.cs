using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ReclamacionesObjetosService : IReclamacionesObjetosService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ReclamacionesObjetosService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ReclamacionesObjetosModel>> ListarTodo()
        {
            try { return await _replica.ReclamacionesObjetos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ReclamacionesObjetosModel: {ex.Message}"); return new List<ReclamacionesObjetosModel>(); }
        }

        public async Task<ReclamacionesObjetosModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.ReclamacionesObjetos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ReclamacionesObjetosModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ReclamacionesObjetosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_reclamaciones_objetos.insert_reclamacion(:p_id_pasajero, :p_id_objeto, :p_fecha_reclamacion, :p_descripcion_reclamacion, :p_estado, :p_fecha_resolucion, :p_resolucion, :p_resuelto_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_objeto", (object?)m.IdObjeto ?? DBNull.Value),
                    new OracleParameter("p_fecha_reclamacion", (object?)m.FechaReclamacion ?? DBNull.Value),
                    new OracleParameter("p_descripcion_reclamacion", (object?)m.DescripcionReclamacion ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_fecha_resolucion", (object?)m.FechaResolucion ?? DBNull.Value),
                    new OracleParameter("p_resolucion", (object?)m.Resolucion ?? DBNull.Value),
                    new OracleParameter("p_resuelto_por", (object?)m.ResueltoPor ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ReclamacionesObjetosModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ReclamacionesObjetosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_reclamaciones_objetos.update_reclamacion(:p_id_reclamacion, :p_id_pasajero, :p_id_objeto, :p_fecha_reclamacion, :p_descripcion_reclamacion, :p_estado, :p_fecha_resolucion, :p_resolucion, :p_resuelto_por); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_reclamacion", id),
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_id_objeto", (object?)m.IdObjeto ?? DBNull.Value),
                    new OracleParameter("p_fecha_reclamacion", (object?)m.FechaReclamacion ?? DBNull.Value),
                    new OracleParameter("p_descripcion_reclamacion", (object?)m.DescripcionReclamacion ?? DBNull.Value),
                    new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                    new OracleParameter("p_fecha_resolucion", (object?)m.FechaResolucion ?? DBNull.Value),
                    new OracleParameter("p_resolucion", (object?)m.Resolucion ?? DBNull.Value),
                    new OracleParameter("p_resuelto_por", (object?)m.ResueltoPor ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ReclamacionesObjetosModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_reclamaciones_objetos.delete_reclamacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ReclamacionesObjetosModel: {ex.Message}"); throw; }
        }
    }
}
