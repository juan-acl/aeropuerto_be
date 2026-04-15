using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IModeloAvionService
    {
        Task<bool> Insertar(ModeloAvionModel modelo);

        // Actualiza capacidades operativas, rendimiento y estado por ID
        Task<bool> Actualizar(int id, int pasajeros, decimal carga, decimal autonomia, int activo);

        // Eliminación por ID único (PK NUMBER)
        Task<bool> Eliminar(int id);

        Task<List<ModeloAvionModel>> ListarTodo();

        // Obtener un modelo específico por su ID
        Task<ModeloAvionModel?> ObtenerPorId(int id);
    }
}

