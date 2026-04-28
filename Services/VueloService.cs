using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class VueloService : IVueloService
    {
        private readonly DBContext _context;

        public VueloService(DBContext context)
        {
            _context = context;
        }

        public async Task<List<VueloModel>> ListarTodo()
        {
            return await _context.Vuelos.OrderBy(v => v.FechaVuelo).ToListAsync();
        }

        public async Task<VueloModel?> ObtenerPorId(int id)
        {
            return await _context.Vuelos.FirstOrDefaultAsync(v => v.IdVuelo == id);
        }

        public async Task<List<VueloModel>> BuscarPorRuta(string origen, string destino, DateTime? fecha)
        {
            var query = _context.Vuelos
                .Join(_context.ProgramasVuelo,
                    v => v.IdPrograma,
                    p => p.IdPrograma,
                    (v, p) => new { Vuelo = v, Programa = p })
                .Where(x =>
                    (string.IsNullOrEmpty(origen)  || x.Programa.AeropuertoOrigen  == origen) &&
                    (string.IsNullOrEmpty(destino) || x.Programa.AeropuertoDestino == destino) &&
                    (fecha == null || x.Vuelo.FechaVuelo == fecha!.Value.Date) &&
                    x.Vuelo.EstadoVuelo != "CANCELADO"
                )
                .Select(x => x.Vuelo);

            return await query.OrderBy(v => v.HoraSalidaProgramada).ToListAsync();
        }

        public async Task<List<VueloModel>> ListarPorEstado(string estado)
        {
            return await _context.Vuelos
                .Where(v => v.EstadoVuelo == estado)
                .OrderBy(v => v.HoraSalidaProgramada)
                .ToListAsync();
        }

        public async Task<bool> Insertar(VueloModel m)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"BEGIN pkg_vuelos.insert_vuelo(
                    :p_id_programa, :p_fecha_vuelo, :p_hora_salida_programada,
                    :p_hora_llegada_programada, :p_id_modelo_avion, :p_matricula_avion,
                    :p_plazas_vacias, :p_plazas_ocupadas, :p_estado_vuelo,
                    :p_id_puerta_salida, :p_id_puerta_llegada, :p_observaciones
                ); END;",
                new OracleParameter("p_id_programa",             m.IdPrograma),
                new OracleParameter("p_fecha_vuelo",             (object?)m.FechaVuelo ?? DBNull.Value),
                new OracleParameter("p_hora_salida_programada",  (object?)m.HoraSalidaProgramada ?? DBNull.Value),
                new OracleParameter("p_hora_llegada_programada", (object?)m.HoraLlegadaProgramada ?? DBNull.Value),
                new OracleParameter("p_id_modelo_avion",         m.IdModeloAvion),
                new OracleParameter("p_matricula_avion",         (object?)m.MatriculaAvion ?? DBNull.Value),
                new OracleParameter("p_plazas_vacias",           m.PlazasVacias),
                new OracleParameter("p_plazas_ocupadas",         m.PlazasOcupadas),
                new OracleParameter("p_estado_vuelo",            m.EstadoVuelo),
                new OracleParameter("p_id_puerta_salida",        (object?)m.IdPuertaSalida ?? DBNull.Value),
                new OracleParameter("p_id_puerta_llegada",       (object?)m.IdPuertaLlegada ?? DBNull.Value),
                new OracleParameter("p_observaciones",           (object?)m.ObservacionesOperativas ?? DBNull.Value)
            );
            return true;
        }

        public async Task<bool> ActualizarEstado(int id, string estado, string? motivo)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN pkg_vuelos.update_estado_vuelo(:p_id_vuelo, :p_estado_vuelo, :p_motivo); END;",
                new OracleParameter("p_id_vuelo",       id),
                new OracleParameter("p_estado_vuelo",   estado),
                new OracleParameter("p_motivo",         (object?)motivo ?? DBNull.Value)
            );
            return true;
        }

        public async Task<bool> ActualizarHoraReal(int id, DateTime? horaSalidaReal, DateTime? horaLlegadaReal)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN pkg_vuelos.update_horas_reales(:p_id_vuelo, :p_hora_salida_real, :p_hora_llegada_real); END;",
                new OracleParameter("p_id_vuelo",         id),
                new OracleParameter("p_hora_salida_real",  (object?)horaSalidaReal  ?? DBNull.Value),
                new OracleParameter("p_hora_llegada_real", (object?)horaLlegadaReal ?? DBNull.Value)
            );
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN pkg_vuelos.delete_vuelo(:p_id_vuelo); END;",
                new OracleParameter("p_id_vuelo", id)
            );
            return true;
        }

        public async Task<bool> AsignarPuerta(AsignarPuertaRequest m)
        {
            var sql = "sp_asignar_puerta_embarque";

            var parametros = new[] {
        new OracleParameter("p_id_vuelo", OracleDbType.Int32) { Value = m.IdVuelo },
        new OracleParameter("p_id_puerta", OracleDbType.Int32) { Value = m.IdPuerta },
        new OracleParameter("p_tipo_vuelo", OracleDbType.Varchar2) { Value = m.TipoVuelo }
    };

            await _context.Database.ExecuteSqlRawAsync(
                $"BEGIN {sql}(:p_id_vuelo, :p_id_puerta, :p_tipo_vuelo); END;",
                parametros
            );

            return true;
        }

        public async Task<bool> CancelarVuelo(CancelarVueloRequest m)
        {
            var sql = "sp_cancelar_vuelo";

            var parametros = new[] {
        new OracleParameter("p_id_vuelo", OracleDbType.Int32) { Value = m.IdVuelo },
        new OracleParameter("p_motivo_cancelacion", OracleDbType.Varchar2) { Value = m.MotivoCancelacion }
    };

            // Ejecutamos el bloque anónimo de PL/SQL
            await _context.Database.ExecuteSqlRawAsync(
                $"BEGIN {sql}(:p_id_vuelo, :p_motivo_cancelacion); END;",
                parametros
            );

            return true;
        }

        public async Task<bool> CerrarEmbarque(int idVuelo)
        {
            var sql = "sp_cierre_embarque";

            var parametros = new[] {
        new OracleParameter("p_id_vuelo", OracleDbType.Int32) { Value = idVuelo }
    };

            // Ejecución del procedimiento que actualiza vuelo y pasajeros (NO_SHOW)
            await _context.Database.ExecuteSqlRawAsync(
                $"BEGIN {sql}(:p_id_vuelo); END;",
                parametros
            );

            return true;
        }
    }
}
