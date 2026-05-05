using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ISlotsAeropuertoService
    {
        Task<List<SlotsAeropuerto>> ListarTodo();
        Task<SlotsAeropuerto ?> ObtenerPorId(int id);
        Task<bool> Insertar(SlotsAeropuerto m);
        Task<bool> Actualizar(int id, SlotsAeropuerto m);
        Task<bool> Eliminar(int id);
    }
}