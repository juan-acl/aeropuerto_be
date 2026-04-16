using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPasajeroService
    {
        Task<bool> Insertar(PasajeroModel modelo);
        Task<bool> ActualizarContacto(int id, string telefono, string email, string direccion);
        Task<bool> Eliminar(int id);
        Task<List<PasajeroModel>> ListarTodo();
    }
}