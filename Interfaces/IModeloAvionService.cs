using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IModeloAvionService
    {
        Task<List<ModeloAvionModel>> ListarTodo();
        Task<ModeloAvionModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(ModeloAvionModel m);
        Task<bool> Actualizar(int id, ModeloAvionModel m);
        Task<bool> Eliminar(int id);
    }
}