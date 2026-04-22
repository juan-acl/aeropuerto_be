using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IObjetosPerdidosService
    {
        Task<List<ObjetosPerdidosModel>> ListarTodo();
        Task<ObjetosPerdidosModel?> ObtenerPorId(int id);
        Task<bool> Insertar(ObjetosPerdidosModel modelo);
        Task<bool> Actualizar(int id, ObjetosPerdidosModel modelo);
        Task<bool> Eliminar(int id);
    }
}
