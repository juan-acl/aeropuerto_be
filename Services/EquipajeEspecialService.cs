using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class EquipajeEspecialService : IEquipajeEspecialService
    {
        private readonly DBContext _context;

        public EquipajeEspecialService(DBContext context) => _context = context;

        public async Task<bool> Insertar(EquipajeEspecialModel m)
        {
            var sql = @"INSERT INTO equipaje_especial 
                        (id_reserva, tipo_equipaje, peso_kg, dimensiones, contenido, requiere_autorizacion, costo_adicional) 
                        VALUES (:p_res, :p_tipo, :p_peso, :p_dim, :p_cont, :p_req, :p_costo)";

            var parametros = new[] {
                new OracleParameter("p_res", m.IdReserva),
                new OracleParameter("p_tipo", m.TipoEquipaje),
                new OracleParameter("p_peso", m.PesoKg),
                new OracleParameter("p_dim", (object?)m.Dimensiones ?? DBNull.Value),
                new OracleParameter("p_cont", (object?)m.Contenido ?? DBNull.Value),
                new OracleParameter("p_req", m.RequiereAutorizacion),
                new OracleParameter("p_costo", m.CostoAdicional)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<EquipajeEspecialModel>> ListarPorReserva(int idReserva)
        {
            return await _context.EquipajeEspecial
                .Where(e => e.IdReserva == idReserva)
                .ToListAsync();
        }

        public async Task<bool> AutorizarEquipaje(int id, decimal costo)
        {
            var sql = "UPDATE equipaje_especial SET autorizado = 1, costo_adicional = :p_costo WHERE id_equipaje_especial = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_costo", costo),
                new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> Actualizar(int id, EquipajeEspecialModel m)
        {
            var sql = @"UPDATE equipaje_especial 
                        SET tipo_equipaje = :p_tipo, peso_kg = :p_peso, dimensiones = :p_dim, contenido = :p_cont 
                        WHERE id_equipaje_especial = :p_id";

            var parametros = new[] {
                new OracleParameter("p_tipo", m.TipoEquipaje),
                new OracleParameter("p_peso", m.PesoKg),
                new OracleParameter("p_dim", m.Dimensiones),
                new OracleParameter("p_cont", m.Contenido),
                new OracleParameter("p_id", id)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM equipaje_especial WHERE id_equipaje_especial = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}