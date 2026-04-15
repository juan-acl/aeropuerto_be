using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICanjePuntoService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(CanjesPuntos modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, CanjesPuntos modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<CanjesPuntos>> ListarTodo();

        // Buscar por ID específico
        Task<CanjesPuntos?> ObtenerPorId(int id);
    }
}


