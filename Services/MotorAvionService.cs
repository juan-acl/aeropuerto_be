using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class MotorAvionService : IMotorAvionService
    {
        private readonly DBContext _context;

        public MotorAvionService(DBContext context)
        {
            _context = context;
        }

        // 1. INSERTAR
        public async Task<bool> Insertar(MotorAvionModel m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_motor", m.IdMotor),
                new OracleParameter("p_nombre_motor", m.NombreMotor),
                new OracleParameter("p_fabricante_motor", (object?)m.FabricanteMotor ?? DBNull.Value),
                new OracleParameter("p_tipo_motor", m.TipoMotor), // 'TURBOFAN', 'JET', etc.
                new OracleParameter("p_empuje_libras", (object?)m.EmpujeLibras ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
            };

            string sql = "BEGIN pkg_motores_aviones.insert_motor(:p_id_motor, :p_nombre_motor, :p_fabricante_motor, :p_tipo_motor, :p_empuje_libras, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        // 2. ACTUALIZAR
        public async Task<bool> Actualizar(int id, string nombre, string tipo, decimal empuje, int activo)
        {
            // Recuperamos el registro para mantener el fabricante original
            var actual = await ObtenerPorId(id);
            if (actual == null) return false;

            var sql = "BEGIN pkg_motores_aviones.update_motor(:p_id_motor, :p_nombre_motor, :p_fabricante_motor, :p_tipo_motor, :p_empuje_libras, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_id_motor", id),
                new OracleParameter("p_nombre_motor", nombre),
                new OracleParameter("p_fabricante_motor", (object?)actual.FabricanteMotor ?? DBNull.Value),
                new OracleParameter("p_tipo_motor", tipo),
                new OracleParameter("p_empuje_libras", empuje),
                new OracleParameter("p_activo", activo));

            return true;
        }

        // 3. ELIMINAR
        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_motores_aviones.delete_motor(:p_id_motor); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_motor", id));
            return true;
        }

        // 4. LISTAR
        public async Task<List<MotorAvionModel>> ListarTodo()
        {
            return await _context.MotoresAviones.ToListAsync();
        }

        // 5. OBTENER POR ID
        public async Task<MotorAvionModel?> ObtenerPorId(int id)
        {
            return await _context.MotoresAviones.FirstOrDefaultAsync(x => x.IdMotor == id);
        }
    }
} 

