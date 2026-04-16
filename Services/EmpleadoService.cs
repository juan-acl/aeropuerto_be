using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly DBContext _context;
        public EmpleadoService(DBContext context) => _context = context;

        public async Task<List<Empleado>> ListarTodo() => await _context.EMPLEADOS.ToListAsync();

        public async Task<bool> Insertar(Empleado m)
        {
            try
            {
                string sql = "BEGIN pkg_empleados.insert_empleado(:cod, :nom, :ape, :tdoc, :ndoc, :fnac, :nac, :gen, :dir, :tel, :mail, :fcon, :dep, :car, :sal, :tcon, :act, :foto); END;";
                
                var p = new OracleParameter[] {
                    new OracleParameter("cod", m.CodigoEmpleado),
                    new OracleParameter("nom", m.Nombres),
                    new OracleParameter("ape", m.Apellidos),
                    new OracleParameter("tdoc", m.TipoDocumento),
                    new OracleParameter("ndoc", m.NumeroDocumento),
                    new OracleParameter("fnac", m.FechaNacimiento),
                    new OracleParameter("nac", m.Nacionalidad),
                    new OracleParameter("gen", m.Genero),
                    new OracleParameter("dir", m.Direccion),
                    new OracleParameter("tel", m.Telefono),
                    new OracleParameter("mail", m.Email),
                    new OracleParameter("fcon", m.FechaContratacion),
                    new OracleParameter("dep", m.Departamento),
                    new OracleParameter("car", m.Cargo),
                    new OracleParameter("sal", m.SalarioBase),
                    new OracleParameter("tcon", m.TipoContrato),
                    new OracleParameter("act", m.Activo),
                    new OracleParameter("foto", OracleDbType.Blob) { Value = (object?)m.FotoEmpleado ?? DBNull.Value }
                };

                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR EMPLEADO: {ex.Message}");
                return false;
            }
        }
    }
}