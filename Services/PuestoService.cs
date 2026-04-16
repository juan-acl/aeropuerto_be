using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PuestoService : IPuestoService
    {
        private readonly DBContext _context;
        public PuestoService(DBContext context) => _context = context;

        public async Task<List<PuestoTrabajo>> ListarTodo() => await _context.PUESTOS_TRABAJO.ToListAsync();

        public async Task<bool> Insertar(PuestoTrabajo m)
        {
            try
            {
                // Llamada al SP del paquete que terminaste
                string sql = "BEGIN PKG_PUESTOS_TRABAJO.insert_puesto(:nom, :dep, :niv, :smin, :smax, :desc, :req, :act); END;";
                
                var p = new OracleParameter[] {
                    new OracleParameter("nom", m.NombrePuesto),
                    new OracleParameter("dep", m.IdDepartamento),
                    new OracleParameter("niv", m.NivelJerarquico),
                    new OracleParameter("smin", m.SalarioMinimo),
                    new OracleParameter("smax", m.SalarioMaximo),
                    new OracleParameter("desc", m.DescripcionFunciones),
                    new OracleParameter("req", m.Requisitos),
                    new OracleParameter("act", m.Activo)
                };

                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR PUESTO: {ex.Message}");
                return false;
            }
        }
    }
}