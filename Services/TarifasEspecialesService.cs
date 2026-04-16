using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class TarifasEspecialesService : ITarifasEspecialesService
    {
        private readonly DBContext _context;

        public TarifasEspecialesService(DBContext context) => _context = context;

        public async Task<bool> Insertar(TarifasEspecialesModel m)
        {
            var sql = @"INSERT INTO tarifas_especiales 
                        (id_aerolinea, nombre_tarifa, descripcion, condiciones, descuento_porcentaje, fecha_inicio, fecha_fin, activa) 
                        VALUES (:p_aero, :p_nombre, :p_desc, :p_cond, :p_desc_porc, :p_f_ini, :p_f_fin, :p_activa)";

            var parametros = new[] {
                new OracleParameter("p_aero", m.IdAerolinea),
                new OracleParameter("p_nombre", m.NombreTarifa),
                new OracleParameter("p_desc", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_cond", (object?)m.Condiciones ?? DBNull.Value),
                new OracleParameter("p_desc_porc", m.DescuentoPorcentaje),
                new OracleParameter("p_f_ini", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_f_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_activa", m.Activa)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<TarifasEspecialesModel>> ListarPorAerolinea(int idAerolinea)
        {
            return await _context.TarifasEspeciales
                .Where(t => t.IdAerolinea == idAerolinea)
                .ToListAsync();
        }

        public async Task<List<TarifasEspecialesModel>> ListarActivas()
        {
            return await _context.TarifasEspeciales
                .Where(t => t.Activa == 1 && (t.FechaFin == null || t.FechaFin >= DateTime.Now))
                .ToListAsync();
        }

        public async Task<bool> Actualizar(int id, TarifasEspecialesModel m)
        {
            var sql = @"UPDATE tarifas_especiales 
                        SET nombre_tarifa = :p_nombre, descripcion = :p_desc, condiciones = :p_cond, 
                            descuento_porcentaje = :p_desc_porc, fecha_inicio = :p_f_ini, 
                            fecha_fin = :p_f_fin, activa = :p_activa 
                        WHERE id_tarifa = :p_id";

            var parametros = new[] {
                new OracleParameter("p_nombre", m.NombreTarifa),
                new OracleParameter("p_desc", m.Descripcion),
                new OracleParameter("p_cond", m.Condiciones),
                new OracleParameter("p_desc_porc", m.DescuentoPorcentaje),
                new OracleParameter("p_f_ini", m.FechaInicio),
                new OracleParameter("p_f_fin", m.FechaFin),
                new OracleParameter("p_activa", m.Activa),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM tarifas_especiales WHERE id_tarifa = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}