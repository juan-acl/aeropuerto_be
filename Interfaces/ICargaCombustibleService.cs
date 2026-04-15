using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICargaCombustibleService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(CargasCombustible modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, CargasCombustible modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<CargasCombustible>> ListarTodo();

        // Buscar por ID específico
        Task<CargasCombustible?> ObtenerPorId(int id);
    }
}


