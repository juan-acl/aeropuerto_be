using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EstacionamientoService : IEstacionamientoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public EstacionamientoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<EstacionamientoModel>> ListarTodo()
        {
            try { return await _replica.Estacionamiento.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EstacionamientoModel: {ex.Message}"); return new List<EstacionamientoModel>(); }
        }

        public async Task<EstacionamientoModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.Estacionamiento.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EstacionamientoModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EstacionamientoModel m)
        {
            try
            {
                string sql = "BEGIN pkg_estacionamiento.insert_estacionamiento(:p_codigo_aeropuerto, :p_numero_espacio, :p_tipo_espacio, :p_terminal_cercana, :p_tarifa_por_hora, :p_tarifa_diaria, :p_disponible, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_numero_espacio", (object?)m.NumeroEspacio ?? DBNull.Value),
                    new OracleParameter("p_tipo_espacio", (object?)m.TipoEspacio ?? DBNull.Value),
                    new OracleParameter("p_terminal_cercana", (object?)m.TerminalCercana ?? DBNull.Value),
                    new OracleParameter("p_tarifa_por_hora", (object?)m.TarifaPorHora ?? DBNull.Value),
                    new OracleParameter("p_tarifa_diaria", (object?)m.TarifaDiaria ?? DBNull.Value),
                    new OracleParameter("p_disponible", m.Disponible),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar EstacionamientoModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, EstacionamientoModel m)
        {
            try
            {
                string sql = "BEGIN pkg_estacionamiento.update_estacionamiento(:p_id_estacionamiento, :p_codigo_aeropuerto, :p_numero_espacio, :p_tipo_espacio, :p_terminal_cercana, :p_tarifa_por_hora, :p_tarifa_diaria, :p_disponible, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_estacionamiento", id),
                    new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_numero_espacio", (object?)m.NumeroEspacio ?? DBNull.Value),
                    new OracleParameter("p_tipo_espacio", (object?)m.TipoEspacio ?? DBNull.Value),
                    new OracleParameter("p_terminal_cercana", (object?)m.TerminalCercana ?? DBNull.Value),
                    new OracleParameter("p_tarifa_por_hora", (object?)m.TarifaPorHora ?? DBNull.Value),
                    new OracleParameter("p_tarifa_diaria", (object?)m.TarifaDiaria ?? DBNull.Value),
                    new OracleParameter("p_disponible", m.Disponible),
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar EstacionamientoModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_estacionamiento.delete_estacionamiento(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar EstacionamientoModel: {ex.Message}"); throw; }
        }
    }
}
