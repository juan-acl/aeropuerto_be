using Aeropuerto.Backend.Data;
using Aeropuerto.Backend.Interfaces;
using Aeropuerto.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace Aeropuerto.Backend.Services
{
    public class ObjetosDecomisadosService : IObjetosDecomisadosService
    {
        private readonly DBContext _context;

        public ObjetosDecomisadosService(DBContext context) => _context = context;

        public async Task<bool> RegistrarDecomiso(ObjetosDecomisadosModel m)
        {
            var sql = @"INSERT INTO objetos_decomisados 
                        (id_control, id_pasajero, tipo_objeto, descripcion, cantidad, 
                         motivo_decomiso, destino_final, fecha_registro, registrado_por) 
                        VALUES (:p_ctrl, :p_pas, :p_tipo, :p_desc, :p_cant, 
                                :p_mot, :p_dest, SYSTIMESTAMP, :p_user)";

            var parametros = new[] {
                new OracleParameter("p_ctrl", (object?)m.IdControl ?? DBNull.Value),
                new OracleParameter("p_pas", (object?)m.IdPasajero ?? DBNull.Value),
                new OracleParameter("p_tipo", (object?)m.TipoObjeto ?? DBNull.Value),
                new OracleParameter("p_desc", (object?)m.Descripcion ?? DBNull.Value),
                new OracleParameter("p_cant", m.Cantidad),
                new OracleParameter("p_mot", (object?)m.MotivoDecomiso ?? DBNull.Value),
                new OracleParameter("p_dest", (object?)m.DestinoFinal ?? DBNull.Value),
                new OracleParameter("p_user", (object?)m.RegistradoPor ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parametros);
            return true;
        }

        public async Task<List<ObjetosDecomisadosModel>> ListarPorControl(int idControl)
        {
            return await _context.ObjetosDecomisados
                .Where(o => o.IdControl == idControl)
                .ToListAsync();
        }

        public async Task<List<ObjetosDecomisadosModel>> ListarPorPasajero(int idPasajero)
        {
            return await _context.ObjetosDecomisados
                .Where(o => o.IdPasajero == idPasajero)
                .OrderByDescending(o => o.FechaRegistro)
                .ToListAsync();
        }

        public async Task<bool> ActualizarDestino(int id, string nuevoDestino)
        {
            var sql = "UPDATE objetos_decomisados SET destino_final = :p_dest WHERE id_decomiso = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new OracleParameter("p_dest", nuevoDestino),
                new OracleParameter("p_id", id));
            return true;
        }

        public async Task<bool> EliminarFisico(int id)
        {
            var sql = "DELETE FROM objetos_decomisados WHERE id_decomiso = :p_id";
            await _context.Database.ExecuteSqlRawAsync(sql, new OracleParameter("p_id", id));
            return true;
        }
    }
}