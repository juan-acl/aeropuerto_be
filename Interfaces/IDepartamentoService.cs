using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IDepartamentoService
    {
        Task<bool> Insertar(Departamento modelo);
        Task<List<Departamento>> ListarTodo();
    }
}