using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IAsignacionVehiculoRutaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(AsignacionVehiculosRutas modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, AsignacionVehiculosRutas modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<AsignacionVehiculosRutas>> ListarTodo();

        // Buscar por ID específico
        Task<AsignacionVehiculosRutas?> ObtenerPorId(int id);
    }
}
