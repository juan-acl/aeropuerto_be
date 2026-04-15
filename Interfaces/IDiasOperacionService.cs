using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IDiasOperacionService
    {
        Task<bool> Insertar(DiaOperacionModel modelo);

        // Actualiza el nombre del día y su estado (activo/inactivo)
        Task<bool> Actualizar(int id, string nombreDia, int activo);

        // Eliminación por ID único (PK NUMBER)
        Task<bool> Eliminar(int id);

        Task<List<DiaOperacionModel>> ListarTodo();

        // Obtener un día específico por su ID
        Task<DiaOperacionModel?> ObtenerPorId(int id);
    }
}

