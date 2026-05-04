using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IObjetosDecomisadosService
    {
        Task<List<ObjetosDecomisadosModel>> ListarTodo();
        Task<ObjetosDecomisadosModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ObjetosDecomisadosModel m);
        Task<bool> Actualizar(int id, ObjetosDecomisadosModel m);
        Task<bool> Eliminar(int id);
    }
}