using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class TripulacionService : ITripulacionService
    {
        private readonly DBContext _context;

        public TripulacionService(DBContext context)
        {
            _context = context;
        }

        // 1. INSERTAR
        public async Task<bool> Insertar(TripulacionModel m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_tripulante", m.IdTripulante),
                new OracleParameter("p_nombres", m.Nombres),
                new OracleParameter("p_apellidos", m.Apellidos),
                new OracleParameter("p_tipo_documento", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_numero_documento", m.NumeroDocumento),
                new OracleParameter("p_fecha_nacimiento", (object?)m.FechaNacimiento ?? DBNull.Value),
                new OracleParameter("p_nacionalidad", (object?)m.Nacionalidad ?? DBNull.Value),
                new OracleParameter("p_tipo_tripulante", m.TipoTripulante),
                new OracleParameter("p_licencia", (object?)m.Licencia ?? DBNull.Value),
                new OracleParameter("p_fecha_licencia", (object?)m.FechaLicencia ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", (object?)m.FechaVencimientoLicencia ?? DBNull.Value),
                new OracleParameter("p_horas_vuelo", (object?)m.HorasVueloAcumuladas ?? 0),
                new OracleParameter("p_activo", m.Activo)
            };

            string sql = "BEGIN pkg_tripulacion.insert_tripulante(:p_id_tripulante, :p_nombres, :p_apellidos, :p_tipo_documento, :p_numero_documento, :p_fecha_nacimiento, :p_nacionalidad, :p_tipo_tripulante, :p_licencia, :p_fecha_licencia, :p_fecha_vencimiento, :p_horas_vuelo, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        // 2. ACTUALIZAR
        public async Task<bool> Actualizar(int id, string tipoTripulante, string licencia, DateTime vencimientoLicencia, decimal horasVuelo, int activo)
        {
            // Recuperamos el tripulante actual para no perder datos personales (Nombres, Documentos, etc.)
            // ya que el SP update_tripulante pide la firma completa.
            var actual = await ObtenerPorId(id);
            if (actual == null) return false;

            var sql = "BEGIN pkg_tripulacion.update_tripulante(:p_id_tripulante, :p_nombres, :p_apellidos, :p_tipo_documento, :p_numero_documento, :p_fecha_nacimiento, :p_nacionalidad, :p_tipo_tripulante, :p_licencia, :p_fecha_licencia, :p_fecha_vencimiento, :p_horas_vuelo, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_id_tripulante", id),
                new OracleParameter("p_nombres", actual.Nombres),
                new OracleParameter("p_apellidos", actual.Apellidos),
                new OracleParameter("p_tipo_documento", (object?)actual.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_numero_documento", actual.NumeroDocumento),
                new OracleParameter("p_fecha_nacimiento", (object?)actual.FechaNacimiento ?? DBNull.Value),
                new OracleParameter("p_nacionalidad", (object?)actual.Nacionalidad ?? DBNull.Value),
                new OracleParameter("p_tipo_tripulante", tipoTripulante),
                new OracleParameter("p_licencia", (object?)licencia ?? DBNull.Value),
                new OracleParameter("p_fecha_licencia", (object?)actual.FechaLicencia ?? DBNull.Value),
                new OracleParameter("p_fecha_vencimiento", vencimientoLicencia),
                new OracleParameter("p_horas_vuelo", horasVuelo),
                new OracleParameter("p_activo", activo));

            return true;
        }

        // 3. ELIMINAR
        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_tripulacion.delete_tripulante(:p_id_tripulante); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_tripulante", id));
            return true;
        }

        // 4. LISTAR
        public async Task<List<TripulacionModel>> ListarTodo()
        {
            return await _context.Tripulacion.ToListAsync();
        }

        // 5. OBTENER POR ID
        public async Task<TripulacionModel?> ObtenerPorId(int id)
        {
            return await _context.Tripulacion.FirstOrDefaultAsync(x => x.IdTripulante == id);
        }

        // 6. OBTENER POR DOCUMENTO
        public async Task<TripulacionModel?> ObtenerPorDocumento(string numeroDocumento)
        {
            return await _context.Tripulacion.FirstOrDefaultAsync(x => x.NumeroDocumento == numeroDocumento);
        }
    }
}

