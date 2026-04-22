using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class SalonesVipService : ISalonesVipService
    {
        private readonly DBContext _context;
        public SalonesVipService(DBContext context) => _context = context;

        public async Task<List<SalonesVipModel>> ListarTodo()
        {
            try { return await _context.SalonesVip.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo SalonesVipModel: {ex.Message}"); return new List<SalonesVipModel>(); }
        }

        public async Task<SalonesVipModel?> ObtenerPorId(int id)
        {
            try { return await _context.SalonesVip.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId SalonesVipModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(SalonesVipModel m)
        {
            try
            {
                string sql = "BEGIN pkg_salones_vip.insert_salon(:p_codigo_aeropuerto, :p_nombre_salon, :p_ubicacion, :p_capacidad, :p_horario_apertura, :p_horario_cierre, :p_servicios, :p_requisitos_acceso, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_nombre_salon", (object?)m.NombreSalon ?? DBNull.Value),
                new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                new OracleParameter("p_capacidad", (object?)m.Capacidad ?? DBNull.Value),
                new OracleParameter("p_horario_apertura", (object?)m.HorarioApertura ?? DBNull.Value),
                new OracleParameter("p_horario_cierre", (object?)m.HorarioCierre ?? DBNull.Value),
                new OracleParameter("p_servicios", (object?)m.Servicios ?? DBNull.Value),
                new OracleParameter("p_requisitos_acceso", (object?)m.RequisitosAcceso ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar SalonesVipModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(int id, SalonesVipModel m)
        {
            try
            {
                string sql = "BEGIN pkg_salones_vip.update_salon(:p_id_salon, :p_codigo_aeropuerto, :p_nombre_salon, :p_ubicacion, :p_capacidad, :p_horario_apertura, :p_horario_cierre, :p_servicios, :p_requisitos_acceso, :p_activo); END;";
                var p = new OracleParameter[] {
                new OracleParameter("p_id_salon", id),
                new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_nombre_salon", (object?)m.NombreSalon ?? DBNull.Value),
                new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                new OracleParameter("p_capacidad", (object?)m.Capacidad ?? DBNull.Value),
                new OracleParameter("p_horario_apertura", (object?)m.HorarioApertura ?? DBNull.Value),
                new OracleParameter("p_horario_cierre", (object?)m.HorarioCierre ?? DBNull.Value),
                new OracleParameter("p_servicios", (object?)m.Servicios ?? DBNull.Value),
                new OracleParameter("p_requisitos_acceso", (object?)m.RequisitosAcceso ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
                };
                await _context.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar SalonesVipModel: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_salones_vip.delete_salon(:); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar SalonesVipModel: {ex.Message}"); return false; }
        }
    }
}
