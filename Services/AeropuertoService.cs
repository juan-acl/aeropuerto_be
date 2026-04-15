using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AeropuertoService : IAeropuertoService
    {
        private readonly DBContext _context;

        public AeropuertoService(DBContext context)
        {
            _context = context;
        }

        // 1. INSERTAR
        public async Task<bool> Insertar(AeropuertoModel m)
        {
            var parametros = new[] {
                new OracleParameter("p_codigo_aeropuerto", m.CodigoAeropuerto),
                new OracleParameter("p_nombre", m.Nombre),
                new OracleParameter("p_ciudad", m.Ciudad),
                new OracleParameter("p_pais", m.Pais),
                new OracleParameter("p_region", (object?)m.Region ?? DBNull.Value),
                new OracleParameter("p_continente", (object?)m.Continente ?? DBNull.Value),
                new OracleParameter("p_huso_horario", (object?)m.HusoHorario ?? DBNull.Value),
                new OracleParameter("p_latitud", (object?)m.Latitud ?? DBNull.Value),
                new OracleParameter("p_longitud", (object?)m.Longitud ?? DBNull.Value),
                new OracleParameter("p_elevacion_metros", (object?)m.ElevacionMetros ?? DBNull.Value),
                new OracleParameter("p_terminales", (object?)m.Terminales ?? DBNull.Value),
                new OracleParameter("p_puertas_abordaje", (object?)m.PuertasAbordaje ?? DBNull.Value),
                new OracleParameter("p_usuario_registro", (object?)m.UsuarioRegistro ?? DBNull.Value)
            };

            // Se usa el nombre del paquete: pkg_aeropuertos
            string sql = "BEGIN pkg_aeropuertos.insert_aeropuerto(:p_codigo_aeropuerto, :p_nombre, :p_ciudad, :p_pais, :p_region, :p_continente, :p_huso_horario, :p_latitud, :p_longitud, :p_elevacion_metros, :p_terminales, :p_puertas_abordaje, :p_usuario_registro); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        // 2. ACTUALIZAR
        public async Task<bool> Actualizar(string codigo, int terminales, int puertas, int activo)
        {
            // Se usa el nombre del paquete: pkg_aeropuertos
            var sql = "BEGIN pkg_aeropuertos.update_aeropuerto(:p_codigo_aeropuerto, :p_terminales, :p_puertas_abordaje, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_codigo_aeropuerto", codigo),
                new OracleParameter("p_terminales", terminales),
                new OracleParameter("p_puertas_abordaje", puertas),
                new OracleParameter("p_activo", activo));
            return true;
        }

        // 3. ELIMINAR
        public async Task<bool> Eliminar(string codigo)
        {
            // Se usa el nombre del paquete: pkg_aeropuertos
            var sql = "BEGIN pkg_aeropuertos.delete_aeropuerto(:p_codigo_aeropuerto); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_codigo_aeropuerto", codigo));
            return true;
        }

        // 4. LISTAR
        public async Task<List<AeropuertoModel>> ListarTodo()
        {
            return await _context.Aeropuertos.ToListAsync();
        }
    }
}
