using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IChoferTransporteService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(ChoferesTransporte modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, ChoferesTransporte modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<ChoferesTransporte>> ListarTodo();

        // Buscar por ID específico
        Task<ChoferesTransporte?> ObtenerPorId(int id);
    }
}


