using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Aeropuerto.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class EmpresasTransporteService : IEmpresasTransporteService
    {
        private readonly DBContext _primary;
        private readonly ReplicaDBContext _replica;
        public EmpresasTransporteService(DBContext primary, ReplicaDBContext replica) { _primary = primary; _replica = replica; }

        public async Task<List<EmpresasTransporte>> ListarTodo()
        {
            try { return await _replica.EmpresasTransporte.ToListAsync(); }
            catch (Exception ex) { Console.WriteLine($"ERROR ListarTodo EmpresasTransporte: {ex.Message}"); return new List<EmpresasTransporte>(); }
        }

        public async Task<EmpresasTransporte ?> ObtenerPorId(int id)
        {
            try { return await _replica.EmpresasTransporte.FindAsync(id); }
            catch (Exception ex) { Console.WriteLine($"ERROR ObtenerPorId EmpresasTransporte: {ex.Message}"); return null; }
        }

        public async Task<bool> Insertar(EmpresasTransporte m)
        {
            try
            {
                string sql = "BEGIN pkg_empresas_transporte.insert_empresa(:p_nombre_empresa, :p_nit, :p_tipo_empresa, :p_telefono_contacto, :p_email_contacto, :p_website, :p_persona_contacto, :p_telefono_emergencia, :p_horario_atencion, :p_calificacion_promedio, :p_autorizada_aeropuerto, :p_fecha_autorizacion, :p_fecha_vencimiento_autorizacion, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_nombre_empresa", (object?)m.NombreEmpresa ?? DBNull.Value),
                    new OracleParameter("p_nit", (object?)m.Nit ?? DBNull.Value),
                    new OracleParameter("p_tipo_empresa", (object?)m.TipoEmpresa ?? DBNull.Value),
                    new OracleParameter("p_telefono_contacto", (object?)m.TelefonoContacto ?? DBNull.Value),
                    new OracleParameter("p_email_contacto", (object?)m.EmailContacto ?? DBNull.Value),
                    new OracleParameter("p_website", (object?)m.Website ?? DBNull.Value),
                    new OracleParameter("p_persona_contacto", (object?)m.PersonaContacto ?? DBNull.Value),
                    new OracleParameter("p_telefono_emergencia", (object?)m.TelefonoEmergencia ?? DBNull.Value),
                    new OracleParameter("p_horario_atencion", (object?)m.HorarioAtencion ?? DBNull.Value),
                    new OracleParameter("p_calificacion_promedio", (object?)m.CalificacionPromedio ?? DBNull.Value),
                    new OracleParameter("p_autorizada_aeropuerto", (object?)m.AutorizadaAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_fecha_autorizacion", (object?)m.FechaAutorizacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_vencimiento_autorizacion", (object?)m.FechaVencimientoAutorizacion ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Insertar EmpresasTransporte: {ex.Message}"); throw; }
        }

        public async Task<bool> Actualizar(int id, EmpresasTransporte m)
        {
            try
            {
                string sql = "BEGIN pkg_empresas_transporte.update_empresa(:p_id_empresa_transporte, :p_nombre_empresa, :p_nit, :p_tipo_empresa, :p_telefono_contacto, :p_email_contacto, :p_website, :p_persona_contacto, :p_telefono_emergencia, :p_horario_atencion, :p_calificacion_promedio, :p_autorizada_aeropuerto, :p_fecha_autorizacion, :p_fecha_vencimiento_autorizacion, :p_activa); END;";
                var p = new OracleParameter[] {
                    new OracleParameter("p_id_empresa_transporte", id),
                    new OracleParameter("p_nombre_empresa", (object?)m.NombreEmpresa ?? DBNull.Value),
                    new OracleParameter("p_nit", (object?)m.Nit ?? DBNull.Value),
                    new OracleParameter("p_tipo_empresa", (object?)m.TipoEmpresa ?? DBNull.Value),
                    new OracleParameter("p_telefono_contacto", (object?)m.TelefonoContacto ?? DBNull.Value),
                    new OracleParameter("p_email_contacto", (object?)m.EmailContacto ?? DBNull.Value),
                    new OracleParameter("p_website", (object?)m.Website ?? DBNull.Value),
                    new OracleParameter("p_persona_contacto", (object?)m.PersonaContacto ?? DBNull.Value),
                    new OracleParameter("p_telefono_emergencia", (object?)m.TelefonoEmergencia ?? DBNull.Value),
                    new OracleParameter("p_horario_atencion", (object?)m.HorarioAtencion ?? DBNull.Value),
                    new OracleParameter("p_calificacion_promedio", (object?)m.CalificacionPromedio ?? DBNull.Value),
                    new OracleParameter("p_autorizada_aeropuerto", (object?)m.AutorizadaAeropuerto ?? DBNull.Value),
                    new OracleParameter("p_fecha_autorizacion", (object?)m.FechaAutorizacion ?? DBNull.Value),
                    new OracleParameter("p_fecha_vencimiento_autorizacion", (object?)m.FechaVencimientoAutorizacion ?? DBNull.Value),
                    new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value)
                };
                await _primary.Database.ExecuteSqlRawAsync(sql, p);
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Actualizar EmpresasTransporte: {ex.Message}"); throw; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                string sql = "BEGIN pkg_empresas_transporte.delete_empresa(:p_id); END;";
                await _primary.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
                return true;
            }
            catch (Exception ex) { Console.WriteLine($"ERROR Eliminar EmpresasTransporte: {ex.Message}"); throw; }
        }
    }
}
