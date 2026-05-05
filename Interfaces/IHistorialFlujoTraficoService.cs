using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IHistorialFlujoTraficoService
    {
        Task<List<HistorialFlujoTrafico>> ListarTodo();
        Task<HistorialFlujoTrafico ?> ObtenerPorId(int id);
        Task<bool> Insertar(HistorialFlujoTrafico m);
        Task<bool> Actualizar(int id, HistorialFlujoTrafico m);
        Task<bool> Eliminar(int id);
    }
}