using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IObjetosDecomisadosService
    {
        Task<List<ObjetosDecomisadosModel>> ListarTodo();
        Task<ObjetosDecomisadosModel?> ObtenerPorId(int id);
        Task<bool> Insertar(ObjetosDecomisadosModel modelo);
        Task<bool> Actualizar(int id, ObjetosDecomisadosModel modelo);
        Task<bool> Eliminar(int id);
    }
}
