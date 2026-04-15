using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class HuellaCarbonoVueloService : IHuellaCarbonoVueloService
    {
        private readonly DBContext _context;

        public HuellaCarbonoVueloService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(HuellaCarbonoVuelo m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
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
                new OracleParameter("p_certificado_compensacion", (object?)m.CertificadoCompensacion ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_huella_carbono_vuelo.insert_huella(:p_id_vuelo, :p_combustible_consumido_litros, :p_factor_emision_co2, :p_co2_emitido_kg, :p_co2_por_pasajero_kg, :p_co2_por_km, :p_distancia_vuelo_km, :p_categoria_vuelo, :p_eficiencia_combustible_kg_km, :p_fecha_calculo, :p_metodo_calculo, :p_certificado_compensacion); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, HuellaCarbonoVuelo m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_huella", (object?)id),
                new OracleParameter("p_id_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
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
                new OracleParameter("p_certificado_compensacion", (object?)m.CertificadoCompensacion ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_huella_carbono_vuelo.update_huella(:p_id_huella, :p_id_vuelo, :p_combustible_consumido_litros, :p_factor_emision_co2, :p_co2_emitido_kg, :p_co2_por_pasajero_kg, :p_co2_por_km, :p_distancia_vuelo_km, :p_categoria_vuelo, :p_eficiencia_combustible_kg_km, :p_fecha_calculo, :p_metodo_calculo, :p_certificado_compensacion); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_huella_carbono_vuelo.delete_huella(:p_id_huella); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_huella", id));
            return true;
        }

        public async Task<List<HuellaCarbonoVuelo>> ListarTodo()
        {
            return await _context.Set<HuellaCarbonoVuelo>().ToListAsync();
        }

        public async Task<HuellaCarbonoVuelo?> ObtenerPorId(int id) => await _context.Set<HuellaCarbonoVuelo>().FindAsync(id);
    }
}
