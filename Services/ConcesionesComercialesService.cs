using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ConcesionesComercialesService : IConcesionesComercialesService
    {
        private readonly DBContext _context;

        public ConcesionesComercialesService(DBContext context) => _context = context;

        public async Task<bool> RegistrarConcesion(ConcesionesComercialesModel m)
        {
            var sql = @"INSERT INTO concesiones_comerciales 
                        (codigo_aeropuerto, nombre_comercial, tipo_negocio, empresa, ruc, 
                         representante, telefono_contacto, email_contacto, fecha_inicio_concesion, 
                         fecha_fin_concesion, canon_mensual, ubicacion_terminal, local_numero, area_m2, activo) 
                        VALUES (:p_aero, :p_nom, :p_tipo, :p_emp, :p_ruc, 
                                :p_rep, :p_tel, :p_email, :p_inicio, :p_fin, 
                                :p_canon, :p_term, :p_loc, :p_area, 1)";

            var parametros = new[] {
                new OracleParameter("p_aero", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_nom", (object?)m.NombreComercial ?? DBNull.Value),
                new OracleParameter("p_tipo", m.TipoNegocio),
                new OracleParameter("p_emp", (object?)m.Empresa ?? DBNull.Value),
                new OracleParameter("p_ruc", (object?)m.Ruc ?? DBNull.Value),
                new OracleParameter("p_rep", (object?)m.Representante ?? DBNull.Value),
                new OracleParameter("p_tel", (object?)m.TelefonoContacto ?? DBNull.Value),
                new OracleParameter("p_email", (object?)m.EmailContacto ?? DBNull.Value),
                new OracleParameter("p_inicio", (object?)m.FechaInicioConcesion ?? DBNull.Value),
                new OracleParameter("p_fin", (object?)m.FechaFinConcesion ?? DBNull.Value),
                new OracleParameter("p_canon", (object?)m.CanonMensual ?? DBNull.Value),
                new OracleParameter("p_term", (object?)m.UbicacionTerminal ?? DBNull.Value),
                new OracleParameter("p_loc", (object?)m.LocalNumero ?? DBNull.Value),
                new OracleParameter("p_area", (object?)m.AreaM2 ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<ConcesionesComercialesModel>> ListarPorAeropuerto(string codigo)
        {
            return await _context.ConcesionesComerciales
                .Where(c => c.CodigoAeropuerto == codigo)
                .OrderBy(c => c.NombreComercial)
                .ToListAsync();
        }

        public async Task<List<ConcesionesComercialesModel>> ListarActivas(string codigo)
        {
            return await _context.ConcesionesComerciales
                .Where(c => c.CodigoAeropuerto == codigo && c.Activo == 1)
                .OrderBy(c => c.NombreComercial)
                .ToListAsync();
        }

        public async Task<bool> RenovarContrato(int idConcesion, DateTime nuevaFechaFin, decimal nuevoCanon)
        {
            var sql = @"UPDATE concesiones_comerciales 
                        SET fecha_fin_concesion = :p_fin, 
                            canon_mensual = :p_canon 
                        WHERE id_concesion = :p_id";

            var parametros = new[] {
                new OracleParameter("p_fin", nuevaFechaFin),
                new OracleParameter("p_canon", nuevoCanon),
                new OracleParameter("p_id", idConcesion)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> DesactivarConcesion(int id)
        {
            // Soft delete para mantener el registro histórico de inquilinos pasados
            var sql = "UPDATE concesiones_comerciales SET activo = 0 WHERE id_concesion = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM concesiones_comerciales WHERE id_concesion = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}