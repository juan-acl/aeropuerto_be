using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPuertasEmbarqueAsignacionService
    {
        Task<List<PuertasEmbarqueAsignacionModel>> ListarTodo();
        Task<PuertasEmbarqueAsignacionModel?> ObtenerPorId(int id);
        Task<bool> Insertar(PuertasEmbarqueAsignacionModel modelo);
        Task<bool> Actualizar(int id, PuertasEmbarqueAsignacionModel modelo);
        Task<bool> Eliminar(int id);
    }
}
