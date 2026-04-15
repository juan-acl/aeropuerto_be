using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ITipoAeropuertoService
    {
        Task<bool> Insertar(TipoAeropuertoModel modelo);

        // Actualiza la descripción, el código (IATA/OACI) y el estado por ID
        Task<bool> Actualizar(int id, string descripcion, string codigo, int activo);

        // Eliminación por ID único (PK NUMBER)
        Task<bool> Eliminar(int id);

        Task<List<TipoAeropuertoModel>> ListarTodo();

        // Obtener un tipo específico por su ID
        Task<TipoAeropuertoModel?> ObtenerPorId(int id);
    }
}

