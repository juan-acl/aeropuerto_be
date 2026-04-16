using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class IncidentesInvolucradosService : IIncidentesInvolucradosService
    {
        private readonly DBContext _context;

        public IncidentesInvolucradosService(DBContext context) => _context = context;

        public async Task<bool> Insertar(IncidentesInvolucradosModel m)
        {
            var sql = @"INSERT INTO incidentes_involucrados 
                        (id_incidente, tipo_persona, id_pasajero, id_tripulante, nombre_completo, 
                         tipo_documento, numero_documento, nacionalidad, rol_en_incidente, declaracion) 
                        VALUES (:p_inc, :p_tipo, :p_pas, :p_trip, :p_nom, :p_tdoc, :p_ndoc, :p_nac, :p_rol, :p_decl)";

            var parametros = new[] {
                new OracleParameter("p_inc", m.IdIncidente),
                new OracleParameter("p_tipo", m.TipoPersona),
                new OracleParameter("p_pas", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_trip", (object?)m.IdTripulante ?? DBNull.Value),
                new OracleParameter("p_nom", (object?)m.NombreCompleto ?? DBNull.Value),
                new OracleParameter("p_tdoc", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_ndoc", (object?)m.NumeroDocumento ?? DBNull.Value),
                new OracleParameter("p_nac", (object?)m.Nacionalidad ?? DBNull.Value),
                new OracleParameter("p_rol", (object?)m.RolEnIncidente ?? DBNull.Value),
                new OracleParameter("p_decl", (object?)m.Declaracion ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<IncidentesInvolucradosModel>> ListarPorIncidente(int idIncidente)
        {
            return await _context.IncidentesInvolucrados
                .Where(i => i.IdIncidente == idIncidente)
                .ToListAsync();
        }

        public async Task<bool> ActualizarDeclaracion(int id, string nuevaDeclaracion)
        {
            var sql = "UPDATE incidentes_involucrados SET declaracion = :p_decl WHERE id_involucrado = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_decl", nuevaDeclaracion),
                new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM incidentes_involucrados WHERE id_involucrado = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}