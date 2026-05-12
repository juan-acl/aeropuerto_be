using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class HotelesCercanosService : IHotelesCercanosService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public HotelesCercanosService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<HotelesCercanosModel>> ListarTodo()
        {
            try { return await _replica.HotelesCercanos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo HotelesCercanosModel: {ex.Message}"); return new List<HotelesCercanosModel>(); }
        }

        public async Task<List<HotelesCercanosModel>> ListarPorAeropuerto(string codigoAeropuerto)
        {
            try { return await _replica.HotelesCercanos.Where(h => h.CodigoAeropuerto == codigoAeropuerto.ToUpper()).ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarPorAeropuerto HotelesCercanosModel: {ex.Message}"); return new List<HotelesCercanosModel>(); }
        }

        public async Task<HotelesCercanosModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.HotelesCercanos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId HotelesCercanosModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(HotelesCercanosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_hoteles_cercanos.insert_hotel(:p_codigo_aeropuerto, :p_nombre_hotel, :p_categoria, :p_direccion, :p_distancia_km, :p_telefono, :p_email, :p_website, :p_tarifa_noche_desde, :p_tiene_shuttle, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_nombre_hotel", (object?)m.NombreHotel ?? DBNull.Value),
                    new OracleParameter("p_categoria", (object?)m.Categoria ?? DBNull.Value),
                    new OracleParameter("p_direccion", (object?)m.Direccion ?? DBNull.Value),
                    new OracleParameter("p_distancia_km", (object?)m.DistanciaKm ?? DBNull.Value),
                    new OracleParameter("p_telefono", (object?)m.Telefono ?? DBNull.Value),
                    new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                    new OracleParameter("p_website", (object?)m.Website ?? DBNull.Value),
                    new OracleParameter("p_tarifa_noche_desde", (object?)m.TarifaNocheDesde ?? DBNull.Value),
                    new OracleParameter("p_tiene_shuttle", m.TieneShuttle),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar HotelesCercanosModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, HotelesCercanosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_hoteles_cercanos.update_hotel(:p_id_hotel, :p_codigo_aeropuerto, :p_nombre_hotel, :p_categoria, :p_direccion, :p_distancia_km, :p_telefono, :p_email, :p_website, :p_tarifa_noche_desde, :p_tiene_shuttle, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_hotel", id),
                    new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_nombre_hotel", (object?)m.NombreHotel ?? DBNull.Value),
                    new OracleParameter("p_categoria", (object?)m.Categoria ?? DBNull.Value),
                    new OracleParameter("p_direccion", (object?)m.Direccion ?? DBNull.Value),
                    new OracleParameter("p_distancia_km", (object?)m.DistanciaKm ?? DBNull.Value),
                    new OracleParameter("p_telefono", (object?)m.Telefono ?? DBNull.Value),
                    new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                    new OracleParameter("p_website", (object?)m.Website ?? DBNull.Value),
                    new OracleParameter("p_tarifa_noche_desde", (object?)m.TarifaNocheDesde ?? DBNull.Value),
                    new OracleParameter("p_tiene_shuttle", m.TieneShuttle),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar HotelesCercanosModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_hoteles_cercanos.delete_hotel(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar HotelesCercanosModel: {ex.Message}"); throw; }
        }
    }
}
