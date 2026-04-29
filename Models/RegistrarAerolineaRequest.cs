namespace Aeropuerto.Backend.Models
{
    public class RegistrarAerolineaRequest
    {
        public string Nombre { get; set; }
        public string CodigoIata { get; set; }
        public string CodigoOaci { get; set; }
        public string PaisOrigen { get; set; }
        public string Contacto { get; set; }
    }
}
