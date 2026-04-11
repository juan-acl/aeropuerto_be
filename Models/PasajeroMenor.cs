using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class PasajeroMenor
    {
        [Key]
        public int IdPasajeroMenor { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; } = null!;
        public string Pasaporte { get; set; } = null!;
    }
}