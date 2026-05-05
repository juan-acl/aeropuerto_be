using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class BodegaCargaService : IBodegaCargaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public BodegaCargaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<BodegaCarga>> ListarTodo()
        {
            try { return await _replica.BODEGAS_CARGA.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo BodegaCarga: {ex.Message}"); return new List<BodegaCarga>(); }
        }

        public async Task<BodegaCarga ?> ObtenerPorId(int id)
        {
            try { return await _replica.BODEGAS_CARGA.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId BodegaCarga: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(BodegaCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_bodegas_carga.insert_bodega(:p_codigo_bodega, :p_nombre_bodega, :p_ubicacion, :p_capacidad_m3, :p_capacidad_kg, :p_tiene_refrigeracion, :p_temperatura_controlada, :p_tiene_acceso_restringido, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_bodega", DBNull.Value),
                    new OracleParameter("p_nombre_bodega", (object?)m.NombreBodega ?? DBNull.Value),
                    new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                    new OracleParameter("p_capacidad_m3", DBNull.Value),
                    new OracleParameter("p_capacidad_kg", DBNull.Value),
                    new OracleParameter("p_tiene_refrigeracion", DBNull.Value),
                    new OracleParameter("p_temperatura_controlada", DBNull.Value),
                    new OracleParameter("p_tiene_acceso_restringido", DBNull.Value),
                    new OracleParameter("p_activo", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar BodegaCarga: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, BodegaCarga m)
        {
            try
            {
                string sql = "BEGIN pkg_bodegas_carga.update_bodega(:p_id_bodega, :p_codigo_bodega, :p_nombre_bodega, :p_ubicacion, :p_capacidad_m3, :p_capacidad_kg, :p_tiene_refrigeracion, :p_temperatura_controlada, :p_tiene_acceso_restringido, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_bodega", id),
                    new OracleParameter("p_codigo_bodega", DBNull.Value),
                    new OracleParameter("p_nombre_bodega", (object?)m.NombreBodega ?? DBNull.Value),
                    new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                    new OracleParameter("p_capacidad_m3", DBNull.Value),
                    new OracleParameter("p_capacidad_kg", DBNull.Value),
                    new OracleParameter("p_tiene_refrigeracion", DBNull.Value),
                    new OracleParameter("p_temperatura_controlada", DBNull.Value),
                    new OracleParameter("p_tiene_acceso_restringido", DBNull.Value),
                    new OracleParameter("p_activo", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar BodegaCarga: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_bodegas_carga.delete_bodega(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar BodegaCarga: {ex.Message}"); throw; }
        }
    }
}
