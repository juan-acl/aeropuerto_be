using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ConveniosHotelesTransporteService : IConveniosHotelesTransporteService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ConveniosHotelesTransporteService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<ConveniosHotelesTransporte>> ListarTodo()
        {
            try { return await _replica.ConveniosHoteles.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo ConveniosHotelesTransporte: {ex.Message}"); return new List<ConveniosHotelesTransporte>(); }
        }

        public async Task<ConveniosHotelesTransporte ?> ObtenerPorId(int id)
        {
            try { return await _replica.ConveniosHoteles.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId ConveniosHotelesTransporte: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(ConveniosHotelesTransporte m)
        {
            try
            {
                string sql = "BEGIN pkg_convenios_hoteles.insert_convenio(:p_id_hotel_cercano, :p_id_empresa_transporte, :p_tipo_convenio, :p_tarifa_especial, :p_condiciones, :p_fecha_inicio, :p_fecha_fin, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_hotel_cercano", m.IdHotelCercano),
                    new OracleParameter("p_id_empresa_transporte", m.IdEmpresaTransporte),
                    new OracleParameter("p_tipo_convenio", (object?)m.TipoConvenio ?? DBNull.Value),
                    new OracleParameter("p_tarifa_especial", (object?)m.TarifaEspecial ?? DBNull.Value),
                    new OracleParameter("p_condiciones", (object?)m.Condiciones ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", m.FechaInicio),
                    new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar ConveniosHotelesTransporte: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, ConveniosHotelesTransporte m)
        {
            try
            {
                string sql = "BEGIN pkg_convenios_hoteles.update_convenio(:p_id_convenio_hotel, :p_id_hotel_cercano, :p_id_empresa_transporte, :p_tipo_convenio, :p_tarifa_especial, :p_condiciones, :p_fecha_inicio, :p_fecha_fin, :p_activo); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_convenio_hotel", id),
                    new OracleParameter("p_id_hotel_cercano", m.IdHotelCercano),
                    new OracleParameter("p_id_empresa_transporte", m.IdEmpresaTransporte),
                    new OracleParameter("p_tipo_convenio", (object?)m.TipoConvenio ?? DBNull.Value),
                    new OracleParameter("p_tarifa_especial", (object?)m.TarifaEspecial ?? DBNull.Value),
                    new OracleParameter("p_condiciones", (object?)m.Condiciones ?? DBNull.Value),
                    new OracleParameter("p_fecha_inicio", m.FechaInicio),
                    new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                    new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar ConveniosHotelesTransporte: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_convenios_hoteles.delete_convenio(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar ConveniosHotelesTransporte: {ex.Message}"); throw; }
        }
    }
}
