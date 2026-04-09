using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface ICategoriasObjetosService
    {
        Task<bool> RegistrarCategoria(CategoriasObjetosModel modelo);
        Task<List<CategoriasObjetosModel>> ListarTodas();
        Task<List<CategoriasObjetosModel>> ListarActivas();
        Task<bool> DesactivarCategoria(int id);
        Task<bool> EliminarFisico(int id);
    }
}