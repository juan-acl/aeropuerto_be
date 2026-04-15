using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IContratoService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(Contratos modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, Contratos modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<Contratos>> ListarTodo();

        // Buscar por ID específico
        Task<Contratos?> ObtenerPorId(int id);
    }
}


