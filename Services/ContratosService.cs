using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class ContratosService : IContratosService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public ContratosService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<Contratos>> ListarTodo()
        {
            try { return await _replica.Contratos.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo Contratos: {ex.Message}"); return new List<Contratos>(); }
        }

        public async Task<Contratos ?> ObtenerPorId(int id)
        {
            try { return await _replica.Contratos.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId Contratos: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(Contratos m)
        {
            try
            {
                string sql = "BEGIN pkg_contratos.insert_contrato(:p_numero_contrato, :p_nombre_contrato, :p_tipo_contrato, :p_contraparte_nombre, :p_contraparte_documento, :p_fecha_firma, :p_fecha_inicio, :p_fecha_fin, :p_fecha_terminacion_anticipada, :p_monto_total, :p_moneda, :p_forma_pago, :p_objeto_contractual, :p_clausulas_principales, :p_documento_contrato, :p_renovacion_automatica, :p_notificar_vencimiento_dias, :p_estado, :p_administrador_contrato, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_numero_contrato", (object?)m.NumeroContrato ?? DBNull.Value),
                    new OracleParameter("p_nombre_contrato", (object?)m.NombreContrato ?? DBNull.Value),
                    new OracleParameter("p_tipo_contrato", (object?)m.TipoContrato ?? DBNull.Value),
                    new OracleParameter("p_contraparte_nombre", (object?)m.ContraparteNombre ?? DBNull.Value),
                    new OracleParameter("p_contraparte_documento", (object?)m.ContraparteDocumento ?? DBNull.Value),
                    new OracleParameter("p_fecha_firma", m.FechaFirma),
                    new OracleParameter("p_fecha_inicio", m.FechaInicio),
                    new OracleParameter("p_fecha_fin", m.FechaFin),
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
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar Contratos: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, Contratos m)
        {
            try
            {
                string sql = "BEGIN pkg_contratos.update_contrato(:p_id_contrato, :p_numero_contrato, :p_nombre_contrato, :p_tipo_contrato, :p_contraparte_nombre, :p_contraparte_documento, :p_fecha_firma, :p_fecha_inicio, :p_fecha_fin, :p_fecha_terminacion_anticipada, :p_monto_total, :p_moneda, :p_forma_pago, :p_objeto_contractual, :p_clausulas_principales, :p_documento_contrato, :p_renovacion_automatica, :p_notificar_vencimiento_dias, :p_estado, :p_administrador_contrato, :p_observaciones); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_contrato", id),
                    new OracleParameter("p_numero_contrato", (object?)m.NumeroContrato ?? DBNull.Value),
                    new OracleParameter("p_nombre_contrato", (object?)m.NombreContrato ?? DBNull.Value),
                    new OracleParameter("p_tipo_contrato", (object?)m.TipoContrato ?? DBNull.Value),
                    new OracleParameter("p_contraparte_nombre", (object?)m.ContraparteNombre ?? DBNull.Value),
                    new OracleParameter("p_contraparte_documento", (object?)m.ContraparteDocumento ?? DBNull.Value),
                    new OracleParameter("p_fecha_firma", m.FechaFirma),
                    new OracleParameter("p_fecha_inicio", m.FechaInicio),
                    new OracleParameter("p_fecha_fin", m.FechaFin),
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
                    new OracleParameter("p_observaciones", (object?)m.Observaciones ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar Contratos: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_contratos.delete_contrato(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar Contratos: {ex.Message}"); throw; }
        }
    }
}
