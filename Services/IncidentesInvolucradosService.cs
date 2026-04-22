using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class IncidentesInvolucradosService : IIncidentesInvolucradosService
    {
        private readonly DBContext _context;
        public IncidentesInvolucradosService(DBContext context) => _context = context;

        public async Task<List<IncidentesInvolucradosModel>> ListarTodo()
        {
            try { return await _context.IncidentesInvolucrados.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo IncidentesInvolucradosModel: {ex.Message}"); return new List<IncidentesInvolucradosModel>(); }
        }

        public async Task<IncidentesInvolucradosModel?> ObtenerPorId(int id)
        {
            try { return await _context.IncidentesInvolucrados.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId IncidentesInvolucradosModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(IncidentesInvolucradosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes_involucrados.insert_involucrado(:p_id_incidente, :p_tipo_persona, :p_id_pasajero, :p_id_tripulante, :p_nombre_completo, :p_tipo_documento, :p_numero_documento, :p_nacionalidad, :p_rol_en_incidente, :p_declaracion); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_incidente", m.IdIncidente),
                new OracleParameter("p_tipo_persona", (object?)m.TipoPersona ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_id_tripulante", (object?)m.IdTripulante ?? DBNull.Value),
                new OracleParameter("p_nombre_completo", (object?)m.NombreCompleto ?? DBNull.Value),
                new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_numero_documento", (object?)m.NumeroDocumento ?? DBNull.Value),
                new OracleParameter("p_nacionalidad", (object?)m.Nacionalidad ?? DBNull.Value),
                new OracleParameter("p_rol_en_incidente", (object?)m.RolEnIncidente ?? DBNull.Value),
                new OracleParameter("p_declaracion", (object?)m.Declaracion ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar IncidentesInvolucradosModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, IncidentesInvolucradosModel m)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes_involucrados.update_involucrado(:p_id_involucrado, :p_id_incidente, :p_tipo_persona, :p_id_pasajero, :p_id_tripulante, :p_nombre_completo, :p_tipo_documento, :p_numero_documento, :p_nacionalidad, :p_rol_en_incidente, :p_declaracion); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_involucrado", id),
                new OracleParameter("p_id_incidente", m.IdIncidente),
                new OracleParameter("p_tipo_persona", (object?)m.TipoPersona ?? DBNull.Value),
                new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_id_tripulante", (object?)m.IdTripulante ?? DBNull.Value),
                new OracleParameter("p_nombre_completo", (object?)m.NombreCompleto ?? DBNull.Value),
                new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_numero_documento", (object?)m.NumeroDocumento ?? DBNull.Value),
                new OracleParameter("p_nacionalidad", (object?)m.Nacionalidad ?? DBNull.Value),
                new OracleParameter("p_rol_en_incidente", (object?)m.RolEnIncidente ?? DBNull.Value),
                new OracleParameter("p_declaracion", (object?)m.Declaracion ?? DBNull.Value)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar IncidentesInvolucradosModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_incidentes_involucrados.delete_involucrado(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar IncidentesInvolucradosModel: {ex.Message}"); return false; }
        }
    }
}
