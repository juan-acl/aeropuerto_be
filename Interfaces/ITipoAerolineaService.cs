using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITipoAerolineaService
    {
        Task<bool> Insertar(TipoAerolineaModel modelo);

        // Actualiza la descripción (COMERCIAL, CARGA, etc.) y el estado por ID
        Task<bool> Actualizar(int id, string descripcion, int activo);

        // Eliminación por ID único (PK NUMBER)
        Task<bool> Eliminar(int id);

        Task<List<TipoAerolineaModel>> ListarTodo();

        // Obtener un tipo específico por su ID
        Task<TipoAerolineaModel?> ObtenerPorId(int id);
    }
}

