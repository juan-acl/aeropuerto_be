using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ProgramaLealtadService : IProgramaLealtadService
    {
        private readonly DBContext _context;

        public ProgramaLealtadService(DBContext context) => _context = context;

        public async Task<int> RegistrarMembresia(ProgramaLealtadModel m)
        {
            // Generamos un número de tarjeta aleatorio si no se proporciona uno
            string numeroTarjeta = m.TarjetaNumero ?? $"VIP-{DateTime.Now.Ticks.ToString().Substring(8, 8)}";

            var sql = @"INSERT INTO programa_lealtad 
                        (id_pasajero, nivel_membresia, fecha_ingreso, fecha_ultima_actividad, 
                         beneficios_activos, tarjeta_numero, activo) 
                        VALUES (:p_pas, :p_nivel, SYSDATE, SYSDATE, 
                                :p_ben, :p_tarj, 1)
                        RETURNING id_lealtad INTO :p_id_out";

            var idOutParam = new OracleParameter("p_id_out", OracleDbType.Int32, ParameterDirection.Output);

            var parametros = new[] {
                new OracleParameter("p_pas", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_nivel", string.IsNullOrEmpty(m.NivelMembresia) ? "BRONCE" : m.NivelMembresia.ToUpper()),
                new OracleParameter("p_ben", (object?)m.BeneficiosActivos ?? DBNull.Value),
                new OracleParameter("p_tarj", numeroTarjeta),
                idOutParam
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return Convert.ToInt32(idOutParam.Value.ToString());
        }

        public async Task<ProgramaLealtadModel?> ObtenerPorPasajero(int idPasajero)
        {
            return await _context.ProgramaLealtad
                .FirstOrDefaultAsync(p => p.IdPasajero == idPasajero && p.Activo == 1);
        }

        public async Task<bool> SumarActividad(int idPasajero, int puntos, int millas)
        {
            // Suma puntos al histórico (para subir de nivel) y al saldo canjeable actual
            var sql = @"UPDATE programa_lealtad 
                        SET puntos_acumulados = puntos_acumulados + :p_puntos,
                            puntos_canjeables = puntos_canjeables + :p_puntos,
                            millas_acumuladas = millas_acumuladas + :p_millas,
                            fecha_ultima_actividad = SYSDATE
                        WHERE id_pasajero = :p_pas";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_puntos", puntos),
                new OracleParameter("p_millas", millas),
                new OracleParameter("p_pas", idPasajero));

            return true;
        }

        public async Task<bool> CanjearPuntos(int idPasajero, int puntosACanjear)
        {
            var membresia = await ObtenerPorPasajero(idPasajero);

            if (membresia == null || membresia.PuntosCanjeables < puntosACanjear)
                throw new Exception("Saldo de puntos insuficiente para realizar el canje.");

            // Descuenta solo del saldo canjeable. Los puntos acumulados (históricos) no se tocan.
            var sql = @"UPDATE programa_lealtad 
                        SET puntos_canjeables = puntos_canjeables - :p_puntos,
                            fecha_ultima_actividad = SYSDATE
                        WHERE id_pasajero = :p_pas";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_puntos", puntosACanjear),
                new OracleParameter("p_pas", idPasajero));

            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM programa_lealtad WHERE id_lealtad = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}