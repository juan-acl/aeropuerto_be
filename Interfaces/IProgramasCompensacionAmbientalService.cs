using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProgramasCompensacionAmbientalService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(ProgramasCompensacionAmbiental modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, ProgramasCompensacionAmbiental modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<ProgramasCompensacionAmbiental>> ListarTodo();

        // Buscar por ID específico
        Task<ProgramasCompensacionAmbiental?> ObtenerPorId(int id);
    }
}


