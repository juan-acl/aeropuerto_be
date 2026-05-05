using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ProgramaLealtadService : IProgramaLealtadService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ProgramaLealtadService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ProgramaLealtadModel>> ListarTodo()
        {
            try { return await _replica.ProgramaLealtad.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ProgramaLealtadModel: {ex.Message}"); return new List<ProgramaLealtadModel>(); }
        }

        public async Task<ProgramaLealtadModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.ProgramaLealtad.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ProgramaLealtadModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ProgramaLealtadModel m)
        {
            try
            {
                string sql = "BEGIN pkg_programa_lealtad.insert_lealtad(:p_id_pasajero, :p_nivel_membresia, :p_puntos_acumulados, :p_puntos_canjeables, :p_fecha_ingreso, :p_fecha_ultima_actividad, :p_millas_acumuladas, :p_beneficios_activos, :p_tarjeta_numero, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_nivel_membresia", (object?)m.NivelMembresia ?? DBNull.Value),
                    new OracleParameter("p_puntos_acumulados", m.PuntosAcumulados),
                    new OracleParameter("p_puntos_canjeables", m.PuntosCanjeables),
                    new OracleParameter("p_fecha_ingreso", (object?)m.FechaIngreso ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultima_actividad", (object?)m.FechaUltimaActividad ?? DBNull.Value),
                    new OracleParameter("p_millas_acumuladas", m.MillasAcumuladas),
                    new OracleParameter("p_beneficios_activos", (object?)m.BeneficiosActivos ?? DBNull.Value),
                    new OracleParameter("p_tarjeta_numero", (object?)m.TarjetaNumero ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ProgramaLealtadModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ProgramaLealtadModel m)
        {
            try
            {
                string sql = "BEGIN pkg_programa_lealtad.update_lealtad(:p_id_lealtad, :p_id_pasajero, :p_nivel_membresia, :p_puntos_acumulados, :p_puntos_canjeables, :p_fecha_ingreso, :p_fecha_ultima_actividad, :p_millas_acumuladas, :p_beneficios_activos, :p_tarjeta_numero, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_lealtad", id),
                    new OracleParameter("p_id_pasajero", (object?)m.IdPasajero ?? DBNull.Value),
                    new OracleParameter("p_nivel_membresia", (object?)m.NivelMembresia ?? DBNull.Value),
                    new OracleParameter("p_puntos_acumulados", m.PuntosAcumulados),
                    new OracleParameter("p_puntos_canjeables", m.PuntosCanjeables),
                    new OracleParameter("p_fecha_ingreso", (object?)m.FechaIngreso ?? DBNull.Value),
                    new OracleParameter("p_fecha_ultima_actividad", (object?)m.FechaUltimaActividad ?? DBNull.Value),
                    new OracleParameter("p_millas_acumuladas", m.MillasAcumuladas),
                    new OracleParameter("p_beneficios_activos", (object?)m.BeneficiosActivos ?? DBNull.Value),
                    new OracleParameter("p_tarjeta_numero", (object?)m.TarjetaNumero ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ProgramaLealtadModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_programa_lealtad.delete_lealtad(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ProgramaLealtadModel: {ex.Message}"); throw; }
        }
    }
}
