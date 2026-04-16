using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class HotelesCercanosService : IHotelesCercanosService
    {
        private readonly DBContext _context;

        public HotelesCercanosService(DBContext context) => _context = context;

        public async Task<bool> RegistrarHotel(HotelesCercanosModel m)
        {
            var sql = @"INSERT INTO hoteles_cercanos 
                        (codigo_aeropuerto, nombre_hotel, categoria, direccion, distancia_km, 
                         telefono, email, website, tarifa_noche_desde, tiene_shuttle, activo) 
                        VALUES (:p_aero, :p_nom, :p_cat, :p_dir, :p_dist, 
                                :p_tel, :p_email, :p_web, :p_tarifa, :p_shut, 1)";

            var parametros = new[] {
                new OracleParameter("p_aero", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_nom", (object?)m.NombreHotel ?? DBNull.Value),
                new OracleParameter("p_cat", m.Categoria),
                new OracleParameter("p_dir", (object?)m.Direccion ?? DBNull.Value),
                new OracleParameter("p_dist", (object?)m.DistanciaKm ?? DBNull.Value),
                new OracleParameter("p_tel", (object?)m.Telefono ?? DBNull.Value),
                new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                new OracleParameter("p_web", (object?)m.Website ?? DBNull.Value),
                new OracleParameter("p_tarifa", (object?)m.TarifaNocheDesde ?? DBNull.Value),
                new OracleParameter("p_shut", m.TieneShuttle)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<HotelesCercanosModel>> ListarPorAeropuerto(string codigoAeropuerto)
        {
            return await _context.HotelesCercanos
                .Where(h => h.CodigoAeropuerto == codigoAeropuerto)
                .OrderBy(h => h.DistanciaKm)
                .ToListAsync();
        }

        public async Task<List<HotelesCercanosModel>> ListarTodo()
        {
            return await _context.HotelesCercanos
                .OrderBy(h => h.DistanciaKm)
                .ToListAsync();
        }

        public async Task<List<HotelesCercanosModel>> ListarActivos(string codigoAeropuerto, bool? conShuttle = null)
        {
            var query = _context.HotelesCercanos
                .Where(h => h.CodigoAeropuerto == codigoAeropuerto && h.Activo == 1);

            // Filtro dinámico si el usuario solo quiere hoteles que incluyan transporte al aeropuerto
            if (conShuttle.HasValue && conShuttle.Value)
            {
                query = query.Where(h => h.TieneShuttle == 1);
            }

            return await query
                .OrderBy(h => h.DistanciaKm) // Siempre ordenamos del más cercano al más lejano
                .ToListAsync();
        }

        public async Task<bool> DesactivarHotel(int id)
        {
            var sql = "UPDATE hoteles_cercanos SET activo = 0 WHERE id_hotel = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM hoteles_cercanos WHERE id_hotel = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}