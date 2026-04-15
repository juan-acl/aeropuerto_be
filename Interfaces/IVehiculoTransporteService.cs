using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IVehiculoTransporteService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(VehiculosTransporte modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, VehiculosTransporte modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<VehiculosTransporte>> ListarTodo();

        // Buscar por ID específico
        Task<VehiculosTransporte?> ObtenerPorId(int id);
    }
}


