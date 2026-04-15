using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IClausulaContratoService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(ClausulasContrato modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, ClausulasContrato modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<ClausulasContrato>> ListarTodo();

        // Buscar por ID específico
        Task<ClausulasContrato?> ObtenerPorId(int id);
    }
}


