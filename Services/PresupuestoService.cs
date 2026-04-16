using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class PresupuestoService : IPresupuestoService
    {
        private readonly DBContext _context;
        public PresupuestoService(DBContext context) => _context = context;

        public async Task<List<Presupuesto>> ListarTodo() => 
            await _context.PRESUPUESTOS.ToListAsync();

        public async Task<bool> Insertar(Presupuesto m)
        {
            try
            {
                // Usando los parámetros típicos de un SP de presupuesto
                string sql = "BEGIN pkg_presupuestos.insert_presupuesto(:p_id_dep, :p_monto, :p_ejec, :p_anio, :p_fecha, :p_est, :p_notas); END;";
                
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_dep", m.IdDepartamento),
                    new OracleParameter("p_monto", m.MontoAsignado),
                    new OracleParameter("p_ejec", m.MontoEjecutado),
                    new OracleParameter("p_anio", m.AnioPresupuestario),
                    new OracleParameter("p_fecha", m.FechaAprobacion),
                    new OracleParameter("p_est", m.Estado),
                    new OracleParameter("p_notas", m.Notas ?? (object)DBNull.Value)
                };

                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR PRESUPUESTO: {ex.Message}");
                return false;
            }
        }
    }
}