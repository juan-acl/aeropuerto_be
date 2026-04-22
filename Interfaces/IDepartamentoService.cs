using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IDepartamentoService
    {
        Task<List<Departamento>> ListarTodo();
        Task<Departamento?> ObtenerPorId(int id);
        Task<bool> Insertar(Departamento modelo);
        Task<bool> Actualizar(int id, Departamento modelo);
        Task<bool> Eliminar(int id);
    }
}
