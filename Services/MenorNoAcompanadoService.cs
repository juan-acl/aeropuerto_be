using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class MenorNoAcompanadoService : IMenorNoAcompanadoService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public MenorNoAcompanadoService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<MenorNoAcompanado>> ListarTodo()
        {
            try { return await _replica.MENORES_NO_ACOMPANADOS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo MenorNoAcompanado: {ex.Message}"); return new List<MenorNoAcompanado>(); }
        }

        public async Task<MenorNoAcompanado ?> ObtenerPorId(int id)
        {
            try { return await _replica.MENORES_NO_ACOMPANADOS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId MenorNoAcompanado: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(MenorNoAcompanado m)
        {
            try
            {
                string sql = "BEGIN pkg_menores_no_acompanados.insert_menor(:p_id_reserva, :p_edad, :p_nombre_entrega_origen, :p_relacion_origen, :p_telefono_origen, :p_nombre_recoge_destino, :p_relacion_destino, :p_telefono_destino, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_reserva", DBNull.Value),
                    new OracleParameter("p_edad", DBNull.Value),
                    new OracleParameter("p_nombre_entrega_origen", DBNull.Value),
                    new OracleParameter("p_relacion_origen", DBNull.Value),
                    new OracleParameter("p_telefono_origen", DBNull.Value),
                    new OracleParameter("p_nombre_recoge_destino", DBNull.Value),
                    new OracleParameter("p_relacion_destino", DBNull.Value),
                    new OracleParameter("p_telefono_destino", DBNull.Value),
                    new OracleParameter("p_observaciones", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar MenorNoAcompanado: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, MenorNoAcompanado m)
        {
            try
            {
                string sql = "BEGIN pkg_menores_no_acompanados.update_menor(:p_id_menor, :p_id_reserva, :p_edad, :p_nombre_entrega_origen, :p_relacion_origen, :p_telefono_origen, :p_nombre_recoge_destino, :p_relacion_destino, :p_telefono_destino, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_menor", id),
                    new OracleParameter("p_id_reserva", DBNull.Value),
                    new OracleParameter("p_edad", DBNull.Value),
                    new OracleParameter("p_nombre_entrega_origen", DBNull.Value),
                    new OracleParameter("p_relacion_origen", DBNull.Value),
                    new OracleParameter("p_telefono_origen", DBNull.Value),
                    new OracleParameter("p_nombre_recoge_destino", DBNull.Value),
                    new OracleParameter("p_relacion_destino", DBNull.Value),
                    new OracleParameter("p_telefono_destino", DBNull.Value),
                    new OracleParameter("p_observaciones", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar MenorNoAcompanado: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_menores_no_acompanados.delete_menor(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar MenorNoAcompanado: {ex.Message}"); throw; }
        }
    }
}
