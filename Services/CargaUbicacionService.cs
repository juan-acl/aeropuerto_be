using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class CargaUbicacionService : ICargaUbicacionService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public CargaUbicacionService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<CargaUbicacion>> ListarTodo()
        {
            try { return await _replica.CARGA_UBICACION.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo CargaUbicacion: {ex.Message}"); return new List<CargaUbicacion>(); }
        }

        public async Task<CargaUbicacion ?> ObtenerPorId(int id)
        {
            try { return await _replica.CARGA_UBICACION.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId CargaUbicacion: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(CargaUbicacion m)
        {
            try
            {
                string sql = "BEGIN pkg_carga_ubicacion.insert_ubicacion(:p_id_envio, :p_id_bodega, :p_fecha_ingreso, :p_fecha_salida, :p_posicion_estante, :p_posicion_fila, :p_posicion_columna, :p_responsable_ingreso, :p_responsable_salida); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_envio", m.IdEnvio),
                    new OracleParameter("p_id_bodega", m.IdBodega),
                    new OracleParameter("p_fecha_ingreso", m.FechaIngreso),
                    new OracleParameter("p_fecha_salida", (object?)m.FechaSalida ?? DBNull.Value),
                    new OracleParameter("p_posicion_estante", DBNull.Value),
                    new OracleParameter("p_posicion_fila", DBNull.Value),
                    new OracleParameter("p_posicion_columna", DBNull.Value),
                    new OracleParameter("p_responsable_ingreso", DBNull.Value),
                    new OracleParameter("p_responsable_salida", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar CargaUbicacion: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, CargaUbicacion m)
        {
            try
            {
                string sql = "BEGIN pkg_carga_ubicacion.update_ubicacion(:p_id_ubicacion, :p_id_envio, :p_id_bodega, :p_fecha_ingreso, :p_fecha_salida, :p_posicion_estante, :p_posicion_fila, :p_posicion_columna, :p_responsable_ingreso, :p_responsable_salida); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_ubicacion", id),
                    new OracleParameter("p_id_envio", m.IdEnvio),
                    new OracleParameter("p_id_bodega", m.IdBodega),
                    new OracleParameter("p_fecha_ingreso", m.FechaIngreso),
                    new OracleParameter("p_fecha_salida", (object?)m.FechaSalida ?? DBNull.Value),
                    new OracleParameter("p_posicion_estante", DBNull.Value),
                    new OracleParameter("p_posicion_fila", DBNull.Value),
                    new OracleParameter("p_posicion_columna", DBNull.Value),
                    new OracleParameter("p_responsable_ingreso", DBNull.Value),
                    new OracleParameter("p_responsable_salida", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar CargaUbicacion: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_carga_ubicacion.delete_ubicacion(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar CargaUbicacion: {ex.Message}"); throw; }
        }
    }
}
