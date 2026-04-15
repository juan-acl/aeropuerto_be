using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ContratoService : IContratoService
    {
        private readonly DBContext _context;
        public ContratoService(DBContext context) => _context = context;

        public async Task<bool> Insertar(Contratos m)
        {
            var p = new[] {
                new OracleParameter("p_numero_contrato", (object?)m.NumeroContrato ?? DBNull.Value),
                new OracleParameter("p_nombre_contrato", (object?)m.NombreContrato ?? DBNull.Value),
                new OracleParameter("p_tipo_contrato", (object?)m.TipoContrato ?? DBNull.Value),
                new OracleParameter("p_contraparte_nombre", (object?)m.ContraparteNombre ?? DBNull.Value),
                new OracleParameter("p_contraparte_documento", (object?)m.ContraparteDocumento ?? DBNull.Value),
                new OracleParameter("p_fecha_firma", (object?)m.FechaFirma ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_fecha_terminacion_anticipada", (object?)m.FechaTerminacionAnticipada ?? DBNull.Value),
                new OracleParameter("p_monto_total", (object?)m.MontoTotal ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_forma_pago", (object?)m.FormaPago ?? DBNull.Value),
                new OracleParameter("p_objeto_contractual", (object?)m.ObjetoContractual ?? DBNull.Value),
                new OracleParameter("p_clausulas_principales", (object?)m.ClausulasPrincipales ?? DBNull.Value),
                new OracleParameter("p_documento_contrato", (object?)m.DocumentoContrato ?? DBNull.Value),
                new OracleParameter("p_renovacion_automatica", (object?)m.RenovacionAutomatica ?? DBNull.Value),
                new OracleParameter("p_notificar_vencimiento_dias", (object?)m.NotificarVencimientoDias ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_administrador_contrato", (object?)m.AdministradorContrato ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_contratos.insert_contrato(:p_numero_contrato, :p_nombre_contrato, :p_tipo_contrato, :p_contraparte_nombre, :p_contraparte_documento, :p_fecha_firma, :p_fecha_inicio, :p_fecha_fin, :p_fecha_terminacion_anticipada, :p_monto_total, :p_moneda, :p_forma_pago, :p_objeto_contractual, :p_clausulas_principales, :p_documento_contrato, :p_renovacion_automatica, :p_notificar_vencimiento_dias, :p_estado, :p_administrador_contrato, :p_observaciones); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, Contratos m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_contrato", m.IdContrato)
            };
            p.AddRange(new[] {
                new OracleParameter("p_numero_contrato", (object?)m.NumeroContrato ?? DBNull.Value),
                new OracleParameter("p_nombre_contrato", (object?)m.NombreContrato ?? DBNull.Value),
                new OracleParameter("p_tipo_contrato", (object?)m.TipoContrato ?? DBNull.Value),
                new OracleParameter("p_contraparte_nombre", (object?)m.ContraparteNombre ?? DBNull.Value),
                new OracleParameter("p_contraparte_documento", (object?)m.ContraparteDocumento ?? DBNull.Value),
                new OracleParameter("p_fecha_firma", (object?)m.FechaFirma ?? DBNull.Value),
                new OracleParameter("p_fecha_inicio", (object?)m.FechaInicio ?? DBNull.Value),
                new OracleParameter("p_fecha_fin", (object?)m.FechaFin ?? DBNull.Value),
                new OracleParameter("p_fecha_terminacion_anticipada", (object?)m.FechaTerminacionAnticipada ?? DBNull.Value),
                new OracleParameter("p_monto_total", (object?)m.MontoTotal ?? DBNull.Value),
                new OracleParameter("p_moneda", (object?)m.Moneda ?? DBNull.Value),
                new OracleParameter("p_forma_pago", (object?)m.FormaPago ?? DBNull.Value),
                new OracleParameter("p_objeto_contractual", (object?)m.ObjetoContractual ?? DBNull.Value),
                new OracleParameter("p_clausulas_principales", (object?)m.ClausulasPrincipales ?? DBNull.Value),
                new OracleParameter("p_documento_contrato", (object?)m.DocumentoContrato ?? DBNull.Value),
                new OracleParameter("p_renovacion_automatica", (object?)m.RenovacionAutomatica ?? DBNull.Value),
                new OracleParameter("p_notificar_vencimiento_dias", (object?)m.NotificarVencimientoDias ?? DBNull.Value),
                new OracleParameter("p_estado", (object?)m.Estado ?? DBNull.Value),
                new OracleParameter("p_administrador_contrato", (object?)m.AdministradorContrato ?? DBNull.Value),
                new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_contratos.update_contrato(:p_id_contrato, :p_numero_contrato, :p_nombre_contrato, :p_tipo_contrato, :p_contraparte_nombre, :p_contraparte_documento, :p_fecha_firma, :p_fecha_inicio, :p_fecha_fin, :p_fecha_terminacion_anticipada, :p_monto_total, :p_moneda, :p_forma_pago, :p_objeto_contractual, :p_clausulas_principales, :p_documento_contrato, :p_renovacion_automatica, :p_notificar_vencimiento_dias, :p_estado, :p_administrador_contrato, :p_observaciones); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_contratos.delete_contrato(:p_id_contrato); END;",
                new OracleParameter("p_id_contrato", id));
            return true;
        }

        public async Task<List<Contratos>> ListarTodo() => await _context.Set<Contratos>().ToListAsync();

        public async Task<Contratos?> ObtenerPorId(int id) => await _context.Set<Contratos>().FindAsync(id);
    }
}
