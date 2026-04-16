using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ProhibicionesVueloService : IProhibicionesVueloService
    {
        private readonly DBContext _context;

        public ProhibicionesVueloService(DBContext context) => _context = context;

        public async Task<bool> Insertar(ProhibicionesVueloModel m)
        {
            var sql = @"INSERT INTO prohibiciones_vuelo 
                        (id_pasajero, fecha_prohibicion, fecha_inicio, fecha_fin, motivo, id_incidente, autoridad_emite, activa) 
                        VALUES (:p_pas, SYSDATE, :p_ini, :p_fin, :p_mot, :p_inc, :p_aut, :p_act)";

            var parametros = new[] {
                new OracleParameter("p_pas", m.IdPasajero),
                new OracleParameter("p_ini", m.FechaInicio),
                new OracleParameter("p_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_mot", (object?)m.Motivo ?? DBNull.Value),
                new OracleParameter("p_inc", (object?)m.IdIncidente ?? DBNull.Value),
                new OracleParameter("p_aut", (object?)m.AutoridadEmite ?? DBNull.Value),
                new OracleParameter("p_act", m.Activa)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EsPasajeroProhibido(int idPasajero)
        {
            var hoy = DateTime.Now.Date;
            // Verifica si hay una prohibición activa y si la fecha actual está en el rango
            return await _context.ProhibicionesVuelo
                .AnyAsync(p => p.IdPasajero == idPasajero &&
                               p.Activa == 1 &&
                               hoy >= p.FechaInicio.Date &&
                               (p.FechaFin == null || hoy <= p.FechaFin.Value.Date));
        }

        public async Task<List<ProhibicionesVueloModel>> ListarPorPasajero(int idPasajero)
        {
            return await _context.ProhibicionesVuelo
                .Where(p => p.IdPasajero == idPasajero)
                .OrderByDescending(p => p.FechaInicio)
                .ToListAsync();
        }

        public async Task<bool> DesactivarProhibicion(int id)
        {
            var sql = "UPDATE prohibiciones_vuelo SET activa = 0 WHERE id_prohibicion = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM prohibiciones_vuelo WHERE id_prohibicion = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}