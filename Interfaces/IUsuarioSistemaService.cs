using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IUsuarioSistemaService
    {
        // Inserta un nuevo registro
        Task<bool> Insertar(UsuariosSistema modelo);

        // Actualiza los datos del registro por ID
        // Nota: Ajusta los parámetros adicionales según los campos de la tabla
        Task<bool> Actualizar(int id, UsuariosSistema modelo);

        // Eliminación por ID
        Task<bool> Eliminar(int id);

        // Obtiene la lista completa
        Task<List<UsuariosSistema>> ListarTodo();

        // Buscar por ID específico
        Task<UsuariosSistema?> ObtenerPorId(int id);
    }
}


