using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PerfilViajeroService : IPerfilViajeroService
    {
        private readonly DBContext _context;
        public PerfilViajeroService(DBContext context) => _context = context;

        public async Task<List<PerfilViajeroModel>> ListarTodo()
        {
            try { return await _context.PerfilesViajero.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PerfilViajeroModel: {ex.Message}"); return new List<PerfilViajeroModel>(); }
        }

        public async Task<PerfilViajeroModel?> ObtenerPorId(int id)
        {
            try { return await _context.PerfilesViajero.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PerfilViajeroModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PerfilViajeroModel m)
        {
            try
            {
                string sql = "BEGIN pkg_perfiles_viajero.insert_perfil(:p_id_pasajero, :p_tipo_perfil, :p_numero_programa, :p_aerolinea_asociada, :p_puntos_acumulados, :p_categoria, :p_fecha_ingreso, :p_fecha_ultima_actividad); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_tipo_perfil", (object?)m.TipoPerfil ?? DBNull.Value),
                new OracleParameter("p_numero_programa", (object?)m.NumeroPrograma ?? DBNull.Value),
                new OracleParameter("p_aerolinea_asociada", (object?)m.AerolineaAsociada ?? DBNull.Value),
                new OracleParameter("p_puntos_acumulados", m.PuntosAcumulados),
                new OracleParameter("p_categoria", (object?)m.Categoria ?? DBNull.Value),
                new OracleParameter("p_fecha_ingreso", (object?)m.FechaIngreso ?? DBNull.Value),
                new OracleParameter("p_fecha_ultima_actividad", (object?)m.FechaUltimaActividad ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PerfilViajeroModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, PerfilViajeroModel m)
        {
            try
            {
                string sql = "BEGIN pkg_perfiles_viajero.update_perfil(:p_id_perfil, :p_id_pasajero, :p_tipo_perfil, :p_numero_programa, :p_aerolinea_asociada, :p_puntos_acumulados, :p_categoria, :p_fecha_ingreso, :p_fecha_ultima_actividad); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_perfil", id),
                new OracleParameter("p_id_pasajero", m.IdPasajero),
                new OracleParameter("p_tipo_perfil", (object?)m.TipoPerfil ?? DBNull.Value),
                new OracleParameter("p_numero_programa", (object?)m.NumeroPrograma ?? DBNull.Value),
                new OracleParameter("p_aerolinea_asociada", (object?)m.AerolineaAsociada ?? DBNull.Value),
                new OracleParameter("p_puntos_acumulados", m.PuntosAcumulados),
                new OracleParameter("p_categoria", (object?)m.Categoria ?? DBNull.Value),
                new OracleParameter("p_fecha_ingreso", (object?)m.FechaIngreso ?? DBNull.Value),
                new OracleParameter("p_fecha_ultima_actividad", (object?)m.FechaUltimaActividad ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PerfilViajeroModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_perfiles_viajero.delete_perfil(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PerfilViajeroModel: {ex.Message}"); return false; }
        }
    }
}
