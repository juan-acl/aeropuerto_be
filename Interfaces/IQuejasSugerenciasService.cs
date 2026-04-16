using Aeropuerto.Backend.Models;

namespace Aeropuerto.Backend.Interfaces
{
    public interface IQuejasSugerenciasService
    {
        Task<int> RegistrarContacto(QuejasSugerenciasModel modelo);
        Task<bool> ResponderContacto(int idQueja, string respuestaTexto);
        Task<bool> CalificarRespuesta(int idQueja, int nivelSatisfaccion);
        Task<List<QuejasSugerenciasModel>> ListarPorEstado(string estado);
        Task<List<QuejasSugerenciasModel>> ListarPorPasajero(int idPasajero);
        Task<bool> EliminarFisico(int id);
    }
}