using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class GruposViajeService : IGruposViajeService
    {
        private readonly DBContext _context;
        public GruposViajeService(DBContext context) => _context = context;

        public async Task<List<GruposViajeModel>> ListarTodo()
        {
            try { return await _context.GruposViaje.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo GruposViajeModel: {ex.Message}"); return new List<GruposViajeModel>(); }
        }

        public async Task<GruposViajeModel?> ObtenerPorId(int id)
        {
            try { return await _context.GruposViaje.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId GruposViajeModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(GruposViajeModel m)
        {
            try
            {
                string sql = "BEGIN pkg_grupos_viaje.insert_grupo(:p_nombre_grupo, :p_tipo_grupo, :p_cantidad_pasajeros, :p_contacto_responsable, :p_telefono_responsable, :p_email_responsable, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_nombre_grupo", (object?)m.NombreGrupo ?? DBNull.Value),
                new OracleParameter("p_tipo_grupo", (object?)m.TipoGrupo ?? DBNull.Value),
                new OracleParameter("p_cantidad_pasajeros", m.CantidadPasajeros),
                new OracleParameter("p_contacto_responsable", (object?)m.ContactoResponsable ?? DBNull.Value),
                new OracleParameter("p_telefono_responsable", (object?)m.TelefonoResponsable ?? DBNull.Value),
                new OracleParameter("p_email_responsable", (object?)m.EmailResponsable ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar GruposViajeModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, GruposViajeModel m)
        {
            try
            {
                string sql = "BEGIN pkg_grupos_viaje.update_grupo(:p_id_grupo, :p_nombre_grupo, :p_tipo_grupo, :p_cantidad_pasajeros, :p_contacto_responsable, :p_telefono_responsable, :p_email_responsable, :p_observaciones); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_grupo", id),
                new OracleParameter("p_nombre_grupo", (object?)m.NombreGrupo ?? DBNull.Value),
                new OracleParameter("p_tipo_grupo", (object?)m.TipoGrupo ?? DBNull.Value),
                new OracleParameter("p_cantidad_pasajeros", m.CantidadPasajeros),
                new OracleParameter("p_contacto_responsable", (object?)m.ContactoResponsable ?? DBNull.Value),
                new OracleParameter("p_telefono_responsable", (object?)m.TelefonoResponsable ?? DBNull.Value),
                new OracleParameter("p_email_responsable", (object?)m.EmailResponsable ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar GruposViajeModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_grupos_viaje.delete_grupo(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar GruposViajeModel: {ex.Message}"); return false; }
        }
    }
}
