using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICompensacionesVueloService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(CompensacionesVuelo modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, CompensacionesVuelo modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<CompensacionesVuelo>> ListarTodo();

        // Buscar por ID específico
        Task<CompensacionesVuelo?> ObtenerPorId(int id);
    }
}


