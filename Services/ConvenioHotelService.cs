using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ConvenioHotelService : IConveniosHotelesService
    {
        private readonly DBContext _context;
        public ConvenioHotelService(DBContext context) => _context = context;

        public async Task<bool> Insertar(ConveniosHotelesTransporte m)
        {
            var p = new[] {
                new OracleParameter("p_id_hotel_cercano", (object?)m.IdHotelCercano ?? DBNull.Value),
                new OracleParameter("p_id_empresa_transporte", (object?)m.IdEmpresaTransporte ?? DBNull.Value),
                new OracleParameter("p_tipo_convenio", (object?)m.TipoConvenio ?? DBNull.Value),
                new OracleParameter("p_tarifa_especial", (object?)m.TarifaEspecial ?? DBNull.Value),
                new OracleParameter("p_condiciones", (object?)m.Condiciones ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_convenios_hoteles.insert_convenio(:p_id_hotel_cercano, :p_id_empresa_transporte, :p_tipo_convenio, :p_tarifa_especial, :p_condiciones, :p_fecha_inicio, :p_fecha_fin, :p_activo); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, ConveniosHotelesTransporte m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_convenio_hotel", m.IdConvenioHotel)
            };
            p.AddRange(new[] {
                new OracleParameter("p_id_hotel_cercano", (object?)m.IdHotelCercano ?? DBNull.Value),
                new OracleParameter("p_id_empresa_transporte", (object?)m.IdEmpresaTransporte ?? DBNull.Value),
                new OracleParameter("p_tipo_convenio", (object?)m.TipoConvenio ?? DBNull.Value),
                new OracleParameter("p_tarifa_especial", (object?)m.TarifaEspecial ?? DBNull.Value),
                new OracleParameter("p_condiciones", (object?)m.Condiciones ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_activo", (object?)m.Activo ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_convenios_hoteles.update_convenio(:p_id_convenio_hotel, :p_id_hotel_cercano, :p_id_empresa_transporte, :p_tipo_convenio, :p_tarifa_especial, :p_condiciones, :p_fecha_inicio, :p_fecha_fin, :p_activo); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_convenios_hoteles.delete_convenio(:p_id_convenio_hotel); END;",
                new OracleParameter("p_id_convenio_hotel", id));
            return true;
        }

        public async Task<List<ConveniosHotelesTransporte>> ListarTodo() => await _context.Set<ConveniosHotelesTransporte>().ToListAsync();

        public async Task<ConveniosHotelesTransporte?> ObtenerPorId(int id) => await _context.Set<ConveniosHotelesTransporte>().FindAsync(id);
    }
}
