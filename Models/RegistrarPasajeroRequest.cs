namespace Aeropuerto.Backend.Models
{
    public class RegistrarPasajeroRequest
    {
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public string Nacionalidad { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; } = null!; // Puede ser null
    }
}
