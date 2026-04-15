using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAsignacionServicioTransporteService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(AsignacionServiciosTransporte modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, AsignacionServiciosTransporte modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<AsignacionServiciosTransporte>> ListarTodo();

        // Buscar por ID específico
        Task<AsignacionServiciosTransporte?> ObtenerPorId(int id);
    }
}
