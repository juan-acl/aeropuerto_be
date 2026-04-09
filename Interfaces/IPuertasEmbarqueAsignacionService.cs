using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IPuertasEmbarqueAsignacionService
    {
        Task<bool> Insertar(PuertasEmbarqueAsignacionModel modelo);
        Task<List<PuertasEmbarqueAsignacionModel>> ListarPorVuelo(int idVuelo);
        Task<List<PuertasEmbarqueAsignacionModel>> ListarOcupacionActual();
        Task<bool> Actualizar(int id, PuertasEmbarqueAsignacionModel modelo);
        Task<bool> EliminarFisico(int id);
    }
}