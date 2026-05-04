using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IQuejasSugerenciasService
    {
        Task<List<QuejasSugerenciasModel>> ListarTodo();
        Task<QuejasSugerenciasModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(QuejasSugerenciasModel m);
        Task<bool> Actualizar(int id, QuejasSugerenciasModel m);
        Task<bool> Eliminar(int id);
    }
}