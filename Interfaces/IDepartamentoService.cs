using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IDepartamentoService
    {
        Task<bool> Insertar(Departamento modelo);
        Task<Departamento?> ObtenerPorId(int id);
        Task<bool> Actualizar(Departamento modelo);
        Task<bool> Eliminar(int id);
        Task<List<Departamento>> ListarTodo();
    }
}