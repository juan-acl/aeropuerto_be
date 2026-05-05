using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PasajeroMascotaService : IPasajeroMascotaService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PasajeroMascotaService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PasajeroMascota>> ListarTodo()
        {
            try { return await _replica.PASAJEROS_MASCOTAS.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PasajeroMascota: {ex.Message}"); return new List<PasajeroMascota>(); }
        }

        public async Task<PasajeroMascota ?> ObtenerPorId(int id)
        {
            try { return await _replica.PASAJEROS_MASCOTAS.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PasajeroMascota: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PasajeroMascota m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_mascotas.insert_mascota(:p_id_pasajero, :p_id_reserva, :p_nombre_mascota, :p_tipo_mascota, :p_raza, :p_peso_kg, :p_certificado_salud, :p_vacunas, :p_transportadora_dimensiones, :p_autorizado); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_pasajero", DBNull.Value),
                    new OracleParameter("p_id_reserva", DBNull.Value),
                    new OracleParameter("p_nombre_mascota", (object?)m.NombreMascota ?? DBNull.Value),
                    new OracleParameter("p_tipo_mascota", DBNull.Value),
                    new OracleParameter("p_raza", (object?)m.Raza ?? DBNull.Value),
                    new OracleParameter("p_peso_kg", DBNull.Value),
                    new OracleParameter("p_certificado_salud", (object?)m.CertificadoSalud ?? DBNull.Value),
                    new OracleParameter("p_vacunas", DBNull.Value),
                    new OracleParameter("p_transportadora_dimensiones", DBNull.Value),
                    new OracleParameter("p_autorizado", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PasajeroMascota: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, PasajeroMascota m)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_mascotas.update_mascota(:p_id_mascota, :p_id_pasajero, :p_id_reserva, :p_nombre_mascota, :p_tipo_mascota, :p_raza, :p_peso_kg, :p_certificado_salud, :p_vacunas, :p_transportadora_dimensiones, :p_autorizado); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_mascota", id),
                    new OracleParameter("p_id_pasajero", DBNull.Value),
                    new OracleParameter("p_id_reserva", DBNull.Value),
                    new OracleParameter("p_nombre_mascota", (object?)m.NombreMascota ?? DBNull.Value),
                    new OracleParameter("p_tipo_mascota", DBNull.Value),
                    new OracleParameter("p_raza", (object?)m.Raza ?? DBNull.Value),
                    new OracleParameter("p_peso_kg", DBNull.Value),
                    new OracleParameter("p_certificado_salud", (object?)m.CertificadoSalud ?? DBNull.Value),
                    new OracleParameter("p_vacunas", DBNull.Value),
                    new OracleParameter("p_transportadora_dimensiones", DBNull.Value),
                    new OracleParameter("p_autorizado", DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PasajeroMascota: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_pasajeros_mascotas.delete_mascota(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PasajeroMascota: {ex.Message}"); throw; }
        }
    }
}
