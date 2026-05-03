using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class OrdenMantenimientoPredictivoService : IOrdenMantenimientoPredictivoService
    {
        private readonly DBContext _context;
        public OrdenMantenimientoPredictivoService(DBContext context) => _context = context;

        public async Task<List<OrdenMantenimientoPredictivo>> ListarTodo() => await _context.ORDENES_MANTENIMIENTO_PREDICTIVO.ToListAsync();
        public async Task<OrdenMantenimientoPredictivo?> ObtenerPorId(int id) => await _context.ORDENES_MANTENIMIENTO_PREDICTIVO.FindAsync(id);

        public async Task<bool> Insertar(OrdenMantenimientoPredictivo m)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_mantenimiento_predictivo.insert_orden_mp(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12, :p13, :p14, :p15, :p16, :p17); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR INSERT ORDEN_MANTENIMIENTO_PREDICTIVO: {ex.Message}"); return false; }
        }

        public async Task<bool> Actualizar(OrdenMantenimientoPredictivo m)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_mantenimiento_predictivo.update_orden_mp(:p1, :p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10, :p11, :p12, :p13, :p14, :p15, :p16, :p17); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, CrearParametros(m));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR UPDATE ORDEN_MANTENIMIENTO_PREDICTIVO: {ex.Message}"); return false; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_ordenes_mantenimiento_predictivo.delete_orden_mp(:p1); END;";
                await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p1", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR DELETE ORDEN_MANTENIMIENTO_PREDICTIVO: {ex.Message}"); return false; }
        }

        private OracleParameter[] CrearParametros(OrdenMantenimientoPredictivo m) => new OracleParameter[]
        {
            new OracleParameter("p1", m.id_orden_mp),
            new OracleParameter("p2", (object?)m.id_alerta_tecnica ?? DBNull.Value),
            new OracleParameter("p3", (object?)m.id_pieza ?? DBNull.Value),
            new OracleParameter("p4", (object?)m.id_avion_matricula ?? DBNull.Value),
            new OracleParameter("p5", (object?)m.fecha_creacion ?? DBNull.Value),
            new OracleParameter("p6", (object?)m.prioridad ?? DBNull.Value),
            new OracleParameter("p7", (object?)m.descripcion_trabajo ?? DBNull.Value),
            new OracleParameter("p8", (object?)m.tecnico_asignado ?? DBNull.Value),
            new OracleParameter("p9", (object?)m.fecha_inicio_estimada ?? DBNull.Value),
            new OracleParameter("p10", (object?)m.fecha_fin_estimada ?? DBNull.Value),
            new OracleParameter("p11", (object?)m.fecha_inicio_real ?? DBNull.Value),
            new OracleParameter("p12", (object?)m.fecha_fin_real ?? DBNull.Value),
            new OracleParameter("p13", (object?)m.estado ?? DBNull.Value),
            new OracleParameter("p14", (object?)m.horas_trabajadas ?? DBNull.Value),
            new OracleParameter("p15", (object?)m.costo_estimado ?? DBNull.Value),
            new OracleParameter("p16", (object?)m.costo_real ?? DBNull.Value),
            new OracleParameter("p17", (object?)m.observaciones ?? DBNull.Value)
        };
    }
}