using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPoliticaSeguridadService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(PoliticasSeguridad modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, PoliticasSeguridad modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<PoliticasSeguridad>> ListarTodo();

        // Buscar por ID específico
        Task<PoliticasSeguridad?> ObtenerPorId(int id);
    }
}


