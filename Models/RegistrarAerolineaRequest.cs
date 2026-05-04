namespace Aeropuerto.Backend.Models
{
    public class RegistrarAerolineaRequest
    {
        public string Nombre { get; set; } = null!;
        public string CodigoIata { get; set; } = null!;
        public string CodigoOaci { get; set; } = null!;
        public string PaisOrigen { get; set; } = null!;
        public string Contacto { get; set; } = null!;
    }
}
