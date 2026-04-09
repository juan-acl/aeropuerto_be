using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IObjetosPerdidosService
    {
        Task<bool> RegistrarObjeto(ObjetosPerdidosModel modelo);
        Task<List<ObjetosPerdidosModel>> ListarNoEntregados(string? codigoAeropuerto = null);
        Task<ObjetosPerdidosModel?> ObtenerFoto(int id);
        Task<bool> EntregarObjeto(int id, int idPasajero);
        Task<bool> EliminarFisico(int id);
    }
}