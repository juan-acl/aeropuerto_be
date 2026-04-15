using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IGestionResiduosService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(GestionResiduos modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, GestionResiduos modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<GestionResiduos>> ListarTodo();

        // Buscar por ID específico
        Task<GestionResiduos?> ObtenerPorId(int id);
    }
}


