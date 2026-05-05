using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IEscalasTecnicasService
    {
        Task<List<EscalasTecnicasModel>> ListarTodo();
        Task<EscalasTecnicasModel ?> ObtenerPorId(int id);
        Task<bool> Insertar(EscalasTecnicasModel m);
        Task<bool> Actualizar(int id, EscalasTecnicasModel m);
        Task<bool> Eliminar(int id);
    }
}