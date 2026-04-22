using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IQuejasSugerenciasService
    {
        Task<List<QuejasSugerenciasModel>> ListarTodo();
        Task<QuejasSugerenciasModel?> ObtenerPorId(int id);
        Task<bool> Insertar(QuejasSugerenciasModel modelo);
        Task<bool> Actualizar(int id, QuejasSugerenciasModel modelo);
        Task<bool> Eliminar(int id);
    }
}
