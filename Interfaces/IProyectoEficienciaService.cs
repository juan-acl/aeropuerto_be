using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProyectoEficienciaService
    {
        Task<List<ProyectosEficienciaEnergetica>> ListarTodo();
        Task<ProyectosEficienciaEnergetica?> ObtenerPorId(int id);
        Task<bool> Insertar(ProyectosEficienciaEnergetica modelo);
        Task<bool> Actualizar(int id, ProyectosEficienciaEnergetica modelo);
        Task<bool> Eliminar(int id);
    }
}
