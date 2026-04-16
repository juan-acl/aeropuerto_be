using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IObjetosEntregadosService
    {
        Task<bool> RegistrarEntrega(ObjetosEntregadosModel modelo);
        Task<List<ObjetosEntregadosModel>> ListarEntregas();
        Task<ObjetosEntregadosModel?> ObtenerFirma(int idEntrega);
        Task<bool> EliminarFisico(int id);
    }
}