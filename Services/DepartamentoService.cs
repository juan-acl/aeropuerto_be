using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly DBContext _context;

        public DepartamentoService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(Departamento modelo)
        {
            try
            {
                // 1. Definimos la llamada al procedimiento dentro del paquete
                // Nota: Asegúrate que el procedimiento se llame PRC_INSERTAR_DEPARTAMENTO
                string sql = "BEGIN PKG_DEPARTAMENTOS.PRC_INSERTAR_DEPARTAMENTO(:nom, :desc, :ubica, :presu, :gerente, :activo); END;";

                // 2. Mapeamos los parámetros con los tipos de datos de Oracle
                var parametros = new OracleParameter[]
                {
                    new OracleParameter("nom", OracleDbType.Varchar2) { Value = modelo.Nombre },
                    new OracleParameter("desc", OracleDbType.Varchar2) { Value = modelo.Descripcion },
                    new OracleParameter("ubica", OracleDbType.Varchar2) { Value = modelo.Ubicacion ?? (object)DBNull.Value },
                    new OracleParameter("presu", OracleDbType.Decimal) { Value = modelo.PresupuestoAnual ?? (object)DBNull.Value },
                    new OracleParameter("gerente", OracleDbType.Int32) { Value = modelo.GerenteId ?? (object)DBNull.Value },
                    new OracleParameter("activo", OracleDbType.Int32) { Value = modelo.Activo }
                };

                // 3. Ejecutamos el SP
                Console.WriteLine("--> Intentando llamar al SP: PKG_DEPARTAMENTOS.PRC_INSERTAR_DEPARTAMENTO");
                await _context.Database.ExecuteSqlRawAsync(sql, parametros);
                
                Console.WriteLine("--> ¡Éxito! Registro insertado correctamente.");
                return true;
            }
            catch (Exception ex)
            {
                // Esto imprimirá el error exacto de Oracle en tu terminal de VS Code
                Console.WriteLine($"--> ERROR EN EL SP: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Departamento>> ListarTodo()
        {
            try 
            {
                // Usamos EF Core para leer la tabla y mostrarla en el GET de Swagger
                return await _context.DEPARTAMENTOS.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> ERROR AL LISTAR: {ex.Message}");
                return new List<Departamento>();
            }
        }
    }
}