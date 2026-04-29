namespace Aeropuerto.Backend.Models
{
    public class RegistrarPasajeroRequest
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; } // Puede ser null
    }
}
