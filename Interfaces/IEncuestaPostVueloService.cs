using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEncuestaPostVueloService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(EncuestasPostVuelo modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, EncuestasPostVuelo modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<EncuestasPostVuelo>> ListarTodo();

        // Buscar por ID específico
        Task<EncuestasPostVuelo?> ObtenerPorId(int id);
    }
}



