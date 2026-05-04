using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IObjetosPerdidosService
    {
        Task<List<ObjetosPerdidosModel>> ListarTodo();
        Task<ObjetosPerdidosModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ObjetosPerdidosModel m);
        Task<bool> Actualizar(int id, ObjetosPerdidosModel m);
        Task<bool> Eliminar(int id);
    }
}