using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IFabricanteAvionService
    {
        Task<bool> Insertar(FabricanteAvionModel modelo);

        // Actualiza los datos de ubicación, contacto y estado por ID
        Task<bool> Actualizar(int id, string pais, string sede, string website, int activo);

        // Eliminación por ID único (PK NUMBER)
        Task<bool> Eliminar(int id);

        Task<List<FabricanteAvionModel>> ListarTodo();

        // Obtener un fabricante específico por su ID
        Task<FabricanteAvionModel?> ObtenerPorId(int id);
    }
}

