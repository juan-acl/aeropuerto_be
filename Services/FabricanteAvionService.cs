using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Aeropuerto.Backend.Services
{
    public class FabricanteAvionService : IFabricanteAvionService
    {
        private readonly DBContext _context;

        public FabricanteAvionService(DBContext context)
        {
            _context = context;
        }

        // 1. INSERTAR
        public async Task<bool> Insertar(FabricanteAvionModel m)
        {
            var parametros = new[] {
                new OracleParameter("p_id_fabricante", m.IdFabricante),
                new OracleParameter("p_nombre_fabricante", m.NombreFabricante),
                new OracleParameter("p_pais_origen", (object?)m.PaisOrigen ?? DBNull.Value),
                new OracleParameter("p_anio_fundacion", (object?)m.AnioFundacion ?? DBNull.Value),
                new OracleParameter("p_sede_principal", (object?)m.SedePrincipal ?? DBNull.Value),
                new OracleParameter("p_website", (object?)m.Website ?? DBNull.Value),
                new OracleParameter("p_activo", m.Activo)
            };

            string sql = "BEGIN pkg_fabricantes.insert_fabricante(:p_id_fabricante, :p_nombre_fabricante, :p_pais_origen, :p_anio_fundacion, :p_sede_principal, :p_website, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        // 2. ACTUALIZAR
        public async Task<bool> Actualizar(int id, string pais, string sede, string website, int activo)
        {
            // Recuperamos el registro actual para obtener nombre y año, 
            // requeridos por la firma del SP update_fabricante
            var actual = await ObtenerPorId(id);
            if (actual == null) return false;

            var sql = "BEGIN pkg_fabricantes.update_fabricante(:p_id_fabricante, :p_nombre_fabricante, :p_pais_origen, :p_anio_fundacion, :p_sede_principal, :p_website, :p_activo); END;";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_id_fabricante", id),
                new OracleParameter("p_nombre_fabricante", actual.NombreFabricante),
                new OracleParameter("p_pais_origen", (object?)pais ?? DBNull.Value),
                new OracleParameter("p_anio_fundacion", (object?)actual.AnioFundacion ?? DBNull.Value),
                new OracleParameter("p_sede_principal", (object?)sede ?? DBNull.Value),
                new OracleParameter("p_website", (object?)website ?? DBNull.Value),
                new OracleParameter("p_activo", activo));

            return true;
        }

        // 3. ELIMINAR
        public async Task<bool> Eliminar(int id)
        {
            var sql = "BEGIN pkg_fabricantes.delete_fabricante(:p_id_fabricante); END;";

            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id_fabricante", id));
            return true;
        }

        // 4. LISTAR
        public async Task<List<FabricanteAvionModel>> ListarTodo()
        {
            return await _context.FabricantesAviones.ToListAsync();
        }

        // 5. OBTENER POR ID
        public async Task<FabricanteAvionModel?> ObtenerPorId(int id)
        {
            return await _context.FabricantesAviones.FirstOrDefaultAsync(x => x.IdFabricante == id);
        }
    }
}

