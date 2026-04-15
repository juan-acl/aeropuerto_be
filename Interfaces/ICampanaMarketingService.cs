using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICampanaMarketingService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(CampanasMarketing modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, CampanasMarketing modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<CampanasMarketing>> ListarTodo();

        // Buscar por ID específico
        Task<CampanasMarketing?> ObtenerPorId(int id);
    }
}

