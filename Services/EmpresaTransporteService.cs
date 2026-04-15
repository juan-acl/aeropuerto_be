using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EmpresaTransporteService : IEmpresaTransporteService
    {
        private readonly DBContext _context;
        public EmpresaTransporteService(DBContext context) => _context = context;

        public async Task<bool> Insertar(EmpresasTransporte m)
        {
            var p = new[] {
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
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
            };
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_empresas_transporte.insert_empresa(:p_nombre_empresa, :p_nit, :p_tipo_empresa, :p_telefono_contacto, :p_email_contacto, :p_website, :p_persona_contacto, :p_telefono_emergencia, :p_horario_atencion, :p_calificacion_promedio, :p_autorizada_aeropuerto, :p_fecha_autorizacion, :p_fecha_vencimiento_autorizacion, :p_activa); END;", p);
            return true;
        }

        public async Task<bool> Actualizar(int id, EmpresasTransporte m)
        {
            var p = new List<OracleParameter> {
                new OracleParameter("p_id_empresa_transporte", m.IdEmpresaTransporte)
            };
            p.AddRange(new[] {
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
                new OracleParameter("p_activa", (object?)m.Activa ?? DBNull.Value),
            });

            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_empresas_transporte.update_empresa(:p_id_empresa_transporte, :p_nombre_empresa, :p_nit, :p_tipo_empresa, :p_telefono_contacto, :p_email_contacto, :p_website, :p_persona_contacto, :p_telefono_emergencia, :p_horario_atencion, :p_calificacion_promedio, :p_autorizada_aeropuerto, :p_fecha_autorizacion, :p_fecha_vencimiento_autorizacion, :p_activa); END;", p.ToArray());
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("BEGIN pkg_empresas_transporte.delete_empresa(:p_id_empresa_transporte); END;", 
                new OracleParameter("p_id_empresa_transporte", id));
            return true;
        }

        public async Task<List<EmpresasTransporte>> ListarTodo() => await _context.Set<EmpresasTransporte>().ToListAsync();

        public async Task<EmpresasTransporte?> ObtenerPorId(int id) => await _context.Set<EmpresasTransporte>().FindAsync(id);
    }
}
