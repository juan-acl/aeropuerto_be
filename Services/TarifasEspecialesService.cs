using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TarifasEspecialesService : ITarifasEspecialesService
    {
        private readonly DBContext _context;
        public TarifasEspecialesService(DBContext context) => _context = context;

        public async Task<List<TarifasEspecialesModel>> ListarTodo()
        {
            try { return await _context.TarifasEspeciales.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo TarifasEspecialesModel: {ex.Message}"); return new List<TarifasEspecialesModel>(); }
        }

        public async Task<TarifasEspecialesModel?> ObtenerPorId(int id)
        {
            try { return await _context.TarifasEspeciales.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId TarifasEspecialesModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(TarifasEspecialesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_tarifas_especiales.insert_tarifa(:p_id_aerolinea, :p_nombre_tarifa, :p_descripcion, :p_condiciones, :p_descuento_porcentaje, :p_fecha_inicio, :p_fecha_fin, :p_activa); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_aerolinea", m.IdAerolinea),
                new OracleParameter("p_nombre_tarifa", (object?)m.NombreTarifa ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_condiciones", (object?)m.Condiciones ?? DBNull.Value),
                new OracleParameter("p_descuento_porcentaje", m.DescuentoPorcentaje),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_activa", m.Activa)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar TarifasEspecialesModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, TarifasEspecialesModel m)
        {
            try
            {
                string sql = "BEGIN pkg_tarifas_especiales.update_tarifa(:p_id_tarifa, :p_id_aerolinea, :p_nombre_tarifa, :p_descripcion, :p_condiciones, :p_descuento_porcentaje, :p_fecha_inicio, :p_fecha_fin, :p_activa); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_tarifa", id),
                new OracleParameter("p_id_aerolinea", m.IdAerolinea),
                new OracleParameter("p_nombre_tarifa", (object?)m.NombreTarifa ?? DBNull.Value),
                new OracleParameter("p_descripcion", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_condiciones", (object?)m.Condiciones ?? DBNull.Value),
                new OracleParameter("p_descuento_porcentaje", m.DescuentoPorcentaje),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_activa", m.Activa)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar TarifasEspecialesModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_tarifas_especiales.delete_tarifa(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar TarifasEspecialesModel: {ex.Message}"); return false; }
        }
    }
}
