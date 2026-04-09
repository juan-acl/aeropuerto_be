using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PublicidadService : IPublicidadService
    {
        private readonly DBContext _context;

        public PublicidadService(DBContext context) => _context = context;

        public async Task<int> RegistrarPublicidad(PublicidadModel m)
        {
            // Nota: Inicialmente registramos sin el BLOB. El archivo se sube por separado para optimizar la red.
            var sql = @"INSERT INTO publicidad 
                        (codigo_aeropuerto, ubicacion, tipo_publicidad, empresa_anunciante, 
                         fecha_inicio, fecha_fin, costo, activo) 
                        VALUES (:p_aero, :p_ubic, :p_tipo, :p_empresa, 
                                :p_inicio, :p_fin, :p_costo, 1)
                        RETURNING id_publicidad INTO :p_id_out";

            var idOutParam = new OracleParameter("p_id_out", OracleDbType.Int32, ParameterDirection.Output);

            var parametros = new[] {
                new OracleParameter("p_aero", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                new OracleParameter("p_ubic", (object?)m.Ubicacion ?? DBNull.Value),
                new OracleParameter("p_tipo", m.TipoPublicidad),
                new OracleParameter("p_empresa", (object?)m.EmpresaAnunciante ?? DBNull.Value),
                new OracleParameter("p_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_costo", (object?)m.Costo ?? DBNull.Value),
                idOutParam
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return Convert.ToInt32(idOutParam.Value.ToString());
        }

        public async Task<List<PublicidadModel>> ListarPorAeropuerto(string codigoAeropuerto)
        {
            // Excluimos el campo BLOB de las consultas de listado para no colapsar la memoria del servidor
            return await _context.Publicidad
                .Where(p => p.CodigoAeropuerto == codigoAeropuerto)
                .Select(p => new PublicidadModel
                {
                    IdPublicidad = p.IdPublicidad,
                    CodigoAeropuerto = p.CodigoAeropuerto,
                    Ubicacion = p.Ubicacion,
                    TipoPublicidad = p.TipoPublicidad,
                    EmpresaAnunciante = p.EmpresaAnunciante,
                    FechaInicio = p.FechaInicio,
                    FechaFin = p.FechaFin,
                    Costo = p.Costo,
                    Activo = p.Activo
                    // No incluimos 'Contrato' aquí
                })
                .OrderByDescending(p => p.FechaInicio)
                .ToListAsync();
        }

        public async Task<List<PublicidadModel>> ListarActivas(string codigoAeropuerto)
        {
            var hoy = DateTime.Now.Date;
            return await _context.Publicidad
                .Where(p => p.CodigoAeropuerto == codigoAeropuerto
                         && p.Activo == 1
                         && p.FechaInicio <= hoy
                         && p.FechaFin >= hoy)
                .Select(p => new PublicidadModel
                {
                    IdPublicidad = p.IdPublicidad,
                    Ubicacion = p.Ubicacion,
                    TipoPublicidad = p.TipoPublicidad,
                    EmpresaAnunciante = p.EmpresaAnunciante,
                    FechaFin = p.FechaFin
                })
                .ToListAsync();
        }

        public async Task<bool> SubirContrato(int idPublicidad, byte[] documentoContrato)
        {
            var sql = "UPDATE publicidad SET contrato = :p_blob WHERE id_publicidad = :p_id";

            var blobParam = new OracleParameter("p_blob", OracleDbType.Blob) { Value = documentoContrato };
            var idParam = new OracleParameter("p_id", idPublicidad);

            await _context.Database.ExecuteSqlRawAsync(sql, blobParam, idParam);
            return true;
        }

        public async Task<byte[]?> ObtenerContrato(int idPublicidad)
        {
            var publicidad = await _context.Publicidad
                .Where(p => p.IdPublicidad == idPublicidad)
                .Select(p => p.Contrato)
                .FirstOrDefaultAsync();

            return publicidad;
        }

        public async Task<bool> DesactivarPublicidad(int id)
        {
            var sql = "UPDATE publicidad SET activo = 0 WHERE id_publicidad = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM publicidad WHERE id_publicidad = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}