using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class QuejasSugerenciasService : IQuejasSugerenciasService
    {
        private readonly DBContext _context;

        public QuejasSugerenciasService(DBContext context) => _context = context;

        public async Task<int> RegistrarContacto(QuejasSugerenciasModel m)
        {
            var sql = @"INSERT INTO quejas_sugerencias 
                        (id_pasajero, id_vuelo, tipo_contacto, fecha_contacto, medio_recepcion, 
                         descripcion, area_relacionada, estado) 
                        VALUES (:p_pas, :p_vuelo, :p_tipo, SYSTIMESTAMP, :p_medio, 
                                :p_desc, :p_area, 'RECIBIDO')
                        RETURNING id_queja INTO :p_id_out";

            var idOutParam = new OracleParameter("p_id_out", OracleDbType.Int32, ParameterDirection.Output);

            var parametros = new[] {
                new OracleParameter("p_pas", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_vuelo", (object?)m.IdVuelo ?? DBNull.Value),
                new OracleParameter("p_tipo", m.TipoContacto),
                new OracleParameter("p_medio", m.MedioRecepcion),
                new OracleParameter("p_desc", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_area", (object?)m.AreaRelacionada ?? DBNull.Value),
                idOutParam
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return Convert.ToInt32(idOutParam.Value.ToString());
        }

        public async Task<bool> ResponderContacto(int idQueja, string respuestaTexto)
        {
            var sql = @"UPDATE quejas_sugerencias 
                        SET estado = 'RESPONDIDO', 
                            fecha_respuesta = SYSTIMESTAMP, 
                            respuesta = :p_res 
                        WHERE id_queja = :p_id";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_res", respuestaTexto),
                new OracleParameter("p_id", idQueja));

            return true;
        }

        public async Task<bool> CalificarRespuesta(int idQueja, int nivelSatisfaccion)
        {
            var sql = @"UPDATE quejas_sugerencias 
                        SET satisfaccion_respuesta = :p_sat,
                            estado = 'CERRADO'
                        WHERE id_queja = :p_id";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_sat", nivelSatisfaccion),
                new OracleParameter("p_id", idQueja));

            return true;
        }

        public async Task<List<QuejasSugerenciasModel>> ListarPorEstado(string estado)
        {
            return await _context.QuejasSugerencias
                .Where(q => q.Estado == estado.ToUpper())
                .OrderBy(q => q.FechaContacto) // Atendemos primero las más antiguas (FIFO)
                .ToListAsync();
        }

        public async Task<List<QuejasSugerenciasModel>> ListarPorPasajero(int idPasajero)
        {
            return await _context.QuejasSugerencias
                .Where(q => q.IdPasajero == idPasajero)
                .OrderByDescending(q => q.FechaContacto)
                .ToListAsync();
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM quejas_sugerencias WHERE id_queja = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}