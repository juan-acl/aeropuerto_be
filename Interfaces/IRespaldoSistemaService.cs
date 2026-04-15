using Aeropuerto.Backend.Models;
namespace Aeropuerto.Backend.Interfaces
{
    public interface IRespaldoSistemaService
    {
        Task<List<RespaldosSistema>> ListarTodo();
        Task<RespaldosSistema?> ObtenerPorId(int id);
        Task<bool> Insertar(RespaldosSistema modelo);
        Task<bool> Actualizar(int id, RespaldosSistema modelo);
        Task<bool> Eliminar(int id);
    }
}
