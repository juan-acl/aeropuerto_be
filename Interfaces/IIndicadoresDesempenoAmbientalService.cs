using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IIndicadoresDesempenoAmbientalService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(IndicadoresDesempenoAmbiental modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, IndicadoresDesempenoAmbiental modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<IndicadoresDesempenoAmbiental>> ListarTodo();

        // Buscar por ID específico
        Task<IndicadoresDesempenoAmbiental?> ObtenerPorId(int id);
    }
}


