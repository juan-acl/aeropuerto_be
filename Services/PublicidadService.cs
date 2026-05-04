using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class PublicidadService : IPublicidadService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public PublicidadService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<PublicidadModel>> ListarTodo()
        {
            try { return await _replica.Publicidad.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo PublicidadModel: {ex.Message}"); return new List<PublicidadModel>(); }
        }

        public async Task<PublicidadModel ?> ObtenerPorId(int id)
        {
            try { return await _replica.Publicidad.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId PublicidadModel: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(PublicidadModel m)
        {
            try
            {
                string sql = "BEGIN pkg_publicidad.insert_publicidad(:p_codigo_aeropuerto, :p_ubicacion, :p_tipo_publicidad, :p_empresa_anunciante, :p_fecha_inicio, :p_fecha_fin, :p_costo, :p_contrato, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                    new OracleParameter("p_tipo_publicidad", (object?)m.TipoPublicidad ?? DBNull.Value),
                    new OracleParameter("p_empresa_anunciante", (object?)m.EmpresaAnunciante ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                    new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                    new OracleParameter("p_costo", (object?)m.Costo ?? DBNull.Value),
                    new OracleParameter("p_contrato", (object?)m.Contrato ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar PublicidadModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, PublicidadModel m)
        {
            try
            {
                string sql = "BEGIN pkg_publicidad.update_publicidad(:p_id_publicidad, :p_codigo_aeropuerto, :p_ubicacion, :p_tipo_publicidad, :p_empresa_anunciante, :p_fecha_inicio, :p_fecha_fin, :p_costo, :p_contrato, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_publicidad", id),
                    new OracleParameter("p_codigo_aeropuerto", (object?)m.CodigoAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_ubicacion", (object?)m.Ubicacion ?? DBNull.Value),
                    new OracleParameter("p_tipo_publicidad", (object?)m.TipoPublicidad ?? DBNull.Value),
                    new OracleParameter("p_empresa_anunciante", (object?)m.EmpresaAnunciante ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                    new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                    new OracleParameter("p_costo", (object?)m.Costo ?? DBNull.Value),
                    new OracleParameter("p_contrato", (object?)m.Contrato ?? DBNull.Value),
                    new OracleParameter("p_activo", m.Activo)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar PublicidadModel: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_publicidad.delete_publicidad(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar PublicidadModel: {ex.Message}"); throw; }
        }
    }
}
