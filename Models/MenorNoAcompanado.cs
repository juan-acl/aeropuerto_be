using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class MenorNoAcompanado
    {
        [Key]
        public int IdServicioMenor { get; set; }
        public int IdPasajeroMenor { get; set; }
        public int IdVuelo { get; set; }
        public string PersonaEntrega { get; set; } = null!;
        public string PersonaRecibe { get; set; } = null!;
        public string TelefonoContacto { get; set; } = null!;
        public string EstadoServicio { get; set; } = "PENDIENTE";
    }
}