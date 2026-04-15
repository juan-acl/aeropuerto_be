using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IConveniosHotelesService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(ConveniosHotelesTransporte modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, ConveniosHotelesTransporte modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<ConveniosHotelesTransporte>> ListarTodo();

        // Buscar por ID específico
        Task<ConveniosHotelesTransporte?> ObtenerPorId(int id);
    }
}


