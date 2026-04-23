using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PasajeroService : IPasajeroService
    {
        private readonly DBContext _context;

        public PasajeroService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(PasajeroModel m)
        {
            var parametros = new[] {
                new OracleParameter("p_nombres", m.Nombres),
                new OracleParameter("p_apellidos", m.Apellidos),
                new OracleParameter("p_tipo_doc", (object?)m.TipoDocumento ?? DBNull.Value),
                new OracleParameter("p_num_doc", m.NumeroDocumento),
                new OracleParameter("p_nacionalidad", (object?)m.Nacionalidad ?? DBNull.Value),
                new OracleParameter("p_fecha_nac", (object?)m.FechaNacimiento ?? DBNull.Value),
                new OracleParameter("p_genero", (object?)m.Genero ?? DBNull.Value),
                new OracleParameter("p_telefono", (object?)m.Telefono ?? DBNull.Value),
                new OracleParameter("p_email", (object?)m.Email ?? DBNull.Value),
                new OracleParameter("p_direccion", (object?)m.Direccion ?? DBNull.Value),
                new OracleParameter("p_ciudad", (object?)m.CiudadResidencia ?? DBNull.Value),
                new OracleParameter("p_pais", (object?)m.PaisResidencia ?? DBNull.Value),
                new OracleParameter("p_cp", (object?)m.CodigoPostal ?? DBNull.Value),
                new OracleParameter("p_ocupacion", (object?)m.Ocupacion ?? DBNull.Value),
                new OracleParameter("p_estado_civil", (object?)m.EstadoCivil ?? DBNull.Value),
                new OracleParameter("p_usuario", (object?)m.UsuarioRegistro ?? DBNull.Value)
            };

            string sql = "BEGIN pkg_pasajeros.insert_pasajero(:p_nombres, :p_apellidos, :p_tipo_doc, :p_num_doc, :p_nacionalidad, :p_fecha_nac, :p_genero, :p_telefono, :p_email, :p_direccion, :p_ciudad, :p_pais, :p_cp, :p_ocupacion, :p_estado_civil, :p_usuario); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> ActualizarContacto(int id, string telefono, string email, string direccion)
        {
            var sql = "BEGIN pkg_pasajeros.update_contacto(:p_id, :p_telefono, :p_email, :p_direccion); END;";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_id", id),
                new OracleParameter("p_telefono", telefono),
                new OracleParameter("p_email", email),
                new OracleParameter("p_direccion", direccion));
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_pasajeros.delete_pasajero(:p_id); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }

        public async Task<List<PasajeroModel>> ListarTodo()
        {
            return await _context.Pasajeros.ToListAsync();
        }
    }
}