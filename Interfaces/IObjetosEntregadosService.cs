using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IObjetosEntregadosService
    {
        Task<List<ObjetosEntregadosModel>> ListarTodo();
        Task<ObjetosEntregadosModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ObjetosEntregadosModel m);
        Task<bool> Actualizar(int id, ObjetosEntregadosModel m);
        Task<bool> Eliminar(int id);
    }
}