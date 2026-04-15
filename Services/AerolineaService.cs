using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class AerolineaService : IAerolineaService
    {
        private readonly DBContext _context;

        public AerolineaService(DBContext context)
        {
            _context = context;
        }

        // 1. INSERTAR
        public async Task<bool> Insertar(AerolineaModel m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_aerolinea", m.IdAerolinea), // Generalmente 0 si es Identity
                new OracleParameter("p_nombre_aerolinea", m.NombreAerolinea),
                new OracleParameter("p_codigo_iata", (object?)m.CodigoIata ?? DBNull.Value),
                new OracleParameter("p_codigo_oaci", (object?)m.CodigoOaci ?? DBNull.Value),
                new OracleParameter("p_pais_origen", (object?)m.PaisOrigen ?? DBNull.Value),
                new OracleParameter("p_anio_fundacion", (object?)m.AnioFundacion ?? DBNull.Value),
                new OracleParameter("p_flota_total", (object?)m.FlotaTotal ?? DBNull.Value),
                new OracleParameter("p_destinos_totales", (object?)m.DestinosTotales ?? DBNull.Value),
                new OracleParameter("p_alianza", (object?)m.Alianza ?? DBNull.Value),
                new OracleParameter("p_website", (object?)m.Website ?? DBNull.Value),
                new OracleParameter("p_telefono_contacto", (object?)m.TelefonoContacto ?? DBNull.Value),
                new OracleParameter("p_email_contacto", (object?)m.EmailContacto ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
            };

            string sql = "BEGIN pkg_aerolineas.insert_aerolinea(:p_id_aerolinea, :p_nombre_aerolinea, :p_codigo_iata, :p_codigo_oaci, :p_pais_origen, :p_anio_fundacion, :p_flota_total, :p_destinos_totales, :p_alianza, :p_website, :p_telefono_contacto, :p_email_contacto, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        // 2. ACTUALIZAR 
        // Nota: He ajustado la firma para que coincida con la del paquete de Oracle
        public async Task<bool> Actualizar(int id, int flota, int destinos, string alianza, int activo)
        {
            // Nota: El SP de Oracle pide todos los campos. 
            // Si el SP solo requiere estos 4, el mapeo sería así:
            var sql = "BEGIN pkg_aerolineas.update_aerolinea_basico(:p_id_aerolinea, :p_flota_total, :p_destinos_totales, :p_alianza, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_id_aerolinea", id),
                new OracleParameter("p_flota_total", flota),
                new OracleParameter("p_destinos_totales", destinos),
                new OracleParameter("p_alianza", (object?)alianza ?? DBNull.Value),
                new OracleParameter("p_activo", activo));

            return true;
        }

        // 3. ELIMINAR
        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_aerolineas.delete_aerolinea(:p_id_aerolinea); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_aerolinea", id));
            return true;
        }

        // 4. LISTAR
        public async Task<List<AerolineaModel>> ListarTodo()
        {
            return await _context.Aerolineas.ToListAsync();
        }

        // 5. OBTENER POR ID
        public async Task<AerolineaModel?> ObtenerPorId(int id)
        {
            return await _context.Aerolineas.FirstOrDefaultAsync(x => x.IdAerolinea == id);
        }
    }
}

