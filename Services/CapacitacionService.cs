using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class CapacitacionService : ICapacitacionService
    {
        private readonly DBContext _context;
        public CapacitacionService(DBContext context) => _context = context;

        public async Task<List<Capacitacion>> ListarTodo() => 
            await _context.CAPACITACIONES.ToListAsync();

        public async Task<bool> Insertar(Capacitacion m)
        {
            try
            {
                string sql = "BEGIN pkg_capacitaciones.insert_capacitacion(:p_nom, :p_desc, :p_tipo, :p_dur, :p_costo, :p_prov, :p_ini, :p_fin, :p_act); END;";
                
                var p = new OracleParameter[] {
                    new OracleParameter("p_nom", m.NombreCurso),
                    new OracleParameter("p_desc", m.Descripcion),
                    new OracleParameter("p_tipo", m.TipoCapacitacion),
                    new OracleParameter("p_dur", m.DuracionHoras),
                    new OracleParameter("p_costo", m.Costo),
                    new OracleParameter("p_prov", m.Proveedor),
                    new OracleParameter("p_ini", m.FechaInicio),
                    new OracleParameter("p_fin", m.FechaFin),
                    new OracleParameter("p_act", m.Activo)
                };

                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR CAPACITACION: {ex.Message}");
                return false;
            }
        }
    }
}