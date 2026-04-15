using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPuntoEncuentroService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(PuntosEncuentro modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, PuntosEncuentro modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<PuntosEncuentro>> ListarTodo();

        // Buscar por ID específico
        Task<PuntosEncuentro?> ObtenerPorId(int id);
    }
}


