using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class HuellaCarbonoVueloService : IHuellaCarbonoVueloService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public HuellaCarbonoVueloService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<HuellaCarbonoVuelo>> ListarTodo()
        {
            try { return await _replica.HuellaCarbonoVuelo.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo HuellaCarbonoVuelo: {ex.Message}"); return new List<HuellaCarbonoVuelo>(); }
        }

        public async Task<HuellaCarbonoVuelo ?> ObtenerPorId(int id)
        {
            try { return await _replica.HuellaCarbonoVuelo.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId HuellaCarbonoVuelo: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(HuellaCarbonoVuelo m)
        {
            try
            {
                string sql = "BEGIN pkg_huella_carbono_vuelo.insert_huella(:p_id_vuelo, :p_combustible_consumido_litros, :p_factor_emision_co2, :p_co2_emitido_kg, :p_co2_por_pasajero_kg, :p_co2_por_km, :p_distancia_vuelo_km, :p_categoria_vuelo, :p_eficiencia_combustible_kg_km, :p_fecha_calculo, :p_metodo_calculo, :p_certificado_compensacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_combustible_consumido_litros", (object?)m.CombustibleConsumidoLitros ?? DBNull.Value),
                    new OracleParameter("p_factor_emision_co2", (object?)m.FactorEmisionCo2 ?? DBNull.Value),
                    new OracleParameter("p_co2_emitido_kg", (object?)m.Co2EmitidoKg ?? DBNull.Value),
                    new OracleParameter("p_co2_por_pasajero_kg", (object?)m.Co2PorPasajeroKg ?? DBNull.Value),
                    new OracleParameter("p_co2_por_km", (object?)m.Co2PorKm ?? DBNull.Value),
                    new OracleParameter("p_distancia_vuelo_km", (object?)m.DistanciaVueloKm ?? DBNull.Value),
                    new OracleParameter("p_categoria_vuelo", (object?)m.CategoriaVuelo ?? DBNull.Value),
                    new OracleParameter("p_eficiencia_combustible_kg_km", (object?)m.EficienciaCombustibleKgKm ?? DBNull.Value),
                    new OracleParameter("p_fecha_calculo", (object?)m.FechaCalculo ?? DBNull.Value),
                    new OracleParameter("p_metodo_calculo", (object?)m.MetodoCalculo ?? DBNull.Value),
                    new OracleParameter("p_certificado_compensacion", (object?)m.CertificadoCompensacion ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar HuellaCarbonoVuelo: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, HuellaCarbonoVuelo m)
        {
            try
            {
                string sql = "BEGIN pkg_huella_carbono_vuelo.update_huella(:p_id_huella_carbono, :p_id_vuelo, :p_combustible_consumido_litros, :p_factor_emision_co2, :p_co2_emitido_kg, :p_co2_por_pasajero_kg, :p_co2_por_km, :p_distancia_vuelo_km, :p_categoria_vuelo, :p_eficiencia_combustible_kg_km, :p_fecha_calculo, :p_metodo_calculo, :p_certificado_compensacion); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_huella_carbono", id),
                    new OracleParameter("p_id_vuelo", m.IdVuelo),
                    new OracleParameter("p_combustible_consumido_litros", (object?)m.CombustibleConsumidoLitros ?? DBNull.Value),
                    new OracleParameter("p_factor_emision_co2", (object?)m.FactorEmisionCo2 ?? DBNull.Value),
                    new OracleParameter("p_co2_emitido_kg", (object?)m.Co2EmitidoKg ?? DBNull.Value),
                    new OracleParameter("p_co2_por_pasajero_kg", (object?)m.Co2PorPasajeroKg ?? DBNull.Value),
                    new OracleParameter("p_co2_por_km", (object?)m.Co2PorKm ?? DBNull.Value),
                    new OracleParameter("p_distancia_vuelo_km", (object?)m.DistanciaVueloKm ?? DBNull.Value),
                    new OracleParameter("p_categoria_vuelo", (object?)m.CategoriaVuelo ?? DBNull.Value),
                    new OracleParameter("p_eficiencia_combustible_kg_km", (object?)m.EficienciaCombustibleKgKm ?? DBNull.Value),
                    new OracleParameter("p_fecha_calculo", (object?)m.FechaCalculo ?? DBNull.Value),
                    new OracleParameter("p_metodo_calculo", (object?)m.MetodoCalculo ?? DBNull.Value),
                    new OracleParameter("p_certificado_compensacion", (object?)m.CertificadoCompensacion ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar HuellaCarbonoVuelo: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_huella_carbono_vuelo.delete_huella(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar HuellaCarbonoVuelo: {ex.Message}"); throw; }
        }
    }
}
