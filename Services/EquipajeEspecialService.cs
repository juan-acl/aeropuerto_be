using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EquipajeEspecialService : IEquipajeEspecialService
    {
        private readonly DBContext _context;
        public EquipajeEspecialService(DBContext context) => _context = context;

        public async Task<List<EquipajeEspecialModel>> ListarTodo()
        {
            try { return await _context.EquipajeEspecial.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EquipajeEspecialModel: {ex.Message}"); return new List<EquipajeEspecialModel>(); }
        }

        public async Task<EquipajeEspecialModel?> ObtenerPorId(int id)
        {
            try { return await _context.EquipajeEspecial.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EquipajeEspecialModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EquipajeEspecialModel m)
        {
            try
            {
                string sql = "BEGIN pkg_equipaje_especial.insert_equipaje(:p_id_reserva, :p_tipo_equipaje, :p_peso_kg, :p_dimensiones, :p_contenido, :p_requiere_autorizacion, :p_autorizado, :p_costo_adicional); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_reserva", m.IdReserva),
                new OracleParameter("p_tipo_equipaje", (object?)m.TipoEquipaje ?? DBNull.Value),
                new OracleParameter("p_peso_kg", m.PesoKg),
                new OracleParameter("p_dimensiones", (object?)m.Dimensiones ?? DBNull.Value),
                new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                new OracleParameter("p_requiere_autorizacion", m.RequiereAutorizacion),
                new OracleParameter("p_autorizado", m.Autorizado),
                new OracleParameter("p_costo_adicional", m.CostoAdicional)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar EquipajeEspecialModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, EquipajeEspecialModel m)
        {
            try
            {
                string sql = "BEGIN pkg_equipaje_especial.update_equipaje(:p_id_equipaje_especial, :p_id_reserva, :p_tipo_equipaje, :p_peso_kg, :p_dimensiones, :p_contenido, :p_requiere_autorizacion, :p_autorizado, :p_costo_adicional); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_equipaje_especial", id),
                new OracleParameter("p_id_reserva", m.IdReserva),
                new OracleParameter("p_tipo_equipaje", (object?)m.TipoEquipaje ?? DBNull.Value),
                new OracleParameter("p_peso_kg", m.PesoKg),
                new OracleParameter("p_dimensiones", (object?)m.Dimensiones ?? DBNull.Value),
                new OracleParameter("p_contenido", (object?)m.Contenido ?? DBNull.Value),
                new OracleParameter("p_requiere_autorizacion", m.RequiereAutorizacion),
                new OracleParameter("p_autorizado", m.Autorizado),
                new OracleParameter("p_costo_adicional", m.CostoAdicional)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar EquipajeEspecialModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_equipaje_especial.delete_equipaje(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar EquipajeEspecialModel: {ex.Message}"); return false; }
        }
    }
}
