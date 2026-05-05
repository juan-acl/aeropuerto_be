using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IProyectosEficienciaEnergeticaService
    {
        Task<List<ProyectosEficienciaEnergetica>> ListarTodo();
        Task<ProyectosEficienciaEnergetica ?> ObtenerPorId(int id);
        Task<bool> Insertar(ProyectosEficienciaEnergetica m);
        Task<bool> Actualizar(int id, ProyectosEficienciaEnergetica m);
        Task<bool> Eliminar(int id);
    }
}