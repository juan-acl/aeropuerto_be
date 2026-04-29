namespace Aeropuerto.Backend.Models
{
    public class RegistrarAeronaveRequest
    {
        public string Matricula { get; set; }
        public string CodigoIcaoTipo { get; set; } // CHAR(4) usualmente
        public int IdAerolinea { get; set; }
        public string NombreAeronave { get; set; }
        public string Configuracion { get; set; } // String conteniendo el JSON
        public int NumeroMotores { get; set; }
        public int AnioFabricacion { get; set; }
    }
}
