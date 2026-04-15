using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAerolineaService
    {
        Task<bool> Insertar(AerolineaModel modelo);

        // Actualiza los datos operativos y el estado de la aerolínea
        Task<bool> Actualizar(int id, int flota, int destinos, string alianza, int activo);

        // Eliminación lógica o física por ID
        Task<bool> Eliminar(int id);

        Task<List<AerolineaModel>> ListarTodo();

        // Opcional: Buscar por ID específico
        Task<AerolineaModel?> ObtenerPorId(int id);
    }
}

