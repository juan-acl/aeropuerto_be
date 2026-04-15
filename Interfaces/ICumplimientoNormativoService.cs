using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICumplimientoNormativoService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(CumplimientoNormativo modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, CumplimientoNormativo modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<CumplimientoNormativo>> ListarTodo();

        // Buscar por ID específico
        Task<CumplimientoNormativo?> ObtenerPorId(int id);
    }
}


