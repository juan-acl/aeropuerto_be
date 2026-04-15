using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroSegmentoService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(PasajerosSegmentos modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, PasajerosSegmentos modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<PasajerosSegmentos>> ListarTodo();

        // Buscar por ID específico
        Task<PasajerosSegmentos?> ObtenerPorId(int id);
    }
}


