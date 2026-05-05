using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IRespaldosSistemaService
    {
        Task<List<RespaldosSistema>> ListarTodo();
        Task<RespaldosSistema ?> ObtenerPorId(int id);
        Task<bool> Insertar(RespaldosSistema m);
        Task<bool> Actualizar(int id, RespaldosSistema m);
        Task<bool> Eliminar(int id);
    }
}