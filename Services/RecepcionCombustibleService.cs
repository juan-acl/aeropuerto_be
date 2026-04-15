using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class RecepcionCombustibleService : IRecepcionCombustibleService
    {
        private readonly DBContext _context;

        public RecepcionCombustibleService(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(RecepcionesCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_proveedor_combustible", (object?)m.IdProveedorCombustible ?? DBNull.Value),
                new OracleParameter("p_id_tanque", (object?)m.IdTanque ?? DBNull.Value),
                new OracleParameter("p_numero_guia", (object?)m.NumeroGuia ?? DBNull.Value),
                new OracleParameter("p_fecha_recepcion", (object?)m.FechaRecepcion ?? DBNull.Value),
                new OracleParameter("p_cantidad_recibida_litros", (object?)m.CantidadRecibidaLitros ?? DBNull.Value),
                new OracleParameter("p_cantidad_facturada_litros", (object?)m.CantidadFacturadaLitros ?? DBNull.Value),
                new OracleParameter("p_temperatura_recepcion", (object?)m.TemperaturaRecepcion ?? DBNull.Value),
                new OracleParameter("p_densidad_recepcion", (object?)m.DensidadRecepcion ?? DBNull.Value),
                new OracleParameter("p_placa_camion", (object?)m.PlacaCamion ?? DBNull.Value),
                new OracleParameter("p_transportista", (object?)m.Transportista ?? DBNull.Value),
                new OracleParameter("p_conductor", (object?)m.Conductor ?? DBNull.Value),
                new OracleParameter("p_licencia_conductor", (object?)m.LicenciaConductor ?? DBNull.Value),
                new OracleParameter("p_inspector_recibe", (object?)m.InspectorRecibe ?? DBNull.Value),
                new OracleParameter("p_certificado_calidad", (object?)m.CertificadoCalidad ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_recepciones_combustible.insert_recepcion(:p_id_proveedor_combustible, :p_id_tanque, :p_numero_guia, :p_fecha_recepcion, :p_cantidad_recibida_litros, :p_cantidad_facturada_litros, :p_temperatura_recepcion, :p_densidad_recepcion, :p_placa_camion, :p_transportista, :p_conductor, :p_licencia_conductor, :p_inspector_recibe, :p_certificado_calidad, :p_observaciones); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Actualizar(int id, RecepcionesCombustible m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_recepcion", (object?)id),
                new OracleParameter("p_id_proveedor_combustible", (object?)m.IdProveedorCombustible ?? DBNull.Value),
                new OracleParameter("p_id_tanque", (object?)m.IdTanque ?? DBNull.Value),
                new OracleParameter("p_numero_guia", (object?)m.NumeroGuia ?? DBNull.Value),
                new OracleParameter("p_fecha_recepcion", (object?)m.FechaRecepcion ?? DBNull.Value),
                new OracleParameter("p_cantidad_recibida_litros", (object?)m.CantidadRecibidaLitros ?? DBNull.Value),
                new OracleParameter("p_cantidad_facturada_litros", (object?)m.CantidadFacturadaLitros ?? DBNull.Value),
                new OracleParameter("p_temperatura_recepcion", (object?)m.TemperaturaRecepcion ?? DBNull.Value),
                new OracleParameter("p_densidad_recepcion", (object?)m.DensidadRecepcion ?? DBNull.Value),
                new OracleParameter("p_placa_camion", (object?)m.PlacaCamion ?? DBNull.Value),
                new OracleParameter("p_transportista", (object?)m.Transportista ?? DBNull.Value),
                new OracleParameter("p_conductor", (object?)m.Conductor ?? DBNull.Value),
                new OracleParameter("p_licencia_conductor", (object?)m.LicenciaConductor ?? DBNull.Value),
                new OracleParameter("p_inspector_recibe", (object?)m.InspectorRecibe ?? DBNull.Value),
                new OracleParameter("p_certificado_calidad", (object?)m.CertificadoCalidad ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };

            string sql = "BEGIN pkg_recepciones_combustible.update_recepcion(:p_id_recepcion, :p_id_proveedor_combustible, :p_id_tanque, :p_numero_guia, :p_fecha_recepcion, :p_cantidad_recibida_litros, :p_cantidad_facturada_litros, :p_temperatura_recepcion, :p_densidad_recepcion, :p_placa_camion, :p_transportista, :p_conductor, :p_licencia_conductor, :p_inspector_recibe, :p_certificado_calidad, :p_observaciones); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_recepciones_combustible.delete_recepcion(:p_id_recepcion); END;";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_recepcion", id));
            return true;
        }

        public async Task<List<RecepcionesCombustible>> ListarTodo()
        {
            return await _context.Set<RecepcionesCombustible>().ToListAsync();
        }

        public async Task<RecepcionesCombustible?> ObtenerPorId(int id) => await _context.Set<RecepcionesCombustible>().FindAsync(id);
    }
}
