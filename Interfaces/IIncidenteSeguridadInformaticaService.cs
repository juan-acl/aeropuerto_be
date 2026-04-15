using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIncidenteSeguridadInformaticaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(IncidentesSeguridadInformatica modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, IncidentesSeguridadInformatica modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<IncidentesSeguridadInformatica>> ListarTodo();

        // Buscar por ID específico
        Task<IncidentesSeguridadInformatica?> ObtenerPorId(int id);
    }
}


