using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class SalonesVipService : ISalonesVipService
    {
        private readonly DBContext _context;

        public SalonesVipService(DBContext context) => _context = context;

        public async Task<bool> RegistrarSalon(SalonesVipModel m)
        {
            var sql = @"INSERT INTO salones_vip 
                        (codigo_aeropuerto, nombre_salon, ubicacion, capacidad, 
                         horario_apertura, horario_cierre, servicios, requisitos_acceso, activo) 
                        VALUES (:p_aero, :p_nom, :p_ubic, :p_cap, 
                                :p_aper, :p_cier, :p_serv, :p_req, 1)";

            var parametros = new[] {
                new OracleParameter("p_aero", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_nom", (object?)m.NombreSalon ?? DBNull.Value),
                new OracleParameter("p_ubic", (object?)m.Ubicacion ?? DBNull.Value),
                new OracleParameter("p_cap", (object?)m.Capacidad ?? DBNull.Value),
                new OracleParameter("p_aper", (object?)m.HorarioApertura ?? DBNull.Value),
                new OracleParameter("p_cier", (object?)m.HorarioCierre ?? DBNull.Value),
                new OracleParameter("p_serv", (object?)m.Servicios ?? DBNull.Value),
                new OracleParameter("p_req", (object?)m.RequisitosAcceso ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<SalonesVipModel>> ListarPorAeropuerto(string codigoAeropuerto)
        {
            return await _context.SalonesVip
                .Where(s => s.CodigoAeropuerto == codigoAeropuerto)
                .OrderBy(s => s.NombreSalon)
                .ToListAsync();
        }

        public async Task<List<SalonesVipModel>> ListarActivos(string codigoAeropuerto)
        {
            return await _context.SalonesVip
                .Where(s => s.CodigoAeropuerto == codigoAeropuerto && s.Activo == 1)
                .OrderBy(s => s.NombreSalon)
                .ToListAsync();
        }

        public async Task<bool> ActualizarCapacidad(int idSalon, int nuevaCapacidad)
        {
            var sql = @"UPDATE salones_vip 
                        SET capacidad = :p_cap 
                        WHERE id_salon = :p_id";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_cap", nuevaCapacidad),
                new OracleParameter("p_id", idSalon));
            return true;
        }

        public async Task<bool> DesactivarSalon(int id)
        {
            var sql = "UPDATE salones_vip SET activo = 0 WHERE id_salon = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM salones_vip WHERE id_salon = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}